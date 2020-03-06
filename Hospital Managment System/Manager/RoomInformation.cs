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
    public partial class RoomInformation : Form
    {
        public RoomInformation()
        {
            InitializeComponent();
        }

        private void wEADBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wEADBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);

        }

        private void RoomInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.WEAD' table. You can move, or remove it, as needed.
            this.wEADTableAdapter.Fill(this.dataSet2.WEAD);

        }

        private void RoomInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

                    string Updatequery = "update WEAD set NUMBEROFBED=:numberofbed,UNITPRICE=:unitprice,STATUS=:status where ID=:id";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Updatequery;
                    cmd.Parameters.Add(new OracleParameter("numberofbed", OracleDbType.Decimal, textBox2.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("unitprice", OracleDbType.Decimal, textBox3.Text, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("status", OracleDbType.Varchar2, comboBox1.Text, ParameterDirection.Input));
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomInformation rr = new RoomInformation();
            rr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager mm = new manager();
            mm.Show();
        }

        private void wEADDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = wEADDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = wEADDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = wEADDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = wEADDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox7.Text = wEADDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = wEADDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = wEADDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox1.Text = wEADDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
    }
}
