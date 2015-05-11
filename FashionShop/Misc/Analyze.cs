using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace FashionShop.Misc
{
    public class Analyze
    {
        public Hashtable analyzeIdAndUser(string data)
        {
            string[] pairs = data.Split('&');
            Hashtable hashTable = new Hashtable();

            string[] tmp = pairs[0].Split('=');
            hashTable.Add("ID", tmp[1]);

            tmp = pairs[1].Split('=');
            hashTable.Add("Username", tmp[1]);

            return hashTable;
        }

        public Hashtable analyzeProductIdAndName(string data)
        {
            string[] pairs = data.Split('&');
            Hashtable hashTable = new Hashtable();

            string[] tmp = pairs[0].Split('=');
            hashTable.Add("ProductID", tmp[1]);

            tmp = pairs[1].Split('=');
            hashTable.Add("ProductName", tmp[1]);

            return hashTable;
        }
    }
}