using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Detail 
    {
        public float price { get; set; }
        public virtual Computer Computer { get; set; }
        public int Discount { get; set; }
        public int StockSize { get; set; }
        public float LastPrice
        {
            get
            {
                return price - ((price * Discount) / 100);
            }
            set
            {

            } 
        }
    }
}
