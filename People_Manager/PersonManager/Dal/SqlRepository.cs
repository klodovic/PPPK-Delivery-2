using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Zadatak.Models;
using Zadatak.Utils;

namespace Zadatak.Dal
{
    class SqlRepository : IRepository
    {   // cannot be const
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
       
        public void AddPerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
                    cmd.Parameters.Add(new SqlParameter(nameof(Person.Picture), SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });
                    SqlParameter idPerson = new SqlParameter(nameof(Person.IDPerson), SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPerson);
                    cmd.ExecuteNonQuery();
                    person.IDPerson = (int)idPerson.Value;
                }
            }
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Person> GetPeople()
        {
            IList<Person> people = new List<Person>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadPerson(dr));
                        }
                    }
                }
            }
            return people;
        }

        public Person GetPerson(int idPerson)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadPerson(dr);
                        }
                    }
                }
            }
            throw new Exception("Person does not exist");
        }
        
        private static Person ReadPerson(SqlDataReader dr) => new Person
        {
            IDPerson = (int)dr[nameof(Person.IDPerson)],
            FirstName = dr[nameof(Person.FirstName)].ToString(),
            LastName = dr[nameof(Person.LastName)].ToString(),
            Age = (int)dr[nameof(Person.Age)],
            Email = dr[nameof(Person.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5)
        };

        public void UpdatePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
                    cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
                    cmd.Parameters.Add(new SqlParameter(nameof(Person.Picture), SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /********************************************************/



        //Project 

        public void AddShoes(Shoes shoes)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Shoes.Brand), shoes.Brand);
                    cmd.Parameters.AddWithValue(nameof(Shoes.Size), shoes.Size);
                    cmd.Parameters.Add(new SqlParameter(nameof(Shoes.ShoesPicture), SqlDbType.Binary, shoes.ShoesPicture.Length)
                    {
                        Value = shoes.ShoesPicture
                    });
                    cmd.Parameters.AddWithValue(nameof(Shoes.PersonID), shoes.PersonID);

                    SqlParameter idShoes = new SqlParameter(nameof(Shoes.IDShoes), SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idShoes);
                    cmd.ExecuteNonQuery();
                    shoes.IDShoes = (int)idShoes.Value;
                }
            }
        }

        public void DeleteShoes(Shoes shoes)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Shoes.PersonID), shoes.PersonID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Shoes> GetAllShoesForSinglePerson(int personId)
        {
            IList<Shoes> shoes = new List<Shoes>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Shoes.PersonID), personId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            shoes.Add(ReadShoes(dr));
                        }
                    }
                }
            }
            return shoes;
        }

        private Shoes ReadShoes(SqlDataReader dr) => new Shoes
        {
            IDShoes = (int)dr[nameof(Shoes.IDShoes)],
            Brand = dr[nameof(Shoes.Brand)].ToString(),
            Size = (int)dr[nameof(Shoes.Size)],
            ShoesPicture = ImageUtils.ByteArrayFromSqlDataReader(dr, 3)
        };

        public Shoes GetPairOfShoes(int idPerson)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Shoes.IDShoes), idPerson);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadShoes(dr);
                        }
                    }
                }
            }
            throw new Exception("This Shoes does not exist");
        }

        public void UpdateShoes(Shoes shoes)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue(nameof(Shoes.IDShoes), shoes.IDShoes);
                    cmd.Parameters.AddWithValue(nameof(Shoes.Brand), shoes.Brand);
                    cmd.Parameters.AddWithValue(nameof(Shoes.Size), shoes.Size);
                    cmd.Parameters.Add(new SqlParameter(nameof(Shoes.ShoesPicture), SqlDbType.Binary, shoes.ShoesPicture.Length)
                    {
                        Value = shoes.ShoesPicture
                    });
                    cmd.Parameters.AddWithValue(nameof(Shoes.PersonID), shoes.PersonID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
