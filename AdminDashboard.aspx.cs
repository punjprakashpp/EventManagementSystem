using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class AdminDashboard : System.Web.UI.Page
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
            LoadStatistics();
        }
    }

    private void LoadStatistics()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            lblTotalEvents.Text = GetCount(conn, "SELECT COUNT(*) FROM Events").ToString();
            lblTotalUsers.Text = GetCount(conn, "SELECT COUNT(*) FROM Users").ToString();
            lblTotalRegistrations.Text = GetCount(conn, "SELECT COUNT(*) FROM EventRegistrations").ToString();
        }
    }

    private int GetCount(SqlConnection conn, string query)
    {
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            return (int)cmd.ExecuteScalar();
        }
    }
}
