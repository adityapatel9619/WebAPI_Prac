using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebAPI_Prac.Models;

namespace WebAPI_Prac.DB
{
    public class DBRegister
    {
        // For Add("A")
        public IEnumerable<ModelRegister> GetRegisterList(string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelRegister> test = new List<ModelRegister>();
                SqlCommand cmd = new SqlCommand("usp_RegisterFormAE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "A";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ModelRegister mr = new ModelRegister();
                    mr.Id = dr["Id"].ToString();
                    mr.Firstname = dr["Firstname"].ToString();
                    mr.Lastname = dr["Lastname"].ToString();
                    mr.Addresline1 = dr["Addressline1"].ToString();
                    mr.Addressline2 = dr["Addressline2"].ToString();
                    mr.Phonenumber = dr["Phonenumber"].ToString();
                    mr.Alternatenumber = dr["Alternatenumber"].ToString();
                    mr.Dob = dr["Dateofbirth"].ToString();
                    mr.Gender = dr["Gender"].ToString();
                    test.Add(mr);
                }
                con.Close();

                return test.ToArray();
            }
        }


        //For Edit("E")
        public IEnumerable<ModelRegister> EditRegisterList(int id, string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                List<ModelRegister> test = new List<ModelRegister>();
                SqlCommand cmd = new SqlCommand("usp_RegisterFormAE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Type", "E");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ModelRegister mr = new ModelRegister();
                    mr.Id = dr["Id"].ToString();
                    mr.Firstname = dr["Firstname"].ToString();
                    mr.Lastname = dr["Lastname"].ToString();
                    mr.Addresline1 = dr["Addressline1"].ToString();
                    mr.Addressline2 = dr["Addressline2"].ToString();
                    mr.Phonenumber = dr["Phonenumber"].ToString();
                    mr.Alternatenumber = dr["Alternatenumber"].ToString();
                    mr.Dob = dr["Dateofbirth"].ToString();
                    mr.Gender = dr["Gender"].ToString();
                    test.Add(mr);
                }
                con.Close();

                return test.ToArray();
            }
        }


        // POST  for Saving
        public string Post(ModelRegister stud,string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("usp_RegisterFormAE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@Firstname", stud.Firstname.ToString());
                cmd.Parameters.AddWithValue("@Lastname", stud.Lastname.ToString());
                cmd.Parameters.AddWithValue("@Addressline1", stud.Addresline1.ToString());
                cmd.Parameters.AddWithValue("@Addressline2", stud.Addressline2.ToString());
                cmd.Parameters.AddWithValue("@Phonenumber", stud.Phonenumber.ToString());
                cmd.Parameters.AddWithValue("@Alternatenumber", stud.Alternatenumber.ToString());
                cmd.Parameters.AddWithValue("@Dateofbirth", stud.Dob.ToString());
                cmd.Parameters.AddWithValue("@Gender", stud.Gender.ToString());
                cmd.Parameters.AddWithValue("@Userid", stud.Userid.ToString());
                cmd.Parameters.AddWithValue("@Type","A");
                cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@Returnmessage"].Value.ToString();
                con.Close();
                return result;
            }
        }


        //PUT for Updating
        public string Put(ModelRegister stud,string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("usp_RegisterFormAE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", stud.Firstname.ToString());
                cmd.Parameters.AddWithValue("@Lastname", stud.Lastname.ToString());
                cmd.Parameters.AddWithValue("@Addressline1", stud.Addresline1.ToString());
                cmd.Parameters.AddWithValue("@Addressline2", stud.Addressline2.ToString());
                cmd.Parameters.AddWithValue("@Phonenumber", stud.Phonenumber.ToString());
                cmd.Parameters.AddWithValue("@Alternatenumber", stud.Alternatenumber.ToString());
                cmd.Parameters.AddWithValue("@Dateofbirth", stud.Dob.ToString());
                cmd.Parameters.AddWithValue("@Gender", stud.Gender.ToString());
                cmd.Parameters.AddWithValue("@Userid", stud.Userid.ToString());
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "E";
                cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@Returnmessage"].Value.ToString();
                con.Close();
                return result;
            }
        }

        // DELETE For Deleting
        public string Delete(int id,string deletedby,string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                List<ModelRegister> test = new List<ModelRegister>();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("usp_RegisterFormSD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Type", "D");
                cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@Returnmessage"].Value.ToString();
                
                con.Close();
                return result;
            }
        }

    }
}
