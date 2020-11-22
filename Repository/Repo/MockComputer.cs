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
        private readonly IBrand brand;
        private readonly IRam ram;
        private readonly ICPU cpu;
        private readonly IMemory memory;
        private readonly IType type;
        private readonly IGraphicCard graphic;
        private readonly ICountry country;
        public MockComputer(IRam _ram, IBrand _brand, IGraphicCard _graphics, ICountry _country, IMemory _memory, ICPU _cpu, IType _type)
        {
            ram = _ram;
            brand = _brand;
            country = _country;
            cpu = _cpu;
            memory = _memory;
            type = _type;
            graphic = _graphics;


            List<RAM> rams = this.ram.Rams();
            List<Brand> brands = this.brand.Brands();
            List<CPU> processors = this.cpu.Processors();
            List<Memory> memories = this.memory.Memories();
            List<Country> countries = this.country.Countries();
            List<Model.Type> types = this.type.Types();
            List<GraphicCard> graphicCards = this.graphic.GraphicCards();


            computers = new List<Computer>();
            computers.Add(new Computer { ID = 0, Brand = brands[2], Name = brands[2].Name, MadeIn = countries[1], Ram = rams[3], GraphicCard = graphicCards[3], Memory = memories[4], Processor = processors[3], Type = types[0] });
            computers.Add(new Computer { ID = 1, Brand = brands[1], Name = brands[1].Name, MadeIn = countries[0], Ram = rams[2], GraphicCard = graphicCards[2], Memory = memories[2], Processor = processors[3], Type = types[0] });
            computers.Add(new Computer { ID = 2, Brand = brands[3], Name = brands[3].Name, MadeIn = countries[2], Ram = rams[3], GraphicCard = graphicCards[1], Memory = memories[2], Processor = processors[1], Type = types[0] });
            computers.Add(new Computer { ID = 3, Brand = brands[2], Name = brands[2].Name, MadeIn = countries[3], Ram = rams[0], GraphicCard = graphicCards[0], Memory = memories[0], Processor = processors[0], Type = types[1] });
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
