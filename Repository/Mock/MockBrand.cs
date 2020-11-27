using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
    public class MockBrand : IBrand
    {
        private List<Brand> brands;
        public List<Brand> Brands()
        {
           brands = new List<Brand>();
            brands.Add(new Brand{ID=0,Name="Lenovo"});
            brands.Add(new Brand{ID=1,Name="Asus"});
            brands.Add(new Brand{ID=2,Name="Toshiba"});
            brands.Add(new Brand{ID=3,Name="Acer"});
            brands.Add(new Brand{ID=4,Name="Mac"});
            brands.Add(new Brand{ID=5,Name="Sony"});
            return brands;
        }
    }
}
