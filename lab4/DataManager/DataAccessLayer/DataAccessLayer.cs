using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        string connectionString;

        public DataAccessLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void GetPerson(List<Person> persons, int id)
        {
            string sqlExpression = "dbo.GetPerson";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("id", id + 1));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string lastName = reader.GetString(1);
                        persons.Add(new Person(name, lastName));
                    }
                }
            }
        }

        public void GetPassword(List<Person> persons, int id)
        {
            string sqlExpression = "dbo.GetPassword";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("id", id + 1));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string passHash = reader.GetString(0);
                        persons[id].password = new Password(passHash);
                    }
                }
            }
        }

        public void GetAddress(List<Person> persons, int id)
        {
            string sqlExpression = "dbo.GetAddress";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("id", id + 1));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string addressLine = reader.GetString(0);
                        string city = reader.GetString(1);
                        string postalCode = reader.GetString(2);
                        persons[id].address = new Address(addressLine, city, postalCode);
                    }
                }
            }
        }

        public void GetEmailAddress(List<Person> persons, int id)
        {
            string sqlExpression = "dbo.GetEmailAddress";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("id", id + 1));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string address = reader.GetString(0);
                        persons[id].emailAdress = new EmailAddress(address);
                    }
                }
            }
        }

        public void GetPhoneNumber(List<Person> persons, int id)
        {
            string sqlExpression = "dbo.GetPhoneNumber";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("id", id + 1));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string number = reader.GetString(0);
                        int type = reader.GetInt32(1);
                        persons[id].phoneNumber = new PhoneNumber(number, type);
                    }
                }
            }
        }
    }
}
