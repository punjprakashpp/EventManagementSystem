using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class EventRegistrations : System.Web.UI.Page
{
    private string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRegistrations();
        }
    }

    private void LoadRegistrations()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"SELECT u.FullName, e.EventName, er.RegistrationDate 
                             FROM EventRegistrations er
                             JOIN Users u ON er.UserID = u.UserID
                             JOIN Events e ON er.EventID = e.EventID";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvRegistrations.DataSource = dt;
            gvRegistrations.DataBind();
        }
    }
}
