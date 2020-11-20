using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockCountry : ICountry
    {
        private List<Country> countries;
        public List<Country> Countries()
        {
            countries = new List<Country>();
            countries.Add(new Country { ID = 0, Name = "Turkey" });
            countries.Add(new Country { ID = 1, Name = "Indonesia" });
            countries.Add(new Country { ID = 2, Name = "China" });
            countries.Add(new Country { ID = 3, Name = "Lithuania" });
            return countries;
        }
    }
}
