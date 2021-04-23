using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace UsersFiles
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        /// <summary>
        /// Konstruktor bezparametrowy potrzebny do deserializacji
        /// </summary>
        public User() { }

        /// <summary>
        /// Sparametryzowany konstruktor wykorzystywany przy odczycie z pliku CSV
        /// </summary>
        /// <param name="firstName">Pierwsza kolumna pliku CSV - imię użytkownika</param>
        /// <param name="lastName">Druga kolumna pliku CSV - nazwisko użytkownika</param>
        /// <param name="emailAddress">Trzecia kolumna pliku CSV - adres email użytkownika</param>
        public User(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
