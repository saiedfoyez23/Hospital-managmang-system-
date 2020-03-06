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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.PatientRegistration pp = new Patient.PatientRegistration();
            pp.Show();
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
            Patient.PatientInformation ii = new Patient.PatientInformation();
            ii.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.AddNewWard ii = new Patient.AddNewWard();
            ii.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.RoomInformation ii = new Patient.RoomInformation();
            ii.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.Staffinformaton ii = new Patient.Staffinformaton();
            ii.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.UserInformaton ii = new Patient.UserInformaton();
            ii.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient.NewUserAdd ii = new Patient.NewUserAdd();
            ii.Show();
        }

        
    }
    
}
