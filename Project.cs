using System;
using System.Collections.Generic;
using System.Text;

namespace Reply2018Final
{
    class Project
    {
        public int penalty;
        public int[] products;
        public Project(int penalty, int countryID, int[] products)
        {
            this.penalty = penalty;
            this.products = products;
        }
    }
}
