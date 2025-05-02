using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class AddUser : PMS.Administrator
    {
        function fn = new function();
        String query;
        string un = username;

        public AddUser(string lginun)
        {
            InitializeComponent();
            un = lginun; 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserRole.SelectedIndex = -1;
            txtDob.Value = DateTime.Now;
            
            txtName.Clear();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtcp.Clear();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            string mobile = txtMobileNo.Text;
            String email = txtEmail.Text.Trim();
            String username = txtUsername.Text;
            String pass = txtPassword.Text;
            String confirmpass = txtcp.Text;

            if (!mobile.All(char.IsDigit) || mobile.Length != 10)
            {
                MessageBox.Show("Invalid mobile number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtUserRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select role from the suggetion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (name.Length < 2 || !name.All(char.IsLetter))
            {
                MessageBox.Show("Invalid name! It must contain only alphabets and be at least 2 characters long.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (username.Length < 3 || !username.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                MessageBox.Show("Invalid username! It must be at least 3 characters long and contain only letters, numbers, and underscores (_).",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@") || !email.Contains(".") || email.Length <= 6)
            {
                MessageBox.Show("Invalid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(pass != confirmpass) {
                MessageBox.Show("Confirm your passwrd again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = $"insert into users (userRole, name, dob, mobile, email, username, pass) values ('{role}', '{name}', '{dob}', '{mobile}', '{email}', '{username}', '{pass}')";

            fn.setData(query, "Sign Up Successful.");
        }
    }
}
