using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace UsersFiles.FileTypes
{
    public class XmlUsersFile : UsersFile
    {
        public  XmlUsersFile(string filePath) : base(filePath) { }

        public override string ValidExtension
        {
            get
            {
                return ".xml";
            }
        }

        public override List<User> Users
        {
            get
            {
                List<User> users = new List<User>();

                string xml = File.ReadAllText(FilePath);

                if (!xml.Equals(""))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("Users"));

                    using (StringReader reader = new StringReader(xml))
                    {
                        users = (List<User>) serializer.Deserialize(reader);
                    }
                }

                return users;
            }
        }
    }
}
