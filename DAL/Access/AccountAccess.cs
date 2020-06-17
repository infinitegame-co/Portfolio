using System;
using System.Data.SqlClient;
using DAL.Interfaces;
using DAL.Context;
using DTO;
using System.Collections.Generic;

namespace DAL.Access
{
    public class AccountAccess : IAccountAccess
    {
        public void Create(AccountDTO obj)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO[user](Email, Nickname, Password) " +
                    "VALUES(@email, @nickname, @password)", conn))
                {

                    command.Parameters.AddWithValue("email", obj.Email);
                    command.Parameters.AddWithValue("nickname", obj.NickName);
                    command.Parameters.AddWithValue("password", obj.Password);
                    command.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public void Delete(int index)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM[user] WHERE Id = @Id"))
                {
                    command.Parameters.AddWithValue("Id", index);

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public AccountDTO Get(AccountDTO obj)
        {
            AccountDTO EmptyDTO = new AccountDTO();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT Id,NickName,Email,Password FROM[user] " +
                    "WHERE [user].Email = @Email AND [user].Password = @Password", conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("Email", obj.Email);
                    command.Parameters.AddWithValue("Password", obj.Password);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string email = reader.GetString(2);
                        string password = reader.GetString(3);
                        AccountDTO Data = new AccountDTO(id, email, nickname, password);

                        return Data;
                    }

                    conn.Close();
                    return EmptyDTO;
                }
            }
        }

        public List<string> GetAllEmails()
        {
            List<string> FilledList = new List<string>();
            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT Email FROM [user]", conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FilledList.Add(reader.GetString(0));
                    }
                    conn.Close();
                    return FilledList;
                }
            }
        }

        public List<string> GetAllNicknames()
        {
            List<string> FilledList = new List<string>();
            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT Nickname FROM [user]", conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FilledList.Add(reader.GetString(0));
                    }
                    conn.Close();
                    return FilledList;
                }
            }
        }

        public AccountDTO GetLatestEntry()
        {
            AccountDTO EmptyDTO = new AccountDTO();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [user] WHERE Id=(SELECT max(Id) FROM [user])", conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string email = reader.GetString(2);
                        string password = reader.GetString(3);
                        AccountDTO Data = new AccountDTO(id, email, nickname, password);

                        return Data;
                    }

                    conn.Close();
                    return EmptyDTO;
                }
            }
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public AccountDTO Read(int index)
        {
            AccountDTO EmptyDTO = new AccountDTO();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [user] WHERE Id=@id", conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("id", index);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string email = reader.GetString(2);
                        string password = reader.GetString(3);
                        AccountDTO Data = new AccountDTO(id, email, nickname, password);

                        return Data;
                    }

                    conn.Close();
                    return EmptyDTO;
                }
            }
        }

        public void Update(AccountDTO Original, AccountDTO Replacement)
        {
            throw new NotImplementedException();
        }
    }
}
