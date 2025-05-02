using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class UpdateMed : PMS.Pharmacist
    {
        function fn = new function();
        DataSet ds = new DataSet();
        String query;
        Int64 ttlquant;
        public UpdateMed()
        {
            InitializeComponent();
        }

        private void UpdateMed_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtMedID.Text != "")
            {
                query = $"select * from medic where mid = {txtMedID.Text}";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0) 
                {
                    txtMedName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMedNo.Text = ds.Tables[0].Rows[0][3].ToString();
                    dtpMedMgf.Text = ds.Tables[0].Rows[0][4].ToString();
                    dtpMedExp.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAddQuant.Text = "0";
                    txtMedQuant.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtMedppu.Text = ds.Tables[0].Rows[0][7].ToString();
                    

                }
                else
                {
                    MessageBox.Show($"No Medicine found with ID: {txtMedID.Text}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show($"Medicine ID not provided", "Requirement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearall();
            }


        }

        private void clearall()
        {
            txtMedID.Text = string.Empty;
            txtMedName.Text = string.Empty;
            txtMedNo.Text = string.Empty;
            txtMedppu.Text = string.Empty;
            txtMedQuant.Text = string.Empty;
            dtpMedExp.Value = DateTime.Now;
            dtpMedMgf.Value = DateTime.Now;
            txtAddQuant.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMedID.Text == "")
            {
                MessageBox.Show("Medicine ID is not provided", "Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string mname = txtMedName.Text;
                string mnumber = txtMedNo.Text;
                string mdate = dtpMedMgf.Text;
                string edate = dtpMedExp.Text;
                Int64 quant = Int64.Parse(txtMedQuant.Text);
                Int64 ppu = (Int64.Parse(txtMedppu.Text));
                Int64 addquant = Int64.Parse(txtAddQuant.Text);
                ttlquant = quant + addquant;

                query = $"update medic set mname='{mname}',mnumber='{mnumber}',mDate='{mdate}',eDate='{edate}',quantity={ttlquant},perUnit={ppu} where mid = {txtMedID.Text}";
                fn.setData(query, "Medicine Updated Successfully");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            if (txtMedID.Text == "")
            {
                clearall();
            }
            else
            {
                try
                {
                    query = $"SELECT * FROM medic WHERE mid = {txtMedID.Text}";
                    DataSet ds = fn.getData(query);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtMedName.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtMedNo.Text = ds.Tables[0].Rows[0][3].ToString();
                        dtpMedMgf.Text = ds.Tables[0].Rows[0][4].ToString();
                        dtpMedExp.Text = ds.Tables[0].Rows[0][5].ToString();
                        txtAddQuant.Text = "0";
                        txtMedQuant.Text = ds.Tables[0].Rows[0][6].ToString();
                        txtMedppu.Text = ds.Tables[0].Rows[0][7].ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show("No medicine found with this ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearall();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
