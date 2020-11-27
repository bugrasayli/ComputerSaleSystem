using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockRam : IRam
    {
        private List<RAM> rams;
        public MockRam()
        {
            rams = new List<RAM>();
            rams.Add(new RAM {ID=0,Name="4 GB" });
            rams.Add(new RAM {ID=1,Name="8 GB" });
            rams.Add(new RAM {ID=2,Name="16 GB" });
            rams.Add(new RAM {ID=3,Name="32 GB" });
        }
        public List<RAM> Rams()
        {
            return rams;
        }
    }
}
