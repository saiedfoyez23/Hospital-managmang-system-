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
namespace Hospital_Managment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
                    string seletequery = "SELECT * FROM USER_INFO" + " WHERE NAME ='" + textBox1.Text + "'"+ " AND PASSWORD = '" + textBox2.Text + "'";
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = seletequery;
                    //cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Varchar2, textBox1.Text, ParameterDirection.Input));
                    //cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, textBox2.Text, ParameterDirection.Input));

                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr["POSITION"].ToString() == "Admin")
                    {
                        this.Hide();
                        admin aa = new admin();
                        aa.Show();
                    }
                    else if (dr["POSITION"].ToString() == "Manager" || dr["POSITION"].ToString() == "Femanager")
                    {
                        this.Hide();
                        manager mm = new manager();
                        mm.Show();
                    }
                    else if (dr["POSITION"].ToString() == "Cashier")
                    {
                        this.Hide();
                        cashier cc = new cashier();
                        cc.Show();
                    }



                    con.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Username and password in wrong");
                }
                //cmd.ExecuteNonQuery();


               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
           
            /*if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                this.Hide();
                admin aa = new admin();
                aa.Show();
            }
            else if (textBox1.Text == "manager" && textBox2.Text == "456")
            {
                this.Hide();
                manager mm = new manager();
                mm.Show();
            }
            else if (textBox1.Text == "cashier" && textBox2.Text == "789")
            {
                this.Hide();
                cashier cc = new cashier();
                cc.Show();
            }
            else
            {
                label3.ForeColor.Equals("red");
                label3.Text.Equals("invalid username or password");
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
