using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UsersFiles.FileTypes
{
    public class JsonUsersFile : UsersFile
    {
        public JsonUsersFile(string filePath) : base(filePath) { }

        public override string ValidExtension
        {
            get
            {
                return ".json";
            }
        }

        public override List<User> Users
        {
            get
            {
                List<User> users = new List<User>();

                string json = File.ReadAllText(FilePath);

                if (!json.Equals(""))
                {
                    users = JsonSerializer.Deserialize<List<User>>(json);
                }

                return users;
            }
        }
    }
}
