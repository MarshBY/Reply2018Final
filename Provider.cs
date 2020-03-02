using System;
using System.Collections.Generic;
using System.Text;

namespace Reply2018Final
{
    class Provider
    {
        public int regionNum;
        public string name;
        public Region[] regions;
        public Provider(string name, int regionNum)
        {
            this.name = name;
            this.regionNum = regionNum;
            this.regions = new Region[regionNum];
        }
    }

    class Region
    {
        private int packageNumber;
        private float price;
        private int[] products;
        private int[] latencies;
        public string name;
        public Region(string name, int pNum, float price, int[] products, int[] latencies)
        {
            this.name = name;
            this.packageNumber = pNum;
            this.price = price;
            this.products = products;
            this.latencies = latencies;
        }
    }
}
