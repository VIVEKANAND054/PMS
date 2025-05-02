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
    public partial class Pharmacist : Form
    {
        public Pharmacist()
        {
            InitializeComponent();
        }

        private void Pharmacist_Load(object sender, EventArgs e)
        {
            //button1.PerformClick();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhDash d = new PhDash();
            d.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMed addMed = new AddMed();
            addMed.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewMed viewMed = new ViewMed(); 
            viewMed.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateMed um = new UpdateMed();
            um.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sales s = new Sales();
            s.Show();
            this.Hide();
        }
    }
}
