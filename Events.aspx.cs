using System;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEvents();
        }
    }

    private void LoadEvents()
    {
        string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT EventID, EventName, EventDate, Location FROM Events", conn);
            conn.Open();
            gvEvents.DataSource = cmd.ExecuteReader();
            gvEvents.DataBind();
        }
    }
}