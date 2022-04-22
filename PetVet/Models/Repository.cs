using MySqlConnector;

namespace PetVet.Models
{
    public abstract class Repository
    {
        protected const string _strConexao = "DataBase=PetVet; DataSource=localhost;User Id=root;";
        protected MySqlConnection conn = new MySqlConnection(_strConexao);
    }
}