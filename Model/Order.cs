    using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public int ID { get; set; }
        public List<Computer> Computers { get; set; }
        public float Price
        {
            get
            {
                float a = 0;
                foreach (var item in Computers)
                {
                    a += item.Detail.LastPrice;
                }
                return a;
            }
            set
            {
            }
        }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Delivered { get; set; } 
        public DateTime OrderedTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
