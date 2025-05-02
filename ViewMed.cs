using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace PMS
{
    public partial class ViewMed : PMS.Pharmacist
    {
        function fn = new function();
        string query;
        string meddid;
        public ViewMed()
        {
            InitializeComponent();
        }

        private void ViewMed_Load(object sender, EventArgs e)
        {
            query = "select * from medic";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic where mname like '" + textBox1.Text + "%'"; //a%
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                meddid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show("Selected ID: " + meddid);
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            
            DialogResult result = MessageBox.Show($"The selected id is {meddid} .Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    
                    string query = $"DELETE FROM medic WHERE id = {meddid}";

                    
                    //function fn = new function();
                    fn.setData(query, "Record deleted successfully!");

                    
                    ViewMed_Load(sender,null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
