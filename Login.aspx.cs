using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Login : System.Web.UI.Page
{
    private string connStr = WebConfigurationManager.ConnectionStrings["EventManagementDB"].ConnectionString;

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT UserID, FullName, UserRole FROM Users WHERE Email=@Email AND Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Use hashing in production

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["UserID"] = reader["UserID"];
                Session["FullName"] = reader["FullName"];
                Session["UserRole"] = reader["UserRole"];

                if (reader["UserRole"].ToString() == "Admin")
                    Response.Redirect("AdminDashboard.aspx");
                else
                    Response.Redirect("UserDashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid email or password!";
            }
        }
    }
}
