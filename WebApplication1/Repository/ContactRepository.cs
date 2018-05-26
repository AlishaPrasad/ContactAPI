using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContactAPI.Models;

namespace ContactAPI.Repository
{
    public class ContactRepository
    {
        string connectionString = "Server=ALISHA-HP\\SQLEXPRESS;Database=Contact;Trusted_Connection=True;MultipleActiveResultSets=true";
       
        //To View all Contacts details
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                List<Contact> contacts = new List<Contact>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllContacts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Contact contact = new Contact();
                        contact.ContactId = Convert.ToInt32(rdr["ContactId"]);
                        contact.FirstName = rdr["FirstName"].ToString();
                        contact.LastName = rdr["LastName"].ToString();
                        contact.Email = rdr["Email"].ToString();
                        contact.PhoneNumber = rdr["PhoneNumber"].ToString();
                        contact.Status = rdr["Status"].ToString();
                        contacts.Add(contact);
                    }
                    con.Close();
                }
                return contacts;
            }
            catch
            {
                throw;
            }
        }

        //To Add new contact record 
        public bool AddContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                   
                    SqlCommand cmd = new SqlCommand("spAddContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", contact.Status);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar contact
        public bool UpdateContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactId", contact.ContactId);
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", contact.Status);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular contact
        public Contact GetContact(int contactId)
        {
            try
            {
                Contact contact = new Contact();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                   SqlCommand cmd = new SqlCommand("spGetContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        contact.ContactId = Convert.ToInt32(rdr["ContactId"]);
                        contact.FirstName = rdr["FirstName"].ToString();
                        contact.LastName = rdr["LastName"].ToString();
                        contact.Email = rdr["Email"].ToString();
                        contact.PhoneNumber = rdr["PhoneNumber"].ToString();
                        contact.Status = rdr["Status"].ToString();
                    }
                }
                return contact;
            }
            catch
            {
                throw;
            }
        }
        
        //To Delete the record on a particular contact
        public bool DeleteContact(int contactId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                   SqlCommand cmd = new SqlCommand("spDeleteContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}