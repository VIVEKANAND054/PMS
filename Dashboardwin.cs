using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class Dashboardwin : PMS.Administrator
    {
        String query;
        DataSet ds;
        function fn = new function();
        
        public Dashboardwin(string lginun)
        {
            InitializeComponent();
            //btnload.PerformClick();
            username = lginun;
        }

       

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUser ad = new AddUser(username);
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewUser vu = new ViewUser(username);
            vu.Show();
            this.Hide();
        }


        

        private void Dashboardwin_Load(object sender, EventArgs e)
        {
            query = "select count(userRole) from users where userRole = 'Administrator'";
            ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                coadmin.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                coadmin.Text = "0";
            }

            query = "select count(userRole) from users where userRole = 'Pharmacist'";
            ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                copharma.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                copharma.Text = "0";
            }
        }
    }
}
