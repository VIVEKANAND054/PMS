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
    public partial class Administrator : Form
    {
        public static string username ;
        public static string password;
        

         public Administrator()
        {
        InitializeComponent();
        }
        
        public Administrator(string user, string pass)
        {
            InitializeComponent();
            username = user;  
            password = pass;
            
            
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboardwin db = new Dashboardwin(username);
            db.Show();
            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Username before opening Profile: " + username);
            Profile p = new Profile(username);
            p.Show();
            this.Hide();
        }
    }
}
