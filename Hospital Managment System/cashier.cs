using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class cashier : Form
    {
        public cashier()
        {
            InitializeComponent();
        }

        private void cashier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cashier.PatiantRegistration cc = new Cashier.PatiantRegistration();
            cc.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mm = new Form1();
            mm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cashier.PatientInformation pp = new Cashier.PatientInformation();
            pp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cashier.AddNewWard pp = new Cashier.AddNewWard();
            pp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cashier.RoomInformation pp = new Cashier.RoomInformation();
            pp.Show();
        }
    }
}
