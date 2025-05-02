using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class AddMed : PMS.Pharmacist
    {
        function f = new function();
        String query;

        public AddMed()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedID.Text != "" && txtMedName.Text != "" && txtMedNo.Text != "" && txtMedQuant.Text != "" && txtMedppu.Text != "")
            {
                String mid = txtMedID.Text;
                String midName = txtMedName.Text;
                String midNo = txtMedNo.Text;
                String midQuant = txtMedQuant.Text;
                String midppu = txtMedppu.Text;
                String midmfg = dtpMedMgf.Value.ToString("yyyy-MM-dd");
                String midexp = dtpMedExp.Value.ToString("yyyy-MM-dd");

                query = $"INSERT INTO medic (mid, mname, mnumber, mDate, eDate, quantity, perUnit) " +
                        $"VALUES ('{mid}', '{midName}', '{midNo}', '{midmfg}', '{midexp}', '{midQuant}', '{midppu}')";

                try
                {
                    f.setData(query, "Medicine added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMedID.Text = "";
            txtMedName.Text = "";
            txtMedNo.Text = "";
            txtMedQuant.Text = "";
            txtMedppu.Text = "";
            dtpMedMgf.Value = DateTime.Now;
            dtpMedExp.Value = DateTime.Now;

        }

        private void AddMed_Load(object sender, EventArgs e)
        {

        }
    }
}
