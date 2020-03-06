using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace Hospital_Managment_System.Patient
{
    public partial class PatientRegistration : Form
    {
        public PatientRegistration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin aa = new admin();
            aa.Show();
            
        }

        
        private void PatientRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "A")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("101");
                comboBox3.Items.Add("103");
                comboBox3.Items.Add("105");
                comboBox3.Items.Add("107");
                comboBox3.Items.Add("109");
                comboBox3.Items.Add("111");
            }
            if (comboBox2.Text == "B")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("102");
                comboBox3.Items.Add("104");
                comboBox3.Items.Add("106");
                comboBox3.Items.Add("108");
                comboBox3.Items.Add("110");
                comboBox3.Items.Add("112");
            }
            if (comboBox2.Text == "C")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("1111");
                comboBox3.Items.Add("1013");
                comboBox3.Items.Add("1015");
                comboBox3.Items.Add("1017");
                comboBox3.Items.Add("1019");
                comboBox3.Items.Add("1111");
            }

        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {
                    string insertquery = "Insert into REGISTRATION VALUES (:1, :2, :3, :4, :5, :6, :7,:8,:9,:10,:11,:12,:13)";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = insertquery;
                    cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, textBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("3", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("4", OracleDbType.Decimal, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("5", OracleDbType.Varchar2, textBox4.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("6", OracleDbType.Varchar2, textBox5.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("7", OracleDbType.Varchar2, textBox6.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("8", OracleDbType.Varchar2, textBox7.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("9", OracleDbType.Varchar2, comboBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("10", OracleDbType.Varchar2, comboBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("11", OracleDbType.Varchar2, comboBox4.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("12", OracleDbType.Decimal, textBox9.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("13", OracleDbType.Varchar2, textBox8.Text, ParameterDirection.Input));

                    cmd.ExecuteNonQuery();

                    
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Database is not connected"+ex.Message);
            }
        }
    }
}
