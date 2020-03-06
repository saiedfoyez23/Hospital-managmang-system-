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
    public partial class NewUserAdd : Form
    {
        public NewUserAdd()
        {
            InitializeComponent();
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
                    string insertquery = "Insert into USER_INFO VALUES (:1, :2, :3, :4)";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = insertquery;
                    cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, textBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("3", OracleDbType.Varchar2, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("4", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                   

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
            UserInformaton uu = new UserInformaton();
            uu.Show();
        }

        private void NewUserAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
