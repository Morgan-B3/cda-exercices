using Azure.Core;
using Exercice3.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.DAO
{
    internal class MembreDAO : IBaseDAO<Membre>
    {
        protected string request = "";
        public bool Delete(int id)
        {
            EmpruntDAO empruntDAO = new EmpruntDAO();
            empruntDAO.DeleteAllEmpruntsOfAMember(id);

            request = "DELETE FROM Membre WHERE id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public List<Membre> GetAll(int? id = null)
        {
            List<Membre> membres = new();

            request = "SELECT id, nom, prenom, email, date_inscription FROM Membre;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                membres.Add(
                    new Membre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4))
                 );
            }

            return membres;
        }

        public Membre? GetById(int id)
        {
            Membre? membre = null;

            request = "SELECT id, nom, prenom, email, date_inscription FROM Membre WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                List<Emprunt> emprunts = new EmpruntDAO().GetAllEmpruntsOfAMember(id);
                membre = new Membre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    emprunts
                 );
            }

            return membre;
        }

        public List<Membre> GetByEmail(string email)
        {
            List<Membre> membres = new();

            request = "SELECT id, nom, prenom, email, date_inscription FROM Membre WHERE email LIKE @email;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@email", "%"+email+"%");

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                membres.Add(
                    new Membre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4))
                 );
            }

            return membres;
        }


        public Membre Save(Membre membre)
        {
            request = "INSERT INTO membre (nom, prenom, email, date_inscription) OUTPUT INSERTED.ID VALUES (@nom, @prenom, @email, @date_inscription);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@nom", membre.Nom);
            command.Parameters.AddWithValue("@prenom", membre.Prenom);
            command.Parameters.AddWithValue("@email", membre.Email);
            command.Parameters.AddWithValue("@date_inscription", membre.DateInscription);

            connection.Open();

            membre.Id = (int)command.ExecuteScalar();

            return membre;
        }

        public Membre Update(Membre membre)
        {
            request = "UPDATE membre SET nom=@nom, prenom=@prenom, email=@email, date_inscription=@date_inscription) WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", membre.Id);
            command.Parameters.AddWithValue("@nom", membre.Nom);
            command.Parameters.AddWithValue("@prenom", membre.Prenom);
            command.Parameters.AddWithValue("@email", membre.Email);
            command.Parameters.AddWithValue("@date_inscription", membre.DateInscription);

            connection.Open();

            membre.Id = (int)command.ExecuteScalar();

            return membre;
        }
    }
}
