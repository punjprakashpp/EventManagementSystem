using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ManageEvents : System.Web.UI.Page
{
    private string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserRole"].ToString() != "Admin")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            LoadEvents();
        }
    }


    private void LoadEvents()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Events", conn);
            conn.Open();
            gvEvents.DataSource = cmd.ExecuteReader();
            gvEvents.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = hfEventID.Value == "" ?
                "INSERT INTO Events (EventName, EventDate, Location, Description) VALUES (@Name, @Date, @Location, @Description)" :
                "UPDATE Events SET EventName=@Name, EventDate=@Date, Location=@Location, Description=@Description WHERE EventID=@EventID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", txtEventName.Text);
            cmd.Parameters.AddWithValue("@Date", txtEventDate.Text);
            cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            if (hfEventID.Value != "") cmd.Parameters.AddWithValue("@EventID", hfEventID.Value);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        ClearForm();
        LoadEvents();
    }

    protected void gvEvents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        int eventId = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "EditEvent")
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Events WHERE EventID=@EventID", conn);
                cmd.Parameters.AddWithValue("@EventID", eventId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hfEventID.Value = eventId.ToString();
                    txtEventName.Text = reader["EventName"].ToString();
                    txtEventDate.Text = Convert.ToDateTime(reader["EventDate"]).ToString("yyyy-MM-dd");
                    txtLocation.Text = reader["Location"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                }
            }
        }
        else if (e.CommandName == "DeleteEvent")
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Events WHERE EventID=@EventID", conn);
                cmd.Parameters.AddWithValue("@EventID", eventId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadEvents();
        }
    }

    private void ClearForm()
    {
        hfEventID.Value = "";
        txtEventName.Text = "";
        txtEventDate.Text = "";
        txtLocation.Text = "";
        txtDescription.Text = "";
    }
}
