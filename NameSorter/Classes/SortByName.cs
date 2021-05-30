using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.Classes
{
    public static class SortByName
    {
        /// <summary>
        /// Sorts List of string to Name and sorts by last name then by given names.
        /// </summary>
        public static List<string> SortNamesBySurname(List<string> unsortedNames)
        {
            try
            {
                var convertedNameList = unsortedNames.ConvertAll(un => new Name(un));
                convertedNameList.Sort();

                return convertedNameList.Select(cn => cn.FullName).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets list of unsorted names from UnsortedFiles Directory.
        /// </summary>
        public static List<string> GetUnsortedNamesFromDirectory()
        {
            const string unsortedNames = @".\UnsortedFiles\unsorted-names-list.txt";

            return File.ReadAllLines(unsortedNames).ToList();
        }

        /// <summary>
        /// Saves sorted names to SortedFiles directory, creates directory if it doesn't exist.
        /// </summary>
        public static void SaveSortedNamesToFile(List<string> sortedNames)
        {
            const string directoryToSaveSortedNames = @".\SortedFiles\sorted-names-list.txt";
            const string sortedFilesDirectory = @".\SortedFiles";

            if (!Directory.Exists(sortedFilesDirectory))
            {
                Directory.CreateDirectory(sortedFilesDirectory);
            }

            File.WriteAllLines(directoryToSaveSortedNames, sortedNames);
        }
    }
}