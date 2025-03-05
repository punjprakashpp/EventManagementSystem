using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class UserDashboard : System.Web.UI.Page
{
    private string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            LoadUpcomingEvents();
            LoadRegisteredEvents();
        }
    }

    private void LoadUpcomingEvents()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT EventID, EventName, EventDate, Location FROM Events WHERE EventDate >= GETDATE()";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUpcomingEvents.DataSource = dt;
            gvUpcomingEvents.DataBind();
        }
    }

    private void LoadRegisteredEvents()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"SELECT e.EventName, e.EventDate, e.Location 
                             FROM EventRegistrations er
                             JOIN Events e ON er.EventID = e.EventID
                             WHERE er.UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvRegisteredEvents.DataSource = dt;
            gvRegisteredEvents.DataBind();
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int eventID = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);
        int userID = Convert.ToInt32(Session["UserID"]);

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string checkQuery = "SELECT COUNT(*) FROM EventRegistrations WHERE UserID = @UserID AND EventID = @EventID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@UserID", userID);
            checkCmd.Parameters.AddWithValue("@EventID", eventID);

            conn.Open();
            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                string insertQuery = "INSERT INTO EventRegistrations (UserID, EventID) VALUES (@UserID, @EventID)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@UserID", userID);
                insertCmd.Parameters.AddWithValue("@EventID", eventID);
                insertCmd.ExecuteNonQuery();

                lblMessage.Text = "Registration successful!";
                LoadRegisteredEvents();
            }
            else
            {
                lblMessage.Text = "You are already registered for this event.";
            }
        }
    }
}
