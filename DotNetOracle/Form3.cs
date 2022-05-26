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
    public partial class Form3 : Form
    {
  

        private static string CONNECTION_STRING = "Data Source=80.96.123.131/ora09;User Id=hr;Password=oracletest;";
        public Form3()
        {
            InitializeComponent();
        }

        private void AfiseazaContracte()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    
                    conn.Open();
                    string sqlCommand = "select * from Contracteview";

                   
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                       
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                        
                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Angajat";
                    dataGridView1.Columns[2].HeaderText = "Client";
                    dataGridView1.Columns[3].HeaderText = "Masina";
                    dataGridView1.Columns[4].HeaderText = "Data start";
                    dataGridView1.Columns[5].HeaderText = "Data sfarsit";
                    dataGridView1.Columns[6].HeaderText = "Pret";


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


        private void AfiseazaAngajati()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                   
                    conn.Open();
                    string sqlCommand = "select * from AngajatiSI";

                   
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                       
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                        
                        dataGridView1.DataSource = dt;
                    }

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Nume";
                    dataGridView1.Columns[2].HeaderText = "Prenume";
                    dataGridView1.Columns[3].HeaderText = "Adresa";
                    dataGridView1.Columns[4].HeaderText = "Telefon";
                    dataGridView1.Columns[5].HeaderText = "Salariu";
                    dataGridView1.Columns[6].HeaderText = "Email";


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



        private void AfiseazaClienti()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    
                    conn.Open();
                    string sqlCommand = "select * from ClientiSI";

                    
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                       
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                       
                        dataGridView1.DataSource = dt;
                    }

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Nume";
                    dataGridView1.Columns[2].HeaderText = "Prenume";
                    dataGridView1.Columns[3].HeaderText = "Adresa";
                    dataGridView1.Columns[4].HeaderText = "Telefon";



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

        private void AfiseazaCI()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    
                    conn.Open();
                    string sqlCommand = "select angajat, count (*) contracte_incheiate,sum(pret) profit, round(avg(pret)) profit_mediu from contracteview group by angajat";

                   
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                       
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                       
                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].HeaderText = "Nume angajat";
                    dataGridView1.Columns[1].HeaderText = "Contracte incheiate";
                    dataGridView1.Columns[2].HeaderText = "Profit";
                    dataGridView1.Columns[3].HeaderText = "Profit mediu";

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


        private void AfiseazaPM()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    
                    conn.Open();
                    string sqlCommand = "select masina, count (*) popularitate  from contracteview group by masina";

                    
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                        
                        DataTable dt = new DataTable();
                        oda.Fill(dt);
         
                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].HeaderText = "Masina";
                    dataGridView1.Columns[1].HeaderText = "Nr. inchirieri";


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


        private void AfiseazaPPA()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                   
                    conn.Open();
                    string sqlCommand = "select SUM( pret ),round(avg(pret)) from contractesi where to_char (data_start, 'yyyy') = " + txtAn.Text;

                   
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                      
                        DataTable dt = new DataTable();
                        oda.Fill(dt);
 
                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].HeaderText = "Profit";
                    dataGridView1.Columns[1].HeaderText = "Profit mediu";

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


        private void AfiseazaCID()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                   
                    conn.Open();
                    string sqlCommand = "select * from contracteview where id_contract = (select id_contract from contractesi where data_sfarsit >= TRUNC(SYSDATE)) ";

                   
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                        
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Angajat";
                    dataGridView1.Columns[2].HeaderText = "Client";
                    dataGridView1.Columns[3].HeaderText = "Masina";
                    dataGridView1.Columns[4].HeaderText = "Data start";
                    dataGridView1.Columns[5].HeaderText = "Data sfarsit";
                    dataGridView1.Columns[6].HeaderText = "Pret";
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


        private void AfiseazaClientNume()
        {
            OracleConnection conn = new OracleConnection();
            try
            {
                using (conn = new OracleConnection(CONNECTION_STRING))
                {
                    
                    conn.Open();
                    string sqlCommand = "select * from clientisi where nume LIKE '%" + txtClient.Text + "%' or prenume like '%" + txtClient.Text + "%' ";

                  
                    using (OracleDataAdapter oda = new OracleDataAdapter(sqlCommand, conn))
                    {
                        
                        DataTable dt = new DataTable();
                        oda.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[1].HeaderText = "idClient";
                    dataGridView1.Columns[1].HeaderText = "Nume";
                    dataGridView1.Columns[2].HeaderText = "Prenume";
                    dataGridView1.Columns[3].HeaderText = "Adresa";
                    dataGridView1.Columns[4].HeaderText = "Telefon";

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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AfiseazaContracte();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AfiseazaAngajati();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AfiseazaPPA();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AfiseazaCI();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AfiseazaCID();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AfiseazaPM();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AfiseazaClientNume();
        }





    }
}
