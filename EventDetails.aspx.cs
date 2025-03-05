using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class EventDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEventDetails();
        }
    }

    private void LoadEventDetails()
    {
        string eventId = Request.QueryString["EventID"];
        if (eventId == null) return;

        string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Events WHERE EventID=@EventID", conn);
            cmd.Parameters.AddWithValue("@EventID", eventId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblEventName.Text = reader["EventName"].ToString();
                lblEventDate.Text = Convert.ToDateTime(reader["EventDate"]).ToString("MM/dd/yyyy");
                lblLocation.Text = reader["Location"].ToString();
                lblDescription.Text = reader["Description"].ToString();
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserDashboard.aspx?EventID=" + Request.QueryString["EventID"]);
    }
}