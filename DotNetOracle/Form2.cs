using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace DotNetOracle
{
    public partial class Form2 : Form
    {
        private static string CONNECTION_STRING = "Data Source=80.96.123.131/ora09;User Id=hr;Password=oracletest;";
        
        public Form2()
        {
            InitializeComponent();
            IncarcaMarci();
            IncarcaComb();
            IncarcaDisp();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void IncarcaMarci()
        {
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);

            try
            {
              
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ID_marca, marca from marcisi";
                cmd.CommandType = CommandType.Text;

          
                OracleDataReader dr = cmd.ExecuteReader();

               
                while (dr.Read())
                {
                    cmbMarca.Items.Add(new ComboItem(dr.GetString(1), (Int32)dr.GetDecimal(0)));
                }

        
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

        }


        private void IncarcaComb()
        {
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);

            try
            {
               
                conn.Open();

               
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ID_combustibil, combustibil from combustibilisi";
                cmd.CommandType = CommandType.Text;

                
                OracleDataReader dr = cmd.ExecuteReader();

                
                while (dr.Read())
                {
                    cmbComb.Items.Add(new ComboItem(dr.GetString(1), (Int32)dr.GetDecimal(0)));
                }

              
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

        }


        private void IncarcaDisp()
        {
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);

            try
            {

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ID_disp, disp from disponibilitatesi";
                cmd.CommandType = CommandType.Text;

   
                OracleDataReader dr = cmd.ExecuteReader();

    
                while (dr.Read())
                {
                    cmbDisp.Items.Add(new ComboItem(dr.GetString(1), (Int32)dr.GetDecimal(0)));
                }

            
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

        }
        

        private void btnAdaugaMasina_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

               
                conn.Open();

              
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "insert into MasiniSI2 values ";
                 sqlCommand += "( seq_mas.nextval , '" + txtNr_inm.Text + "'," +((ComboItem)cmbMarca.SelectedItem).Value + ",'" + txtModel.Text + "'," + int.Parse(txtAn.Text) + ",'" + txtCuloare.Text + "'," + ((ComboItem)cmbComb.SelectedItem).Value + "," + ((ComboItem)cmbDisp.SelectedItem).Value + ")";
            

                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Adaugat");
                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie " + ex.Message);
            }
        }
		
		
		

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

		
        private void btnAdaugaClient_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

              
                conn.Open();

              
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "INSERT INTO ClientiSI VALUES (seq_cli.nextval, ";
                sqlCommand += "'" + txtNumeC.Text + "','" + txtPrenumeC.Text + "','" + txtAdresaC.Text + "','" +  txtTelefonC.Text + "')";
            

                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Adaugat");

                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

        }

        private void cmbCompanii_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

              
                conn.Open();

               
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "INSERT INTO AngajatiSI VALUES (seq_ang.nextval, ";
                sqlCommand += "'" + txtNumeA.Text + "','" + txtPrenumeA.Text + "','" + txtAdresaA.Text + "','" + txtTelefonA.Text + "', " + int.Parse(txtSalariu.Text) + ",'" + txtEmail.Text +   "')";


                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Adaugat");

                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }


    }
}
