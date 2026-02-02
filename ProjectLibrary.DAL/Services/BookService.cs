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
    public class BookService : IBookRepository<Book>
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectLibrary;Integrated Security=True";
        public IEnumerable<Book> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Get_All";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToBook();
                        }
                    }
                    connection.Close();
                }
            }
        }

        public Book Get(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Get_ById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToBook();
                        }
                        throw new ArgumentOutOfRangeException(nameof(bookId));
                    }
                    connection.Close();
                }
            }
        }

        public Guid Create(Book entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Book.Title), entity.Title);
                    command.Parameters.AddWithValue(nameof(Book.ReleaseDate), entity.ReleaseDate);
                    command.Parameters.AddWithValue(nameof(Book.ISBN), (object?)entity.ISBN ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Book.Author), (object?)entity.Author ?? DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                    connection.Close();
                }
            }
        }

        public void Update(Guid bookId, Book newData)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
                    command.Parameters.AddWithValue(nameof(Book.Title), newData.Title);
                    command.Parameters.AddWithValue(nameof(Book.ReleaseDate), newData.ReleaseDate);
                    command.Parameters.AddWithValue(nameof(Book.ISBN), (object?)newData.ISBN ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Book.Author), (object?)newData.Author ?? DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Delete(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
