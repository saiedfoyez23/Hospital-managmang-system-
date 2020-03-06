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
namespace Hospital_Managment_System.Cashier
{
    public partial class PatientInformation : Form
    {
        public PatientInformation()
        {
            InitializeComponent();
        }

        private void rEGISTRATIONBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rEGISTRATIONBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.REGISTRATION' table. You can move, or remove it, as needed.
            this.rEGISTRATIONTableAdapter.Fill(this.dataSet1.REGISTRATION);

        }

        private void rEGISTRATIONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {
                    //string insertquery = "Insert into REGISTRATION VALUES (:1, :2, :3, :4, :5, :6, :7,:8,:9,:10,:11,:12,:13)";
                    string Updatequery = "update REGISTRATION set GENDER=:gender,PHONE=:phone,ADDRESS=:address,TIMER=:time,DISEASE=:disease,STATUS=:status,PRICE=:price where PID=:pid";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Updatequery;
                    cmd.Parameters.Add(new OracleParameter("gender", OracleDbType.Varchar2, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("phone", OracleDbType.Varchar2, textBox5.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("address", OracleDbType.Varchar2, textBox6.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("disease", OracleDbType.Varchar2, textBox7.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("status", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("time", OracleDbType.Varchar2, textBox13.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("price", OracleDbType.Decimal, textBox12.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("pid", OracleDbType.Decimal, textBox1.Text, ParameterDirection.Input));

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientInformation pp = new PatientInformation();
            pp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier aa = new cashier();
            aa.Show();
        }

        private void rEGISTRATIONDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox10.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox11.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox12.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox13.Text = rEGISTRATIONDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {

                    string deletequery = "DELETE FROM WEAD WHERE ID=:id ";
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
            OracleConnection con = new OracleConnection(oradb);
            con.Open();
            OracleDataAdapter adebtar = new OracleDataAdapter("select * from REGISTRATION where NAME like '" + textBox8.Text + "%'", con);
            DataTable dt = new DataTable();
            adebtar.Fill(dt);
            rEGISTRATIONDataGridView.DataSource = dt;
            con.Close();
        }
    }
}
