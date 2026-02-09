using Microsoft.Data.SqlClient;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectLibrary.DAL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool CheckIsAdministrator(Guid userId)
        {
            try
            {
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SP_User_CheckAsAdministrator";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(userId), userId);
                    _connection.Open();
                    return userId == (Guid)command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Guid CheckPassword(string email, string password)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_CheckPassword";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(email), email);
                command.Parameters.AddWithValue(nameof(password), password);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
                _connection.Close();
            }
        }

        public Guid Create(User entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(User.Email), entity.Email);
                command.Parameters.AddWithValue(nameof(User.Password), entity.Password);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
                _connection.Close();
            }
        }

        public void RemoveAsAdministrator(Guid userId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_RemoveAsAdministrator";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(userId), userId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void SetAsAdministrator(Guid userId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_SetAsAdministrator";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(userId), userId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
