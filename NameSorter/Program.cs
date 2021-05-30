using System;
using NameSorter.Classes;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Miraculous Name Sorter.");
            Console.WriteLine("Would you like to sort a list of names you have saved to the SortedFiles folder? ('y' to sort any other key to exit) ");

            var key = Console.ReadKey(true).KeyChar;

            if (key != 'y') return;
            var nameList = SortByName.GetUnsortedNamesFromDirectory();
            var sortedNameList = SortByName.SortNamesBySurname(nameList);
            SortByName.SaveSortedNamesToFile(sortedNameList);

            foreach (var name in sortedNameList)
            {
                Console.WriteLine(name);
            }
        }
    }
}