using System;
using System.IO;

using UsersFiles.FileTypes;

namespace UsersFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // pliki z danymi użytkowników umieściłem w '/UsersFiles/UsersFiles/bin/debug/netcoreapp2.2/user_files'

            string[] filepaths = Directory.GetFiles("user_files");

            foreach (string path in filepaths)
            {
                string extension = Path.GetExtension(path);

                UsersFile usersFile = null;

                if (extension.Equals(".csv"))
                {
                    usersFile = new CsvUsersFile(path);
                }
                else if (extension.Equals(".xml"))
                {
                    usersFile = new XmlUsersFile(path);
                }
                else if (extension.Equals(".json"))
                {
                    usersFile = new JsonUsersFile(path);
                }
                /*
                    Tutaj można dodawać obsługę kolejnych plików 
                */
                else
                {
                    Console.WriteLine("Nieobsługiwane rozszerzenie: '{0}'", extension);
                }

                if(usersFile != null)
                {
                    Console.WriteLine("Użytkownicy w pliku '{0}':", Path.GetFileName(path));

                    try
                    {
                        foreach (User u in usersFile.Users)
                            Console.WriteLine("Imię: {0}, Nazwisko: {1}, Email: {2}", u.FirstName, u.LastName, u.EmailAddress);
                    }
                    catch(Exception e)
                    {
                        /* 
                         * Tutaj trzeba łapać wyjątki rzucane przez 'get' właściwości Users
                         * (na chwilę obecną są to przede wszystkim wyjątki deserializacji plików XML i JSON)
                        */

                        Console.WriteLine("'{0}' - {1}", e.GetType(), e.Message);
                    }
                }
            }

            Console.ReadKey();
        }

    }
}
