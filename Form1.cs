using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if(txtUsername.Text == "vivek" && txtPassword.Text == "pass")
                {
                    Dashboardwin dbw = new Dashboardwin("vivek");
                    dbw.Show();
                    this.Hide();
                }
            }

            else
            {
                query = "select * from users where username = '"+txtUsername.Text+"' and pass = '"+txtPassword.Text+"'";
                ds = fn.getData(query);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        string adminUser = txtUsername.Text;
                        string adminPass = txtPassword.Text;
                        //Profile p = new Profile(adminUser);

                        Administrator adminForm = new Administrator(adminUser, adminPass);
                        Dashboardwin db = new Dashboardwin(adminUser);
                        AddUser au = new AddUser(adminUser);
                        //Profile pp = new Profile(adminUser);
                        adminForm.Show();
                        this.Hide();
                    }


                    else if (role == "Pharmacist")
                    {
                        Pharmacist ph = new Pharmacist();
                        ph.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Wrong username or passwrod", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
            /*if (txtUsername.Text == "vivek" && txtPassword.Text == "pass")
            {
                Administrator am = new Administrator();
                am.Show();
                this.Hide();
            }
            else { 
            
                MessageBox.Show("Wrong Username OR Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
