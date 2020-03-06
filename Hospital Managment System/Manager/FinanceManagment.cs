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

namespace Hospital_Managment_System.Manager
{
    public partial class FinanceManagment : Form
    {
        public FinanceManagment()
        {
            InitializeComponent();
        }

        private void sTAFFBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sTAFFBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet3);

        }

        private void FinanceManagment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet3.STAFF' table. You can move, or remove it, as needed.
            this.sTAFFTableAdapter.Fill(this.dataSet3.STAFF);

        }

        private void sTAFFDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox6.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox5.Text = sTAFFDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
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

                    string Updatequery = "update STAFF set SALARY=:salary,SEX=:sex,ADDRESS=:address where ID=:id";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Updatequery;
                    cmd.Parameters.Add(new OracleParameter("salary", OracleDbType.Decimal, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("sex", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("address", OracleDbType.Varchar2, textBox5.Text, ParameterDirection.Input));
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
                OracleConnection con = new OracleConnection(oradb);
                con.Open();
                try
                {

                    string deletequery = "DELETE FROM STAFF WHERE ID=:id ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FinanceManagment ff = new FinanceManagment();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager mm = new manager();
            mm.Show();
        }

        private void FinanceManagment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=DESKTOP-DJC5B3N:1521/XE;PASSWORD=12345;USER ID=STUDENT";
            OracleConnection con = new OracleConnection(oradb);
            con.Open();
            OracleDataAdapter adebtar = new OracleDataAdapter("select * from STAFF where NAME like '" + textBox7.Text + "%'", con);
            DataTable dt = new DataTable();
            adebtar.Fill(dt);
            sTAFFDataGridView.DataSource = dt;
            con.Close();
        }
    }
}
