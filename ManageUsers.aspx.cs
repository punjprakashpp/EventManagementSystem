using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ManageUsers : System.Web.UI.Page
{
    private string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUsers();
        }
    }

    private void LoadUsers()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT UserID, FullName, Email, IsActive FROM Users", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }
    }

    protected void btnToggleStatus_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET IsActive = ~IsActive WHERE UserID = @UserID", conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.ExecuteNonQuery();
        }
        LoadUsers();
    }
}
