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
        private readonly IDetail detail;
        public MockComputer(IRam _ram,
            IBrand _brand, IGraphicCard _graphics, ICountry _country,
            IMemory _memory, ICPU _cpu, IType _type, IDetail _detail)
        {
            ram = _ram;
            brand = _brand;
            country = _country;
            cpu = _cpu;
            memory = _memory;
            type = _type;
            graphic = _graphics;
            detail = _detail;


            List<RAM> rams = this.ram.Rams();
            List<Brand> brands = this.brand.Brands();
            List<CPU> processors = this.cpu.Processors();
            List<Memory> memories = this.memory.Memories();
            List<Country> countries = this.country.Countries();
            List<Model.Type> types = this.type.Types();
            List<GraphicCard> graphicCards = this.graphic.GraphicCards();


            computers = new List<Computer>();
            Computer a = null;
            computers.Add(new Computer { ID = 0, Brand = brands[2], Name = brands[2].Name, MadeIn = countries[1], Ram = rams[3], GraphicCard = graphicCards[3], Memory = memories[4], Processor = processors[3], Type = types[0], Detail = new Detail { price = 1999.90f, Discount = 0, StockSize = 12 } });
            computers.Add(new Computer { ID = 1, Brand = brands[1], Name = brands[1].Name, MadeIn = countries[0], Ram = rams[2], GraphicCard = graphicCards[2], Memory = memories[2], Processor = processors[3], Type = types[0], Detail = new Detail { price = 2000, Discount = 10, StockSize = 2 } });
            computers.Add(new Computer { ID = 2, Brand = brands[3], Name = brands[3].Name, MadeIn = countries[2], Ram = rams[3], GraphicCard = graphicCards[1], Memory = memories[2], Processor = processors[1], Type = types[0], Detail = new Detail { price = 3000, Discount = 0, StockSize = 30 } });
            computers.Add(new Computer { ID = 3, Brand = brands[2], Name = brands[2].Name, MadeIn = countries[3], Ram = rams[0], GraphicCard = graphicCards[0], Memory = memories[0], Processor = processors[2], Type = types[1], Detail = new Detail { price = 4999.9f, Discount = 30, StockSize = 2 } });
            computers.Add(new Computer { ID = 4, Brand = brands[0], Name = brands[0].Name, MadeIn = countries[2], Ram = rams[1], GraphicCard = graphicCards[0], Memory = memories[3], Processor = processors[2], Type = types[0], Detail = new Detail { price = 7000, Discount = 0, StockSize = 2 } });
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
