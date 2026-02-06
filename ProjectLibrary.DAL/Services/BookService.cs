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
        private readonly SqlConnection _connection;
        public BookService(SqlConnection connection) {
            _connection = connection;
        }
        public IEnumerable<Book> Get()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Book_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToBook();
                    }
                }
                _connection.Close();
            }
        }

        public Book Get(Guid bookId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Book_Get_ById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(bookId), bookId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToBook();
                    }
                    throw new ArgumentOutOfRangeException(nameof(bookId));
                }
                _connection.Close();
            }
        }

        public Guid Create(Book entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Book_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Book.Title), entity.Title);
                    command.Parameters.AddWithValue(nameof(Book.ReleaseDate), entity.ReleaseDate);
                    command.Parameters.AddWithValue(nameof(Book.ISBN), (object?)entity.ISBN ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Book.Author), (object?)entity.Author ?? DBNull.Value);
                    _connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void Update(Guid bookId, Book newData)
        {
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SP_Book_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
                    command.Parameters.AddWithValue(nameof(Book.Title), newData.Title);
                    command.Parameters.AddWithValue(nameof(Book.ReleaseDate), newData.ReleaseDate);
                    command.Parameters.AddWithValue(nameof(Book.ISBN), (object?)newData.ISBN ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Book.Author), (object?)newData.Author ?? DBNull.Value);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
        }

        public void Delete(Guid bookId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Book_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(bookId), bookId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<Book> GetByCategory(int categoryId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Book_Get_ByCategory";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(categoryId), categoryId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToBook();
                    }
                }
            }
        }

        public void AddCategory(Guid bookId, int categoryId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Book_Add_Category";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
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

        public void RemoveCategory(Guid bookId, int categoryId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Book_Remove_Category";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(bookId), bookId);
                    command.Parameters.AddWithValue(nameof(categoryId), categoryId);
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
