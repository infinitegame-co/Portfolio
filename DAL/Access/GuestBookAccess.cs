using System;
using System.Data.SqlClient;
using DAL.Interfaces;
using DAL.Context;
using DTO;
using System.Collections.Generic;

namespace DAL.Access
{
    public class GuestBookAccess : IGuestBookAccess
    {
        public void Create(GuestBookDTO obj)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO[GuestBook](User_Nickname,Message,PostTime) " +
                    "VALUES(@User, @Message, @Date)", conn))
                {

                    command.Parameters.AddWithValue("User", obj.NickName);
                    command.Parameters.AddWithValue("Message", obj.Message);
                    command.Parameters.AddWithValue("Date", obj.PostDate);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM[GuestBook] WHERE Id = @Id", conn))
                {
                    command.Parameters.AddWithValue("Id", index);

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public GuestBookDTO Get(GuestBookDTO obj)
        {
            GuestBookDTO EmptyDTO = new GuestBookDTO();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT Id,User_Nickname,Message,PostTime FROM[GuestBook] " +
                    "WHERE [GuestBook].User_Nickname = @Nickname", conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("Nickname", obj.NickName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string Message = reader.GetString(2);
                        DateTime PostDate = reader.GetDateTime(3);
                        GuestBookDTO Data = new GuestBookDTO(id, PostDate, Message, nickname);

                        return Data;
                    }

                    conn.Close();
                    return EmptyDTO;
                }
            }
        }

        public List<GuestBookDTO> GetAllEntries()
        {
            List<GuestBookDTO> Data = new List<GuestBookDTO>();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM[GuestBook]", conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string Message = reader.GetString(2);
                        DateTime PostDate = reader.GetDateTime(3);
                        Data.Add(new GuestBookDTO(id, PostDate, Message, nickname));

                    }

                    conn.Close();
                    return Data;
                }
            }
        }

        public List<GuestBookDTO> GetAmountOfEntries(int amount)
        {
            List<GuestBookDTO> Data = new List<GuestBookDTO>();

            using (SqlConnection conn = new SqlConnection(DBConnection.CONNECTIONSTRING))
            {
                using (SqlCommand command = new SqlCommand("SELECT TOP (@amount) [Id],[User_Nickname],[Message],[PostTime]  FROM [dbi413985].[dbo].[GuestBook]  ORDER BY [Id] DESC", conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("amount", amount);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nickname = reader.GetString(1);
                        string Message = reader.GetString(2);
                        DateTime PostDate = reader.GetDateTime(3);
                        Data.Add(new GuestBookDTO(id, PostDate, Message, nickname));

                    }

                    conn.Close();
                    return Data;
                }
            }
        }

        public GuestBookDTO GetLatestEntry()
        {
            throw new NotImplementedException();
        }

        public GuestBookDTO Read(int index)
        {
            throw new NotImplementedException();
        }

        public void Update(GuestBookDTO Original, GuestBookDTO Replacement)
        {
            throw new NotImplementedException();
        }
    }
}
