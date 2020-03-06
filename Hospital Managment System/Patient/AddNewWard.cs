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
    public partial class AddNewWard : Form
    {
        public AddNewWard()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "First Floar")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("101");
                comboBox2.Items.Add("103");
                comboBox2.Items.Add("105");
                comboBox2.Items.Add("107");
                comboBox2.Items.Add("109");
                comboBox2.Items.Add("111");
            }
            if (comboBox1.Text == "Second Floar")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("102");
                comboBox2.Items.Add("104");
                comboBox2.Items.Add("106");
                comboBox2.Items.Add("108");
                comboBox2.Items.Add("110");
                comboBox2.Items.Add("112");
            }
            if (comboBox1.Text == "Ground Floar")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("1111");
                comboBox2.Items.Add("1013");
                comboBox2.Items.Add("1015");
                comboBox2.Items.Add("1017");
                comboBox2.Items.Add("1019");
                comboBox2.Items.Add("1111");
            }
        }

        private void AddNewWard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Medium")
            {
                textBox3.Text = "2090";
            }
            if (comboBox3.Text == "VIP")
            {
                textBox3.Text = "20090";
            }
            if (comboBox3.Text == "Normal")
            {
                textBox3.Text = "290";
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
                    string insertquery = "Insert into WEAD VALUES (:1, :2, :3, :4, :5, :6, :7,:8)";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = insertquery;
                    cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, comboBox4.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("3", OracleDbType.Decimal, comboBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("4", OracleDbType.Varchar2, comboBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("5", OracleDbType.Decimal, textBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("6", OracleDbType.Decimal, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("7", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("8", OracleDbType.Varchar2, "None", ParameterDirection.Input));

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin aa = new admin();
            aa.Show();
        }

        private void AddNewWard_Load(object sender, EventArgs e)
        {

        }
    }
}
