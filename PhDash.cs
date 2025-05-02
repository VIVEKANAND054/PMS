using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class PhDash : PMS.Pharmacist
    {
        public PhDash()
        {
            InitializeComponent();
        }

        private void PhDash_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public void LoadChartData()
        {
            function fn = new function();  
            string query = "SELECT eDate FROM medic"; 
            DataSet ds = fn.getData(query); 

            int emc = 0, vmc = 0;
            DateTime today = DateTime.Now;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DateTime expiryDate = Convert.ToDateTime(row["eDate"]);
                if (expiryDate < today) emc++;
                else vmc++;
            }

            
            chart1.Series.Clear();// used to clear previous data chart

            
            chart1.Series.Add("Expired Medicines");
            chart1.Series.Add("Valid Medicines");

            // uisedd to adding data points
            chart1.Series["Expired Medicines"].Points.AddY(emc);
            chart1.Series["Valid Medicines"].Points.AddY(vmc);

            
        }

    }
}
