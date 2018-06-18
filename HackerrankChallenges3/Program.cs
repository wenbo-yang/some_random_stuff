using System;
using System.Collections.Generic;

class Solution
{
    // note: static stack, queue, dictionaries tends to leak
    // so I am wrapping it in a class instead 
    private static string addCommand = "add";
    private static string findCommand = "find";
    class ContactList
    {
        private string[] contactList;
        private int count;
        public ContactList(int maxNumber)
        {
            contactList = new string[maxNumber];
        }

        public void Add(string contactName)
        {
            contactList[count++] = contactName;
        }

        public int GetNumberOfContacts(string searchString)
        {
            int numOfContacts = 0;
            for (int i = 0; i < count; i++)
            {
                if (contactList[i].StartsWith(searchString))
                {
                    numOfContacts++;
                }
            }
            return numOfContacts;
        }
    }

    class SearchList
    {
        private string[] searchListCache;
        private int count;
        public SearchList(int cacheNumber)
        {
            searchListCache = new string[cacheNumber];
            count = 0;
        }

        public void Add(string searchString)
        {
            searchListCache[count++] = searchString;
        }

        public string[] SearchListCache => searchListCache;
        public int Count => count;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        var contactList = new ContactList(n);
        var searchList = new SearchList(n);
        for (int a0 = 0; a0 < n; a0++)
        {
            string[] tokens_op = Console.ReadLine().Split(' ');
            string op = tokens_op[0];
            string contact = tokens_op[1];

            if (op == addCommand)
            {
                contactList.Add(contact);
            }

            if (op == findCommand)
            {
                searchList.Add(contact);
            }
        }

        for (int i = 0; i < searchList.Count; i++ )
        {
            Console.WriteLine(contactList.GetNumberOfContacts(searchList.SearchListCache[i]).ToString());
        }
    }
}
