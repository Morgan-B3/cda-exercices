using Azure.Core;
using Exercice3.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.DAO
{
    internal class LivreDAO : IBaseDAO<Livre>
    {
        protected string request = "";
        public bool Delete(int id)
        {
            EmpruntDAO empruntDAO = new EmpruntDAO();
            empruntDAO.DeleteAllEmpruntsOfABook(id);

            request = "DELETE FROM Livre WHERE id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id",id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public List<Livre> GetAll(int? id = null)
        {
            List<Livre> livres = new();

            request = "SELECT id, titre, auteur, isbn, annee_publication, est_disponible FROM Livre;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                livres.Add(
                    new Livre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetBoolean(5)));
            }

            return livres;
        }

        public Livre? GetById(int id)
        {
            Livre? livre = null;

            request = "SELECT id, titre, auteur, isbn, annee_publication, est_disponible FROM Livre WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                livre = new Livre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetBoolean(5));
            }

            return livre;
        }

        public List<Livre>? GetByAuteur(string auteur)
        {
            List<Livre>? livres = new();

            request = "SELECT id, titre, auteur, isbn, annee_publication, est_disponible FROM Livre WHERE auteur LIKE @auteur;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@auteur", "%" + auteur + "%");

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                livres.Add(new Livre(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetBoolean(5)));
            }

            return livres;
        }

        public Livre Save(Livre livre)
        {
            request = "INSERT INTO livre (titre, auteur, isbn, annee_publication, est_disponible) OUTPUT INSERTED.ID VALUES (@titre, @auteur, @isbn, @annee_publication, @est_disponible);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@titre", livre.Titre);
            command.Parameters.AddWithValue("@auteur", livre.Auteur);
            command.Parameters.AddWithValue("@isbn", livre.Isbn);
            command.Parameters.AddWithValue("@annee_publication", livre.AnneePublication);
            command.Parameters.AddWithValue("@est_disponible", livre.EstDisponible);

            connection.Open();

            livre.Id = (int)command.ExecuteScalar();

            return livre;
        }

        public Livre Update(Livre livre)
        {
            request = "UPDATE livre SET titre=@titre, auteur=@auteur, isbn=@isbn, annee_publication=@annee_publication, est_disponible=@est_disponible WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", livre.Id);
            command.Parameters.AddWithValue("@titre", livre.Titre);
            command.Parameters.AddWithValue("@auteur", livre.Auteur);
            command.Parameters.AddWithValue("@isbn", livre.Isbn);
            command.Parameters.AddWithValue("@annee_publication", livre.AnneePublication);
            command.Parameters.AddWithValue("@est_disponible", livre.EstDisponible);

            connection.Open();

            command.ExecuteNonQuery();

            return livre;
        }
    }
}
