using System;
using System.Data;
using System.Windows.Forms;

namespace PMS
{
    public partial class Profile : Administrator
    {
        private string username;
        function fn = new function(); // Using function class

        public Profile(string loginUsername)
        {
            InitializeComponent();
            username = loginUsername;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                string query = $"SELECT name, email, username, pass, userRole, mobile, dob FROM users WHERE username = '{username }'";
                DataSet ds = fn.getData(query); 

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    txtUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
                    txtPassword.Text = ds.Tables[0].Rows[0]["pass"].ToString();
                    txtUserRole.Text = ds.Tables[0].Rows[0]["userRole"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                    dtpDOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = txtUserRole.Text;
            string mobile = txtMobile.Text;
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd"); 

            if (name=="" || email == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = $"update users set name='{name}', email='{email}', pass='{password}', userRole='{role}', mobile='{mobile}', dob='{dob}' where username='{username}'";
                fn.setData(query, "Profile Updated Successfully!"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Profile_Load(sender, e); 
        }
    }
}
