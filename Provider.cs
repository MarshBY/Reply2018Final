using System;
using System.Collections.Generic;
using System.Text;

namespace Reply2018Final
{
    class Provider
    {
        private int regions;
        private string name;
        public Provider(string name, int regions)
        {
            this.name = name;
            this.regions = regions;
        }
    }

    class Region
    {
        private int packages;
        private float price;
        public Region()
        {

        }
    }
}
