using System.IO;
using System.Collections.Generic;

namespace UsersFiles.FileTypes
{
    public class CsvUsersFile : UsersFile
    {
        public CsvUsersFile(string filePath) : base(filePath) { }

        public override string ValidExtension
        {
            get
            {
                return ".csv";
            }
        }

        public override List<User> Users
        {
            get
            {
                List<User> u = new List<User>();

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    char[] delimiters = { ';', ',' };

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split(delimiters);

                        /* 
                            Przyjąłem, że puste pole CSV powinno skutkować zwróceniem null-a przy odczycie
                            (tak zachowują się serializatory XML i JSON przy deserializacji)
                        */

                        string firstName = null;
                        string lastName = null;
                        string email = null;

                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (i == 0 && !tokens[i].Equals(""))
                                firstName = tokens[i];

                            if (i == 1 && !tokens[i].Equals(""))
                                lastName = tokens[i];

                            if (i == 2 && !tokens[i].Equals(""))
                                email = tokens[i];
                        }

                        u.Add(new User(firstName, lastName, email));
                    }
                }

                return u;
            }
        }
    }
}
