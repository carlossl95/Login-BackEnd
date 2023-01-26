using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serve.Domain;
using System.Data.SqlClient;

namespace Serve.Infra.Data.Dao
{

    public class ClientDao
    {
        private readonly string _connectionString = @"server=.\SQLEXPRESS;initial catalog=USER_DB;integrated security=true;";

        public void AddNewClient(Client newClient)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;

                    string sql = @"INSERT CLIENT
                                   VALUES(@NAME,
                                          @EMAIL,
                                          @PHONE,
                                          @CPF,
                                          @BIRTH_DATE,
                                          @SEX,
                                          @MARITAL_STATUS,
                                          @CEP,
                                          @CITY,
                                          @NEIGHBORHOOD,
                                          @STATE_,
                                          @STREET,
                                          @NUMBER_,
                                          @COMPLEMENT_ADDRESS,
                                          @PASSWORD_)";

                    command.Parameters.AddWithValue("@NAME", newClient.Name);
                    command.Parameters.AddWithValue("@EMAIL", newClient.Email);
                    command.Parameters.AddWithValue("@PHONE", newClient.Phone);
                    command.Parameters.AddWithValue("@CPF", newClient.Cpf);
                    command.Parameters.AddWithValue("@BIRTH_DATE", newClient.BirthDate);
                    command.Parameters.AddWithValue("@SEX", newClient.sex);
                    command.Parameters.AddWithValue("@MARITAL_STATUS", newClient.MaritalStatus);
                    command.Parameters.AddWithValue("@CEP", newClient.Cep);
                    command.Parameters.AddWithValue("@CITY", newClient.City);
                    command.Parameters.AddWithValue("@NEIGHBORHOOD", newClient.Neighborhood);
                    command.Parameters.AddWithValue("@STATE_", newClient.State);
                    command.Parameters.AddWithValue("@STREET", newClient.Street);
                    command.Parameters.AddWithValue("@NUMBER_", newClient.Number);
                    command.Parameters.AddWithValue("@COMPLEMENT_ADDRESS", newClient.Complement);
                    command.Parameters.AddWithValue("@PASSWORD_", newClient.Password);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
            }            
        }


        internal Client UpdateClient(Client UpdateClient)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"UPDATE CLIENT
                                   SET NAME_ = @NAME_,
                                       PHONE = @PHONE,
                                       CPF = @CPF,
                                       BIRTH_DATE = @BIRTH_DATE,
                                       SEX = @SEX,
                                       MARITAL_STATUS = @MARITAL_STATUS,
                                       CEP = @CEP,
                                       CITY = @CITY,
                                       NEIGHBORHOOD = @NEIGHBORHOOD,
                                       STATE_ = @STATE_,
                                       STREET = @STREET,
                                       NUMBER_ = @NUMBER_,
                                       COMPLEMENT_ADDRESS = @COMPLEMENT_ADDRESS
                                       WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", UpdateClient.Id);
                    command.Parameters.AddWithValue("@NAME_", UpdateClient.Name);
                    command.Parameters.AddWithValue("@PHONE", UpdateClient.Phone);
                    command.Parameters.AddWithValue("@CPF", UpdateClient.Cpf);
                    command.Parameters.AddWithValue("@BIRTH_DATE", UpdateClient.BirthDate);
                    command.Parameters.AddWithValue("@SEX", UpdateClient.sex);
                    command.Parameters.AddWithValue("@MARITAL_STATUS", UpdateClient.MaritalStatus);
                    command.Parameters.AddWithValue("@CEP", UpdateClient.Cep);
                    command.Parameters.AddWithValue("@CITY", UpdateClient.City);
                    command.Parameters.AddWithValue("@NEIGHBORHOOD", UpdateClient.Neighborhood);
                    command.Parameters.AddWithValue("@STATE_", UpdateClient.State);
                    command.Parameters.AddWithValue("@STREET", UpdateClient.Street);
                    command.Parameters.AddWithValue("@NUMBER_", UpdateClient.Number);
                    command.Parameters.AddWithValue("@COMPLEMENT_ADDRESS", UpdateClient.Complement);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
            }

            return UpdateClient;
        }


        internal void UpdatePassword(int id, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"UPDATE CLIENT
                                   SET PASSWORD_ = @PASSWORD
                                        WHERE ID = @ID";

                    
                    command.Parameters.AddWithValue("@PASSWORD", newPassword);
                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
            }            
        }


        internal List<Client> ListClient()
        {
            var listClient = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"SELECT * FROM CLIENT";
                                       
                    command.CommandText = sql;

                    var leader = command.ExecuteReader();

                    while (leader.Read())
                    {
                        var client = new Client
                        {
                            Id = int.Parse(leader["ID"].ToString()),
                            Name = leader["NAME_"].ToString(),
                            Email = leader["EMAIL"].ToString(),
                            Phone = leader["PHONE"].ToString(),
                            Cpf = leader["CPF"].ToString(),
                            BirthDate = DateTime.Parse(leader["BIRTH_DATE"].ToString()),
                            sex = leader["SEX"].ToString(),
                            MaritalStatus = leader["MARITAL_STATUS"].ToString(),
                            Cep = leader["CEP"].ToString(),
                            City = leader["CITY"].ToString(),
                            Neighborhood = leader["NEIGHBORHOOD"].ToString(),
                            State = leader["STATE_"].ToString(),
                            Street = leader["STREET"].ToString(),
                            Number = leader["NUMBER_"].ToString(),
                            Complement = leader["COMPLEMENT_ADDRESS"].ToString(),
                            Password = leader["PASSWORD_"].ToString(),
                        };
                        listClient.Add(client);
                    }
                }
            }
            return listClient;
        }



        internal void DeleteClient(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"DELETE FROM CLIENT WHERE ID = @ID";
                    
                    command.Parameters.AddWithValue("@id", id);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }       

        internal object SeaecheId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"SELECT NAME_,
                                          EMAIL,
                                          PHONE,
                                          CPF,
                                          BIRTH_DATE,
                                          SEX,
                                          MARITAL_STATUS,
                                          CEP,
                                          CITY,
                                          NEIGHBORHOOD,
                                          STATE_,
                                          STREET,
                                          NUMBER_,
                                          COMPLEMENT_ADDRESS,                                          
                                          * FROM CLIENT WHERE ID = @ID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@ID", id);

                    var leader = command.ExecuteReader();

                    while (leader.Read())
                    {
                        var searcheClient = new Client
                        {
                            Name = leader["NAME_"].ToString(),
                            Email = leader["EMAIL"].ToString(),
                            Phone = leader["PHONE"].ToString(),
                            Cpf = leader["CPF"].ToString(),
                            BirthDate = DateTime.Parse(leader["BIRTH_DATE"].ToString()),
                            sex = leader["SEX"].ToString(),
                            MaritalStatus = leader["MARITAL_STATUS"].ToString(),
                            Cep = leader["CEP"].ToString(),
                            City = leader["CITY"].ToString(),
                            Neighborhood = leader["NEIGHBORHOOD"].ToString(),
                            State = leader["STATE_"].ToString(),
                            Street = leader["STREET"].ToString(),
                            Number = leader["NUMBER_"].ToString(),
                            Complement = leader["COMPLEMENT_ADDRESS"].ToString(),
                        };
                        return searcheClient;
                    }
                }
            }
            return new Exception("client not found");
        }

    }




}
