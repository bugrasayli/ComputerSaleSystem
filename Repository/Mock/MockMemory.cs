using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockMemory : IMemory
    {
        private List<Memory> memories;
        public MockMemory()
        {
            memories = new List<Memory>();
            memories.Add(new Memory {ID=0, HDD="1 TB",SSD="0 GB" });
            memories.Add(new Memory {ID=1, HDD="1 TB",SSD="128 GB" });
            memories.Add(new Memory {ID=2, HDD="1 TB",SSD="256 GB" });
            memories.Add(new Memory {ID=3, HDD="0 GB",SSD="1 TB" });
            memories.Add(new Memory {ID=4, HDD="1 TB",SSD="512 GB" });
        }
        public List<Memory> Memories()
        {
            return memories;
        }
    }
}
