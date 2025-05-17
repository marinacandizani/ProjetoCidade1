using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ProjetoCidade1.Models;
using ProjetoCidade1.Models;
using System.Configuration;
using System.Data;
namespace ProjetoCidade1.Repositório
{
    public class LoginRepositório(IConfiguration configuration)
    {

        private readonly string _conexaoMySQL = configuration.GetConnectionString("conexaoMySQL");

        public Usuário ObterUsuario(string email)
        {

            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {

                conexao.Open();

                MySqlCommand cmd = new("SELECT * FROM Usuario WHERE Email = @email", conexao);

                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;



                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    Usuário usuario = null;

                    if (dr.Read())
                    {

                        usuario = new Usuário
                        {

                            Id = Convert.ToInt32(dr["Id"]),

                            Nome = dr["Nome"].ToString(),

                            Email = dr["Email"].ToString(),

                            Senha = dr["Senha"].ToString()
                        };
                    }

                    return usuario;
                }
            }
        }


    }
}
