using System;
using System.Collections.Generic;
using System.Text;

namespace Reply2018Final
{
    class Project
    {
        public int penalty;
        public int[] products;
        public int countryID;
        public Project(int penalty, int countryID, int[] products)
        {
            this.penalty = penalty;
            this.countryID = countryID;
            this.products = new int[products.Length];
            for(int i = 0; i < products.Length; i++)
            {
                this.products[i] = products[i];
            }
        }
    }
}
