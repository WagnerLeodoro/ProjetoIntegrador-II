using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MySqlConnector;

namespace PetVet.Models
{
    public class UsuarioRepository : Repository
    {
        public void Create(Usuario u)
        {
            conn.Open();

            string sql = "INSERT INTO Usuarios(Nome, DataNasc, Endereco, Email, Telefone, Login, Senha) VALUES (@Nome, @DataNasc, @Endereco, @Email, @Telefone, @Login, @Senha) ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nome", u.Nome);
            cmd.Parameters.AddWithValue("@DataNasc", u.DataNasc);
            cmd.Parameters.AddWithValue("@Endereco", u.Endereco);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@Telefone", u.Telefone);
            cmd.Parameters.AddWithValue("@Login", u.Login);
            cmd.Parameters.AddWithValue("@Senha", u.Senha);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Usuario UserId(int id)
        {
            conn.Open();

            string sql = "SELECT * FROM Usuarios WHERE Id = @Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario user = new Usuario();

            while (reader.Read())
            {
                user.Id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    user.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("DataNasc")))
                    user.DataNasc = reader.GetDateTime("DataNasc");

                if (!reader.IsDBNull(reader.GetOrdinal("Endereco")))
                    user.Endereco = reader.GetString("Endereco");

                if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                    user.Email = reader.GetString("Email");

                if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                    user.Telefone = reader.GetString("Telefone");

                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    user.Login = reader.GetString("Login");

                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    user.Senha = reader.GetString("Senha");
            }

            conn.Close();
            return user;
        }
        public List<Usuario> Listar()
        {
            conn.Open();

            string sql = "SELECT * FROM Usuarios";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Usuario> lista = new List<Usuario>();

            while (reader.Read())
            {
                Usuario user = new Usuario();
                user.Id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    user.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("DataNasc")))
                    user.DataNasc = reader.GetDateTime("DataNasc");

                if (!reader.IsDBNull(reader.GetOrdinal("Endereco")))
                    user.Endereco = reader.GetString("Endereco");

                if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                    user.Email = reader.GetString("Email");

                if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                    user.Telefone = reader.GetString("Telefone");

                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    user.Login = reader.GetString("Login");

                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    user.Senha = reader.GetString("Senha");

                lista.Add(user);
            }

            conn.Close();
            return lista;
        }

        public void Atualizar(Usuario u)
        {
            conn.Open();

            string sql = "UPDATE Usuarios SET Nome=@Nome, DataNasc=@DataNasc, Endereco=@Endereco, Email=@Email, Telefone=@Telefone, Login=@Login, Senha=@Senha WHERE id=@Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nome", u.Nome);
            cmd.Parameters.AddWithValue("@DataNasc", u.DataNasc);
            cmd.Parameters.AddWithValue("@Endereco", u.Endereco);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@Telefone", u.Telefone);
            cmd.Parameters.AddWithValue("@Login", u.Login);
            cmd.Parameters.AddWithValue("@Senha", u.Senha);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Remover(int id)
        {
            conn.Open();

            string sql = "DELETE FROM Usuarios WHERE id=@Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Usuario QueryLogin(Usuario u)
        {
            conn.Open();

            string sql = "SELECT * FROM Usuarios WHERE Login=@Login AND Senha=@Senha";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Login", u.Login);
            cmd.Parameters.AddWithValue("@Senha", u.Senha);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario user = null;

            if (reader.Read())
            {
                user = new Usuario();
                user.Id = reader.GetInt32("Id");

                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    user.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    user.Login = reader.GetString("Login");

                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    user.Senha = reader.GetString("Senha");
            }
            conn.Close();
            return user;
        }
    }
}