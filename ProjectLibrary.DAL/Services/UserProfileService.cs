using Microsoft.Data.SqlClient;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectLibrary.DAL.Services
{
    public class UserProfileService : IUserProfileRepository<UserProfile>
    {
        private readonly SqlConnection _connection;

        public UserProfileService(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<UserProfile> Get()
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.ToUserProfile();
                    }
                }
                _connection.Close();
            }
        }

        public UserProfile Get(Guid id)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Get_ById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(id), id);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToUserProfile();
                    }
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                _connection.Close();
            }

        }

        public Guid Create(UserProfile entity)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(UserProfile.LastName), entity.LastName);
                command.Parameters.AddWithValue(nameof(UserProfile.FirstName), entity.FirstName);
                command.Parameters.AddWithValue(nameof(UserProfile.BirthDate), entity.BirthDate);
                command.Parameters.AddWithValue(nameof(UserProfile.Biography), (object?)entity.Biography ?? DBNull.Value);
                command.Parameters.AddWithValue(nameof(UserProfile.ReadingSkill), (object?)entity.ReadingSkill ?? DBNull.Value);
                command.Parameters.AddWithValue(nameof(UserProfile.NewsLetterSubscribed), entity.NewsLetterSubscribed);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
                _connection.Close();
            }

        }

        public void Update(Guid userProfileId, UserProfile newData)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(userProfileId), userProfileId);
                command.Parameters.AddWithValue(nameof(UserProfile.Biography), (object?)newData.Biography ?? DBNull.Value);
                command.Parameters.AddWithValue(nameof(UserProfile.ReadingSkill), (object?)newData.ReadingSkill ?? DBNull.Value);
                command.Parameters.AddWithValue(nameof(UserProfile.NewsLetterSubscribed), newData.NewsLetterSubscribed);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public void Delete(Guid userProfileId)
        {

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(userProfileId), userProfileId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }
    }
}
