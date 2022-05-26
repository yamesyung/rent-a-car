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
    public partial class Form1 : Form
    {
        private static string CONNECTION_STRING = "Data Source=80.96.123.131/ora09;User Id=hr;Password=oracletest;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMasini();
            IncarcaMarci();
            IncarcaComb();
            IncarcaDisp();

        }


        private void AfiseazaMasini()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {

                    conn.Open();
                    string sqlCommand = "select * from masiniview";

                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {

                        DataTable dt = new DataTable();
                        oda.Fill(dt);
                        

                        dataGridView1.DataSource = dt;
                    }

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].HeaderText = "Marca";
                    dataGridView1.Columns[4].HeaderText = "Model";
                    dataGridView1.Columns[5].HeaderText = "An";
                    dataGridView1.Columns[6].HeaderText = "Culoare";
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Culoare";
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].HeaderText = "Disponibila";

                }
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

		 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
            string idMasina = dataGridView1[0, currentRowIndex].Value.ToString();
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);

            try
            {
               
                conn.Open();

               
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from masiniview where ID_masina= "+ idMasina;
                cmd.CommandType = CommandType.Text;

               
                OracleDataReader dr = cmd.ExecuteReader();

               
                if (dr.Read())
                {
                    lblIdMasina.Text = dr.GetInt32(0).ToString(); 
                    txtNr_inm.Text = dr.GetString(1);
                  cmbMarca.SelectedItem = new ComboItem(dr.GetString(3), (Int32)dr.GetDecimal(2));
                    txtModel.Text = dr.GetString(4);
                   txtAn.Text = dr.GetInt32(5).ToString();
                   txtCuloare.Text = dr.GetString(6);
                    cmbComb.SelectedItem = new ComboItem(dr.GetString(8), (Int32)dr.GetDecimal(7));
                   cmbDisp.SelectedItem = new ComboItem(dr.GetString(10), (Int32)dr.GetDecimal(9));

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
            groupBox1.Visible = true;
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

       
        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);
            
               
                conn.Open();

                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "UPDATE MasiniSI2 SET Nr_inmatriculare  = '" + txtNr_inm.Text + "'";

                sqlCommand += ", id_marca = " + ((ComboItem)cmbMarca.SelectedItem).Value;
                sqlCommand += ", Model ='" + txtModel.Text + "'";
                sqlCommand += ", An_fabricatie =" + int.Parse(txtAn.Text);
                sqlCommand += ", Culoare ='" + txtCuloare.Text + "'";
                sqlCommand += ", ID_combustibil = " + ((ComboItem)cmbComb.SelectedItem).Value;
                sqlCommand += ", ID_Disp = " + ((ComboItem)cmbDisp.SelectedItem).Value;
                sqlCommand += " where ID_masina= '" + lblIdMasina.Text +"'";

                cmd.CommandText = sqlCommand;
                
                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Date actualizate");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
            AfiseazaMasini();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

                if (MessageBox.Show("Doresti sa stergi inregistrarea?", "My Application",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {

                    String sqlCommand = "DELETE FROM MasiniSI2  where ID_masina= '" + lblIdMasina.Text + "'";

                    cmd.CommandText = sqlCommand;
                }
                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Inregistrarea a fost stearsa");
                }
                else
                {
                    MessageBox.Show("Error");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
            AfiseazaMasini();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }


    }
}
