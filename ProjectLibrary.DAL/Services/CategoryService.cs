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
    public class CategoryService : ICategoryRepository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryService(SqlConnection connection)
        {
            _connection = connection;
        }

        public int Create(Category entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Category_Create";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Category.CategoryName), entity.CategoryName);
                    _connection.Open();
                    return (int)command.ExecuteScalar();
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void Delete(int categoryId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Category_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(categoryId), categoryId);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex) { throw ex; }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<Category> Get()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Category_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToCategory();
                    }
                }
            }
        }

        public Category Get(int categoryId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Category_Get_ById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(categoryId), categoryId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToCategory();
                    }
                    throw new ArgumentOutOfRangeException(nameof(categoryId));
                }
            }
        }

        public IEnumerable<Category> GetByBook(Guid bookId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Category_Get_ByBook";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(bookId), bookId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToCategory();
                    }
                }
            }
        }

        public void Update(int categoryId, Category entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Category_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(categoryId), categoryId);
                    command.Parameters.AddWithValue(nameof(Category.CategoryName), entity.CategoryName);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
