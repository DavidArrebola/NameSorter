using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Classes
{
    public class Name : IComparable
    {
        public string Surname { get; set; }
        public List<string> GivenNames { get; set; } = new();

        public Name(string fullName)
        {
            var nameParts = fullName.Split(' ');

            this.GivenNames.AddRange(nameParts.Take(nameParts.Length - 1));
            this.Surname = nameParts.Last();
        }

        public string FullName => string.Join(' ', string.Join(' ', GivenNames), Surname);

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                // If not assigned return
                case null:
                    return 1;

                case Name otherName:
                    {
                        // Comparing Surnames
                        var compareResult = this.Surname.CompareTo(otherName.Surname);

                        // If Surnames are not the same we return.
                        if (compareResult != 0) return compareResult;

                        // Otherwise iterate through Given Names
                        for (var i = 0; i < this.GivenNames.Count; i++)
                        {
                            // Store the name to compare against
                            var otherGivenName = otherName.GivenNames.ElementAtOrDefault(i);
                            if (!string.IsNullOrEmpty(otherGivenName))
                            {
                                // Comparing the other given name against the name at the same index in the name we're comparing
                                compareResult = this.GivenNames[i].CompareTo(otherGivenName);

                                // if not the same we return
                                if (compareResult != 0) return compareResult;
                            }
                            else
                            {
                                return -1;
                            }
                        }

                        return compareResult;
                    }
                default:
                    throw new ArgumentException("Object is not a Name");
            }
        }
    }
}
