using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvaliacaoOctoTI {
    public partial class CadastroCliente : Form {
        public CadastroCliente() {
            InitializeComponent();
        
            txt_nome.Enabled = false;
            txt_address.Enabled = false;
            txt_address_num.Enabled = false;
            txt_address_bairro.Enabled = false;
            txt_tel.Enabled = false;
            txt_cel.Enabled = false;
            txt_comercial.Enabled = false;
            txt_cpf_cnpj.Enabled = false;
            txt_email.Enabled = false;
            txt_nome.Enabled = false;
            btn_save.Enabled = false;
            btn_del.Enabled = false;
            btn_edit.Enabled = false;
        }

        SqlConnection sqlCon = null;
        private string _strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OctoTI;Data Source=GASPAR-PC\SQLEXPRESS";
        private string _strSql = string.Empty;

        private void cadastrarClienteToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void label8_Click(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }

        private void CadastroCliente_Load(object sender, EventArgs e) {

        }

        private void btn_add_Click(object sender, EventArgs e) {
            txt_nome.Enabled = true;
            txt_address.Enabled = true;
            txt_address_num.Enabled = true;
            txt_address_bairro.Enabled = true;
            txt_tel.Enabled = true;
            txt_cel.Enabled = true;
            txt_comercial.Enabled = true;
            txt_cpf_cnpj.Enabled = true;
            txt_email.Enabled = true;
            txt_nome.Enabled = true;
            btn_save.Enabled = true;
            btn_del.Enabled = true;
            btn_edit.Enabled = true;
        }

        private void btn_save_Click(object sender, EventArgs e) {
            _strSql = "insert into DadosClientes (Nome, Telefone, Celular, Comercial, Email, Endereco, Numero, Bairro, CPF_CNPJ) " +
                "values(@Nome, @Telefone, @Celular, @Comercial, @Email, @Endereco, @Numero, @Bairro, @CPF_CNPJ)";
            sqlCon = new SqlConnection(_strCon);
            SqlCommand comando = new SqlCommand(_strSql, sqlCon);
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txt_tel.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txt_cel.Text;
            comando.Parameters.Add("@Comercial", SqlDbType.VarChar).Value = txt_comercial.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txt_address.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txt_address_num.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_address_bairro.Text;
            comando.Parameters.Add("@CPF_CNPJ", SqlDbType.VarChar).Value = txt_cpf_cnpj.Text;

            try {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Efetuado com Sucesso!");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlCon.Close();
            }

            txt_search.Enabled = true;

            txt_nome.Clear();
            txt_address.Clear();
            txt_address_num.Clear();
            txt_address_bairro.Clear();
            txt_tel.Clear();
            txt_cel.Clear();
            txt_comercial.Clear();
            txt_cpf_cnpj.Clear();
            txt_email.Clear();
            txt_nome.Clear();
            txt_nome.Enabled = false;
            txt_address.Enabled = false;
            txt_address_num.Enabled = false;
            txt_address_bairro.Enabled = false;
            txt_tel.Enabled = false;
            txt_cel.Enabled = false;
            txt_comercial.Enabled = false;
            txt_cpf_cnpj.Enabled = false;
            txt_email.Enabled = false;
            txt_nome.Enabled = false;
            btn_save.Enabled = false;
            btn_del.Enabled = false;
            btn_edit.Enabled = false;
        }

        private void btn_search_Click(object sender, EventArgs e) {
            _strSql = "select * from DadosClientes where Nome = @pesquisa";
            sqlCon = new SqlConnection(_strCon);
            SqlCommand comando = new SqlCommand(_strSql, sqlCon);
            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txt_search.Text;

            try {
                if(txt_search.Text == string.Empty) {
                    MessageBox.Show("Digite um nome!");
                }
                
                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if(dr.HasRows == false) {
                    throw new Exception("Este nome não está cadastrado!");
                }

                dr.Read();

                txt_nome.Text = Convert.ToString(dr["Nome"]);
                txt_tel.Text = Convert.ToString(dr["Telefone"]);
                txt_cel.Text = Convert.ToString(dr["Celular"]);
                txt_comercial.Text = Convert.ToString(dr["Comercial"]);
                txt_email.Text = Convert.ToString(dr["Email"]);
                txt_address.Text = Convert.ToString(dr["Endereco"]);
                txt_address_num.Text = Convert.ToString(dr["Numero"]);
                txt_address_bairro.Text = Convert.ToString(dr["Bairro"]);
                txt_cpf_cnpj.Text = Convert.ToString(dr["CPF_CNPJ"]);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlCon.Close();
            }
            txt_search.Clear();
            txt_nome.Enabled = true;
            txt_address.Enabled = true;
            txt_address_num.Enabled = true;
            txt_address_bairro.Enabled = true;
            txt_tel.Enabled = true;
            txt_cel.Enabled = true;
            txt_comercial.Enabled = true;
            txt_cpf_cnpj.Enabled = true;
            txt_email.Enabled = true;
            txt_nome.Enabled = true;
            btn_save.Enabled = true;
            btn_del.Enabled = true;
            btn_edit.Enabled = true;
        }

        private void btn_edit_Click(object sender, EventArgs e) {
            _strSql = "update DadosClientes set Nome=@Nome, Telefone=@Telefone, Celular=@Celular," +
                "Comercial=@Comercial, Email=@Email, Endereco=@Endereco, Numero=@Numero, Bairro=@Bairro, CPF_CNPJ=@CPF_CNPJ";
            sqlCon = new SqlConnection(_strCon);
            SqlCommand comando = new SqlCommand(_strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txt_tel.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txt_cel.Text;
            comando.Parameters.Add("@Comercial", SqlDbType.VarChar).Value = txt_comercial.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txt_address.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txt_address_num.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_address_bairro.Text;
            comando.Parameters.Add("@CPF_CNPJ", SqlDbType.VarChar).Value = txt_cpf_cnpj.Text;

            try {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Atualizado com Sucesso!");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlCon.Close();
            }
            txt_nome.Clear();
            txt_address.Clear();
            txt_address_num.Clear();
            txt_address_bairro.Clear();
            txt_tel.Clear();
            txt_cel.Clear();
            txt_comercial.Clear();
            txt_cpf_cnpj.Clear();
            txt_email.Clear();
            txt_nome.Clear();
            txt_nome.Enabled = false;
            txt_address.Enabled = false;
            txt_address_num.Enabled = false;
            txt_address_bairro.Enabled = false;
            txt_tel.Enabled = false;
            txt_cel.Enabled = false;
            txt_comercial.Enabled = false;
            txt_cpf_cnpj.Enabled = false;
            txt_email.Enabled = false;
            txt_nome.Enabled = false;
            btn_save.Enabled = false;
            btn_del.Enabled = false;
            btn_edit.Enabled = false;
        }

        private void btn_del_Click(object sender, EventArgs e) {
            _strSql = "delete * from DadosClientes where Nome = @Nome";
            sqlCon = new SqlConnection(_strCon);
            SqlCommand comando = new SqlCommand(_strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;

            try {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Excluído com Sucesso!");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlCon.Close();
            }
            txt_nome.Clear();
            txt_address.Clear();
            txt_address_num.Clear();
            txt_address_bairro.Clear();
            txt_tel.Clear();
            txt_cel.Clear();
            txt_comercial.Clear();
            txt_cpf_cnpj.Clear();
            txt_email.Clear();
            txt_nome.Clear();
            txt_nome.Enabled = false;
            txt_address.Enabled = false;
            txt_address_num.Enabled = false;
            txt_address_bairro.Enabled = false;
            txt_tel.Enabled = false;
            txt_cel.Enabled = false;
            txt_comercial.Enabled = false;
            txt_cpf_cnpj.Enabled = false;
            txt_email.Enabled = false;
            txt_nome.Enabled = false;
            btn_save.Enabled = false;
            btn_del.Enabled = false;
            btn_edit.Enabled = false;
        }

        private void btn_hundred_Click(object sender, EventArgs e) {
            _strSql = "insert into DadosClientes (Nome, Telefone, Celular, Comercial, Email, Endereco, Numero, Bairro, CPF_CNPJ) " +
                "values(@Nome, @Telefone, @Celular, @Comercial, @Email, @Endereco, @Numero, @Bairro, @CPF_CNPJ)";
            sqlCon = new SqlConnection(_strCon);
            SqlCommand comando = new SqlCommand(_strSql, sqlCon);
            for(int i = 0; i < 100; i++) {
                comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = $"Teste{i}";
                comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = "981998174";
                comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = "984981732";
                comando.Parameters.Add("@Comercial", SqlDbType.VarChar).Value = "73589512";
                comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = $"teste{i}@gmail.com";
                comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = "Rua Alameda";
                comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = i.ToString();
                comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = "Jardim planalto";
                comando.Parameters.Add("@CPF_CNPJ", SqlDbType.VarChar).Value = $"Teste{i}";

                try {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com Sucesso!");
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    sqlCon.Close();
                }
            }
        }
    }
}
