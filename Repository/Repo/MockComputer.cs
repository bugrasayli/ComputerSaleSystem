using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
    public class MockComputer : IComputer
    {
        private List<Model.Computer> computers;
        private readonly IRam ram;
        private readonly IBrand brand;
        private readonly ICountry country;
        public MockComputer(IRam _ram, IBrand _brand, ICountry _country)
        {
            ram = _ram;
            brand = _brand;
            country = _country;

            List<RAM> rams = this.ram.Rams();
            List<Brand> brands = this.brand.Brands();
            List<Country> countries= this.country.Countries();
            computers = new List<Computer>();
        }
        public List<Computer> Computers()
        {
            return computers;
        }
        public List<Computer> Computers(Model.Type type)
        {
            return computers.Where(x => x.Type.ID == type.ID).ToList();
        }
        public List<Computer> Computers(Brand brand)
        {
            return computers.Where(x => x.Brand.ID == brand.ID).ToList();
        }
        public List<Computer> Computers(CPU cpu)
        {
            return computers.Where(x => x.Processor.ID == cpu.ID).ToList();
        }

        public List<Computer> Computers(GraphicCard graphics)
        {
            return computers.Where(x => x.GraphicCard.ID == graphics.ID).ToList();

        }

        public List<Computer> Computers(Memory memory)
        {
            return computers.Where(x => x.Memory.ID == memory.ID).ToList();
        }

        public List<Computer> Computers(RAM ram)
        {
            return computers.Where(x => x.Ram.ID == ram.ID).ToList();

        }
    }
}
