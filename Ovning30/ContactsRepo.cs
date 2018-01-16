using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ovning30
{
    public class ContactsRepo
    {

        public string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContactsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Contact> GetAllContacts()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
                List<Contact> allContacts = new List<Contact>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM CONTACT", connection);
                SqlDataReader result = command.ExecuteReader();
                while (result.Read())
                {
                    allContacts.Add(
                        new Contact {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            PhoneNumber = (string)result["PhoneNumber"],
                            SSN = (string)result["SSN"]
                        }
                        );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }

            return allContacts;
        }

        public Contact CreateContact(int id, string name, string phoneNumber, string ssn)
        {
            Contact contact = new Contact { Id = id, Name = name, PhoneNumber = phoneNumber, SSN = ssn};

            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO CONTACT (Id, Name, PhoneNumber, SSN) VALUES ({contact.Id}, {contact.Name}, {contact.PhoneNumber}, {contact.SSN})", connection);
                var result = (int)command.ExecuteNonQuery();
                return contact;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }

            return contact;
        }

        public Contact UpdateContact(int id, string newName, string newPhoneNumber, string newSsn)
        {
            Contact contact = GetContactById(id);

            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE CONTACT (Id, Name, PhoneNumber, SSN) SET Name = {contact.Name}, Phone Number = {contact.PhoneNumber}, SSN = {contact.SSN}) WHERE Id = {contact.Id}", connection);
                var result = (int)command.ExecuteNonQuery();
                return contact;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }

            return contact;
        }

        public List<Contact> DeleteContact(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM CONTACT WHERE Id = {id}", connection);
                int result = command.ExecuteNonQuery();
                List<Contact> allContacts = GetAllContacts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }

            return null;
        }

        public Contact GetContactById(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            List<Contact> allContacts = new List<Contact>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM CONTACT WHERE Id = {id}", connection);
                SqlDataReader result = command.ExecuteReader();
                var contact = new Contact { Id = (int)result["Id"], Name = (string)result["Name"], PhoneNumber = (string)result["Phone Number"], SSN = (string)result["SSN"]};
                return contact;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }

            return null;
        }
    }
}