using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContactAPI.Models;

namespace ContactAPI.Repository
{
    public class ContactRepository
    {
        string connectionString = "Server=PUN-DE-DLB22F8\\SQLEXPRESS;Database=Contact;Trusted_Connection=True;MultipleActiveResultSets=true";
        //To View all Contacts details
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                List<Contact> contacts = new List<Contact>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Contact";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
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
        public void AddContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"Insert into Contact (FirstName,LastName,Email,PhoneNumber,Status)
                     Values (@FirstName, @LastName, @Email, @PhoneNumber, @Status) ";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", contact.Status);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar contact
        public void UpdateContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"Update Contact         
                                        set FirstName=@FirstName,        
                                        LastName=@LastName,        
                                        Email=@Email,      
                                        PhoneNumber=@PhoneNumber,
                                        Status = @Status        
                                        where ContactId=@ContactId    ";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
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
                    string sqlQuery = "SELECT * FROM Contact WHERE ContactId=" + contactId;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
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
        public void DeleteContact(int contactId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string sqlQuery = "Delete from Contact where ContactId=@ContactId";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}