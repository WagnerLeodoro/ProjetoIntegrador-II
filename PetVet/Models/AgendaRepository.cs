using System.Collections.Generic;
using MySqlConnector;
namespace PetVet.Models
{
    public class AgendaRepository : Repository
    {
        public void CreateAgenda(Agenda a)
        {
            conn.Open();

            string sql = "INSERT INTO Agenda(Nome, TipoAnimal, TipoServico, Detalhes) VALUES (@Nome, @TipoAnimal, @TipoServico, @Detalhes)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nome", a.Nome);
            cmd.Parameters.AddWithValue("@TipoAnimal", a.TipoAnimal);
            cmd.Parameters.AddWithValue("@TipoServico", a.TipoServico);
            cmd.Parameters.AddWithValue("@Detalhes", a.Detalhes);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Agenda GetAgendaId(int id)
        {
            conn.Open();

            string sql = "SELECT * FROM Agenda WHERE Id = @Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            Agenda agenda = new Agenda();

            while (reader.Read())
            {
                agenda.Id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    agenda.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("TipoAnimal")))
                    agenda.TipoAnimal = reader.GetString("TipoAnimal");

                if (!reader.IsDBNull(reader.GetOrdinal("TipoServico")))
                    agenda.TipoServico = reader.GetString("TipoServico");

                if (!reader.IsDBNull(reader.GetOrdinal("Detalhes")))
                    agenda.Detalhes = reader.GetString("Detalhes");
            }

            conn.Close();
            return agenda;
        }
        public List<Agenda> Listar()
        {
            conn.Open();

            string sql = "SELECT * FROM Agenda";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Agenda> lista = new List<Agenda>();

            while (reader.Read())
            {
                Agenda agenda = new Agenda();
                agenda.Id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    agenda.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("TipoAnimal")))
                    agenda.TipoAnimal = reader.GetString("TipoAnimal");

                if (!reader.IsDBNull(reader.GetOrdinal("TipoServico")))
                    agenda.TipoServico = reader.GetString("TipoServico");

                if (!reader.IsDBNull(reader.GetOrdinal("Detalhes")))
                    agenda.Detalhes = reader.GetString("Detalhes");

                lista.Add(agenda);
            }

            conn.Close();
            return lista;
        }

        public void Atualizar(Agenda a)
        {
            conn.Open();

            string sql = "UPDATE Agenda SET Nome=@Nome, TipoAnimal=@TipoAnimal, TipoServico=@TipoServico, Detalhes=@Detalhes WHERE id=@Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nome", a.Nome);
            cmd.Parameters.AddWithValue("@TipoAnimal", a.TipoAnimal);
            cmd.Parameters.AddWithValue("@TipoServico", a.TipoServico);
            cmd.Parameters.AddWithValue("@Detalhes", a.Detalhes);
            cmd.Parameters.AddWithValue("@Id", a.Id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Remover(int id)
        {
            conn.Open();

            string sql = "DELETE FROM Agenda WHERE id=@Id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}