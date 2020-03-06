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
    public partial class NewStaffAdd : Form
    {
        public NewStaffAdd()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staffinformaton ss = new Staffinformaton();
            ss.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Manager")
            {
                textBox3.Text = "100500";
            }
            if (comboBox2.Text == "Doctor")
            {
                textBox3.Text = "55500";
            }
            if (comboBox2.Text == "Cleaner")
            {
                textBox3.Text = "5500";
            }
            if (comboBox2.Text == "FeManager")
            {
                textBox3.Text = "100500";
            }
            if (comboBox2.Text == "Admin")
            {
                textBox3.Text = "60500";
            }
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
                    string insertquery = "Insert into STAFF VALUES (:1, :2, :3, :4, :5, :6, :7)";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = insertquery;
                    cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, textBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("3", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("4", OracleDbType.Varchar2, comboBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("5", OracleDbType.Decimal, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("6", OracleDbType.Decimal, textBox4.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("7", OracleDbType.Varchar2, textBox5.Text, ParameterDirection.Input));
                   

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
                MessageBox.Show("Database is not connected" + ex.Message);
            }
        }

        private void NewStaffAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void NewStaffAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
