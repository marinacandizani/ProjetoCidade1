using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ProjetoCidade1.Models;
using ProjetoCidade1.Models;
using System.Configuration;
using System.Data;
namespace ProjetoCidade1.Repositório
{
    public class ProdutoRepositório(IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        public void CadastrarProduto(Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {

                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Produto (Nome, Descricao, Preco, Quantidade) values (@nome, @descricao, @preco, @quantidade)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;

                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;

                cmd.Parameters.Add("@Preco", MySqlDbType.Double).Value = produto.Preco;

                cmd.Parameters.Add("@Preco", MySqlDbType.Int64).Value = produto.Quantidade;

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        public bool EditarProduto(Produto produto)
        {
            try
            {

                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {

                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand("Update Produto set Nome=@nome, Descricao=@descricao, Preco=@preco, Quantidade=@quantidade" + " where Id=@id ", conexao);


                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = produto.Nome;

                    cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;

                    cmd.Parameters.Add("@Preco", MySqlDbType.Double).Value = produto.Preco;

                    cmd.Parameters.Add("@Quantidade", MySqlDbType.Int64).Value = produto.Quantidade;




                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;

                }
            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
                return false;

            }
        }

        public void ExcluirProduto(int Id)
        {

            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {

                conexao.Open();


                MySqlCommand cmd = new MySqlCommand("delete from Produto where Id=@id", conexao);


                cmd.Parameters.AddWithValue("@id", Id);


                int i = cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }
    }
}
