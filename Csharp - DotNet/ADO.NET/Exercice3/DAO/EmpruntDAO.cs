using Azure.Core;
using Exercice3.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.DAO
{
    internal class EmpruntDAO : IBaseDAO<Emprunt>
    {
        protected string request = "";
        public bool DeleteAllEmpruntsOfABook(int id)
        {
            request = "DELETE FROM Emprunt WHERE livre_id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public bool DeleteAllEmpruntsOfAMember(int id)
        {
            request = "DELETE FROM Emprunt WHERE membre_id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public List<Emprunt> GetAllEmpruntsOfAMember(int id) 
        {
            List<Emprunt> emprunts = new();

            request = "SELECT id, livre_id, membre_id, date_emprunt, date_retour FROM emprunt WHERE membre_id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                emprunts.Add(new Emprunt(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4)));
            }

            return emprunts;
        }

        public Emprunt Save(Emprunt emprunt)
        {
            request = "INSERT INTO emprunt (livre_id, membre_id, date_emprunt)  OUTPUT INSERTED.ID VALUES (@livre_id, @membre_id, @date_emprunt);";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@membre_id", emprunt.MembreId);
            command.Parameters.AddWithValue("@livre_id", emprunt.LivreId);
            command.Parameters.AddWithValue("@date_emprunt", emprunt.DateEmprunt);

            connection.Open();

            emprunt.Id = (int)command.ExecuteScalar();

            return emprunt ;
        }

        public Emprunt Update(Emprunt emprunt)
        {
            request = "UPDATE emprunt SET date_retour=@date_retour WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", emprunt.Id);
            command.Parameters.AddWithValue("@date_retour", emprunt.DateEmprunt);

            connection.Open();

            command.ExecuteNonQuery();

            return emprunt;
        }

        public bool Retourner(int id)
        {
            request = "UPDATE emprunt SET date_retour=@date_retour WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@date_retour", DateTime.Now);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            request = "DELETE FROM Emprunt WHERE id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public Emprunt? GetById(int id)
        {
            Emprunt emprunt = new();

            request = "SELECT id, livre_id, membre_id, date_emprunt, date_retour FROM emprunt WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                emprunt = new Emprunt(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4));
            }

            return emprunt;
        }

        public List<Emprunt> GetAll(int? id = null)
        {
            List<Emprunt> emprunts = new();

            request = "SELECT id, livre_id, membre_id, date_emprunt, date_retour FROM emprunt;";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                emprunts.Add(new Emprunt(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4)));
            }

            return emprunts;
        }

        public List<Emprunt> GetEnCours(int? id = null)
        {
            List<Emprunt> emprunts = new();

            request = "SELECT id, livre_id, membre_id, date_emprunt FROM emprunt WHERE date_retour IS NULL;";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                emprunts.Add(new Emprunt(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3)));
            }

            return emprunts;
        }
    }
}
