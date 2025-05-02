using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class ViewUser : PMS.Administrator
    {
        function fn = new function();
        string query;
        string uid;
        public ViewUser(string username1)
        {
            InitializeComponent();
            username = username1;
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = $"select * from users where username like '{txtUsername.Text}%'"; 
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                uid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
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

            

            
            DialogResult result = MessageBox.Show($"The selected id is {uid} .Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {

                    string query = $"delete from users WHERE id = {uid}";


                    
                    fn.setData(query, "Record deleted successfully!");


                    ViewUser_Load(sender, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
