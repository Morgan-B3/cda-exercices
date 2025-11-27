using Azure.Core;
using Exercice2.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.DAO
{
    internal class CommandeDAO : BaseDao<Commande>
    {
        public override bool DeleteById(int id)
        {
            request = "DELETE FROM commande WHERE id=@id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            command.Parameters.AddWithValue("@id", id);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override List<Commande> GetAll(int? id = null)
        {
            List<Commande> commandes = new();

            request = id == null
                ? "SELECT id, client_id, date, total FROM commande"
                : "SELECT id, client_id, date, total FROM commande WHERE client_id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            if(id != null)
            {
                command.Parameters.AddWithValue("@id", id);
            } 

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                commandes.Add(new Commande(reader.GetInt32(1), reader.GetDateTime(2), reader.GetDecimal(3)));
            }
            return commandes;
        }

        public override Commande? getOneById(int id)
        {
            Commande? commande = null;

            request = "SELECT id, client_id, date, total  FROM commande WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                commande = new Commande(reader.GetInt32(1), reader.GetDateTime(2), reader.GetDecimal(3));
            }
            return commande;
        }

        public override Commande Save(Commande entity)
        {
            request = "INSERT INTO commande (client_id, date, total) OUTPUT INSERTED.ID VALUES (@client_id, @date, @total);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@client_id", entity.ClientId);
            command.Parameters.AddWithValue("@date", entity.Date);
            command.Parameters.AddWithValue("@total", entity.Total);

            connection.Open();

            entity.Id = (int)command.ExecuteScalar();

            return entity;
        }

        public override bool Update(Commande entity)
        {
            string request = "UPDATE commande SET client_id=@client_id, date=@date, total=@total OUTPUT INSERTED.* WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@client_id", entity.ClientId);
            command.Parameters.AddWithValue("@date", entity.Date);
            command.Parameters.AddWithValue("@total", entity.Total);

            connection.Open();

            Console.WriteLine((int)command.ExecuteScalar());

            return command.ExecuteNonQuery() == 1;
        }
    }
}
