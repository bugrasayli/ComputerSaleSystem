using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Detail Detail{ get; set; }
        public Brand Brand{ get; set; }
        public Country MadeIn { get; set; }
        public CPU Processor { get; set; }
        public GraphicCard GraphicCard{ get; set; }
        public Type Type { get; set; }
        public Memory Memory { get; set; }
        public RAM Ram{ get; set; }
        public int MyProperty { get; set; }
    }
}
