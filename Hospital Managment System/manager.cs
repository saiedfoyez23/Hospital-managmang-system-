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
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.PatiantRegistration mm = new Manager.PatiantRegistration();
            mm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ff = new Form1();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.PatientInformation mm = new Manager.PatientInformation();
            mm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.AddNewWard mm = new Manager.AddNewWard();
            mm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.RoomInformation mm = new Manager.RoomInformation();
            mm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.FinanceManagment mm = new Manager.FinanceManagment();
            mm.Show();
        }
    }
}
