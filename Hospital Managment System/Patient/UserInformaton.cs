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
    public partial class UserInformaton : Form
    {
        public UserInformaton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewUserAdd uu = new NewUserAdd();
            uu.Show();
        }

        private void UserInformaton_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UserInformaton_Load(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {

                    DataTable dt = new DataTable();
                    OracleDataAdapter adapter = new OracleDataAdapter("select ID,NAME,POSITION from USER_INFO", con);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin aa = new admin();
            aa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {

                    string deletequery = "DELETE FROM USER_INFO WHERE ID=:id ";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = deletequery;
                    cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));


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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label4.Visible = false;
            textBox4.Visible = false;
            button5.Visible = false;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            textBox4.Visible = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {

                    string Updatequery = "update USER_INFO set PASSWORD=:password where ID=:id";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Updatequery;
                    cmd.Parameters.Add(new OracleParameter("numberofbed", OracleDbType.Varchar2, textBox4.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));


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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInformaton uu = new UserInformaton();
            uu.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
            OracleConnection con = new OracleConnection(oradb);
            con.Open();
            OracleDataAdapter adebtar = new OracleDataAdapter("select * from STAFF where NAME like '" + textBox5.Text + "%'", con);
            DataTable dt = new DataTable();
            adebtar.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
