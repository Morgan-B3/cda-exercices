using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercice1.Classes
{
    internal class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClassNumber { get; set; }
        public DateTime DateDiploma { get; set; }

        public static string connectionString = "Data Source=(localdb)\\CoursSQL;Initial Catalog=CoursSQL;Integrated Security=True";

        public User() { }

        public User(string firstName, string lastName, int classNumber, DateTime dateDiploma)
        {
            FirstName = firstName;
            LastName = lastName;
            ClassNumber = classNumber;
            DateDiploma = dateDiploma;
        }

        public bool Save()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Utilisateur (nom, prenom, numero_classe, date_diplome) VALUES (@Nom, @Prenom, @Numero, @Date)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Prenom", FirstName);
            cmd.Parameters.AddWithValue("@Nom", LastName);
            cmd.Parameters.AddWithValue("@Numero", ClassNumber);
            cmd.Parameters.AddWithValue("@Date", DateDiploma);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM Utilisateur WHERE id = @id";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool EditUser(int id, User user)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string request = "UPDATE Utilisateur SET prenom = @prenom, nom = @nom, numero_classe = @numero, date_diplome = @date WHERE id=@id;";

            SqlCommand cmd = new SqlCommand(request, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@prenom", user.FirstName);
            cmd.Parameters.AddWithValue("@nom", user.LastName);
            cmd.Parameters.AddWithValue("@numero", user.ClassNumber);
            cmd.Parameters.AddWithValue("@date", user.DateDiploma);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static User GetById(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM Utilisateur WHERE id = @id";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = (int)reader["id"],
                    FirstName = reader["prenom"].ToString(),
                    LastName = reader["nom"].ToString(),
                    ClassNumber = (int)reader["numero_classe"],
                    DateDiploma = (DateTime)reader["date_diplome"]
                };
            }

            return null;
        }

        public static List<User> GetAllUsers(int? numeroClasse = null)
        {
            List<User> list = new();

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = numeroClasse == null
                ? "SELECT * FROM Utilisateur"
                : "SELECT * FROM Utilisateur WHERE numero_classe = @number";

            using SqlCommand cmd = new SqlCommand(query, conn);

            if (numeroClasse != null)
                cmd.Parameters.AddWithValue("@number", numeroClasse);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User
                {
                    Id = (int)reader["id"],
                    FirstName = reader["prenom"].ToString(),
                    LastName = reader["nom"].ToString(),
                    ClassNumber = (int)reader["numero_classe"],
                    DateDiploma = (DateTime)reader["date_diplome"]
                });
            }

            return list;
        }
    }
}
