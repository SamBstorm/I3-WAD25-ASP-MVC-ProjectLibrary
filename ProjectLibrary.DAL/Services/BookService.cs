using Microsoft.Data.SqlClient;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectLibrary.DAL.Services
{
    public class BookService
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
            throw new NotImplementedException();
        }

        public Guid Create(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid bookId, Book newData)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}
