using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockType : IType
    {
        private List<Model.Type> types;
        public MockType()
        {
            types = new List<Model.Type>();
            types.Add(new Model.Type { ID = 0, Name = "Laptop" });
            types.Add(new Model.Type { ID = 1, Name = "PC" });
        }

        public List<Model.Type> Types()
        {
            return types;   
        }
    }
}
