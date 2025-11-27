using Azure.Core;
using Exercice2.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.DAO
{
    internal class ClientDAO : BaseDao<Client>
    {
        public override bool DeleteById(int id)
        {
            request = "DELETE FROM client INNER JOIN commande ON client.id = commande.client_id WHERE client.id=@id";
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

        public override List<Client> GetAll(int? id = null)
        {
            List<Client> clients = new ();

            request = "SELECT id, nom, prenom, adresse, code_postal, ville, telephone FROM client";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                clients.Add(new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
            }
            return clients;
        }

        public override Client? getOneById(int id)
        {
            Client? client = null;

            request = "SELECT id, nom, prenom, adresse, code_postal, ville, telephone FROM client WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                List<Commande> commandes = new CommandeDAO().GetAll(id);
                client = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), commandes);
            }
            return client;
        }

        public override Client Save(Client entity)
        {
            request = "INSERT INTO client (nom, prenom, adresse, code_postal, ville, telephone) OUTPUT INSERTED.ID VALUES (@nom, @prenom, @adresse, @code_postal, @ville, @telephone);";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@nom", entity.Nom);
            command.Parameters.AddWithValue("@prenom", entity.Prenom);
            command.Parameters.AddWithValue("@adresse", entity.Adresse);
            command.Parameters.AddWithValue("@code_postal", entity.CodePostal);
            command.Parameters.AddWithValue("@ville", entity.Ville);
            command.Parameters.AddWithValue("@telephone", entity.Telephone);

            connection.Open();

            entity.Id = (int)command.ExecuteScalar();

            return entity;
        }

        public override bool Update(Client entity)
        {
            string request = "UPDATE client SET prenom=@prenom, nom=@nom, adresse=@adresse, code_postal=@code_postal, ville=@ville, telephone=@telephone OUTPUT INSERTED.* WHERE id=@id;";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@nom", entity.Nom);
            command.Parameters.AddWithValue("@prenom", entity.Prenom);
            command.Parameters.AddWithValue("@adresse", entity.Adresse);
            command.Parameters.AddWithValue("@code_postal", entity.CodePostal);
            command.Parameters.AddWithValue("@ville", entity.Ville);
            command.Parameters.AddWithValue("@telephone", entity.Telephone);

            connection.Open();

            //Console.WriteLine((int)command.ExecuteScalar());

            return command.ExecuteNonQuery() == 1;
        }
    }
}
