using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockCPU : ICPU
    {
        private List<CPU> processors;
        public MockCPU()
        {
            processors = new List<CPU>();
            processors.Add(new CPU { ID = 0,Name="Intel i3" });
            processors.Add(new CPU { ID = 1,Name="Intel i5" });
            processors.Add(new CPU { ID = 2,Name="Intel i7" });
            processors.Add(new CPU { ID = 3,Name="Intel i9" });
            processors.Add(new CPU { ID = 4,Name="AMD Rayzen 3" });
        }
        public List<CPU> Processors()
        {
            return processors;
        }
    }
}
