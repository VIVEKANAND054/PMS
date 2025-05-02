using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class Sales : PMS.Pharmacist
    {
        function fn = new function();
        String query;
        DataSet ds;
        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            query = $"select mname from medic where eDate>getdate() and quantity>0";
            ds = fn.getData(query);

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i]["mname"].ToString());
            }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query = $"select mname from medic where mname like '{textBox1.Text}%' and eDate>getdate() and quantity>0";

            ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i]["mname"].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnits.Clear();

            String name = listBox1.GetItemText(listBox1.SelectedItem);

            txtMedName.Text = name;
            query = $"select mid,eDate,perUnit,quantity from medic where mname = '{txtMedName.Text}'";
            ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtMedID.Text = ds.Tables[0].Rows[0]["mid"].ToString();
                txtMedppu.Text = ds.Tables[0].Rows[0]["perUnit"].ToString();
                dtpMedExp.Text = ds.Tables[0].Rows[0]["eDate"].ToString();
            }
            else
            {
                MessageBox.Show("No data found for the selected medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUnits_TextChanged(object sender, EventArgs e)
        {
            if (txtUnits.Text !="")
            {
                Int64 eu = Int64.Parse(txtUnits.Text);
                Int64 availqty = Int64.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());

                if (eu <= availqty)
                {
                    Int64 up = Int64.Parse(txtMedppu.Text);
                    Int64 ttl = up * eu; 
                    textBox2.Text = ttl.ToString();
                }
                else
                {
                    MessageBox.Show("Entered units exceed available stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnits.Clear();
                }
            }
            else
            {
                textBox2.Clear();
                MessageBox.Show("Enter valid purchasing units.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtMedppu.Clear();
            txtUnits.Clear();
            dtpMedExp.ResetText();
            textBox2.Clear();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String expDate = dtpMedExp.Text;
            Int64 units, pricePerUnit, totalAmount;

            if (txtMedID.Text == "" || txtMedName.Text=="" || txtMedppu.Text=="" || txtUnits.Text =="")
            {
                MessageBox.Show("Please select the valid medicine and enter the purchasing units.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                units = Int64.Parse(txtUnits.Text);
                pricePerUnit = Int64.Parse(txtMedppu.Text); 
                totalAmount = Int64.Parse(textBox2.Text);   
                String message = $"Medicine Purchased!\n\n" + $"Expiry Date: {expDate}\n" + $"Units: {units}\n" + $"Price per Unit: {pricePerUnit}\n" + $"Total Amount: {totalAmount}";

                MessageBox.Show(message, "Purchase Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                DeductMedicineStock(units);
            }
            
            
        }

        private void DeductMedicineStock(Int64 purchasedunit)
        {
            try
            {
                string medicinename = listBox1.SelectedItem.ToString(); 
                string query = $"update medic set quantity = quantity - {purchasedunit} where mname = '{medicinename}'";

                fn.setData(query, "Stock updated successfully!"); 
                //MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
