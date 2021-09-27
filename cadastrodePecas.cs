
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace projeto_integrador
{
    public partial class cadastrodePecas : Form
    {
        public cadastrodePecas()
        {
            InitializeComponent();
        }

        private MySqlBaseConnectionStringBuilder conexaobanco()
        {
            MySqlBaseConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "estoquep";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;

            return conexaoBD;

        }




        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparcampos();

        }

        private void limparcampos()
        {
            txtpartnunber.Clear();
            txtnome.Clear();
            txtdescricao.Clear();
            mtbdata.Clear();


        }


        private void cadastroDePeçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastrodePecas cadastro = new cadastrodePecas();
            cadastro.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cadastrodePecas_Load(object sender, EventArgs e)
        {
            atualizarDataGrid();

        }

        private void atualizarDataGrid()
        {
            MySqlBaseConnectionStringBuilder conexaoBD = conexaobanco();
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();

                MySqlCommand comandoMysql = realizaconexaoBD.CreateCommand();
                comandoMysql.CommandText = "SELECT * FROM peca";
                MySqlDataReader reader = comandoMysql.ExecuteReader();

                dgpeca.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow Row = (DataGridViewRow)dgpeca.Rows[0].Clone();
                    Row.Cells[0].Value = reader.GetString(0);
                    Row.Cells[1].Value = reader.GetString(1);
                    Row.Cells[2].Value = reader.GetString(2);
                    Row.Cells[3].Value = reader.GetString(3);
                    Row.Cells[4].Value = reader.GetString(4);
                    dgpeca.Rows.Add(Row);
                }

                realizaconexaoBD.Close();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant not open conection !");
                Console.WriteLine(ex.Message);

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MySqlBaseConnectionStringBuilder conexaoBD = conexaobanco();
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();

                MySqlCommand comandoMysql = realizaconexaoBD.CreateCommand();        
                comandoMysql.CommandText = "INSERT INTO peca VALUES(0, '"+txtnome.Text+"', '"+txtdescricao.Text+"','"+mtbdata.Text+ "',' + mcbpeca.Text + ')";
                MySqlDataReader reader = comandoMysql.ExecuteReader();

                dgpeca.Rows.Clear();
                realizaconexaoBD.Close();
                MessageBox.Show("iserido com sucesso!");
                atualizarDataGrid();

                while (reader.Read())
                {
                    DataGridViewRow Row = (DataGridViewRow)dgpeca.Rows[0].Clone();
                    Row.Cells[0].Value = reader.GetString(0);
                    Row.Cells[1].Value = reader.GetString(1);
                    Row.Cells[2].Value = reader.GetString(2);
                    Row.Cells[3].Value = reader.GetString(3);
                    Row.Cells[4].Value = reader.GetString(4);
                    dgpeca.Rows.Add(Row);
                }


               
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }
    
        }  
    }



