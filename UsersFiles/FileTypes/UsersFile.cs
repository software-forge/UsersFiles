using System;
using System.IO;
using System.Collections.Generic;

namespace UsersFiles.FileTypes
{
    public abstract class UsersFile
    {
        private string _fullpath;

        /// <summary>
        /// Zwraca bezwzględną ścieżkę do istniejącego pliku z danymi użytkowników, którego obiekt jest reprezentacją (przypisać można ścieżkę względną)
        /// </summary>
        public string FilePath
        {
            get
            {
                return _fullpath;
            }
            private set
            {
                string fullPath = Path.GetFullPath(value);

                if (!File.Exists(fullPath))
                    throw new Exception(string.Format("Plik w lokalizacji '{0}' nie istnieje", fullPath));

                string extension = Path.GetExtension(fullPath);

                if (!extension.Equals(ValidExtension))
                    throw new Exception(string.Format("Nieprawidłowe rozszerzenie pliku: '{0}'", extension));

                _fullpath = fullPath;
            }
        }

        /// <summary>
        /// Tworzy nowy obiekt reprezentujący plik z danymi użytkowników istniejący pod wskazaną lokalizacją
        /// </summary>
        /// <param name="filePath">Względna lub bezwzględna ścieżka do pliku z danymi użytkowników</param>
        public UsersFile(string filePath)
        {
            FilePath = filePath;
        }

        public abstract string ValidExtension { get; }

        public abstract List<User> Users { get; }
    }
}
