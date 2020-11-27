using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IComputer
    {
        public List<Computer> Computers();
        public Computer Computer(int ID);
        public List<Computer> Computers(Model.Type type);
        public List<Computer> Computers(Brand brand);
        public List<Computer> Computers(CPU cpu);
        public List<Computer> Computers(GraphicCard graphics);
        public List<Computer> Computers(Memory memory);
        public List<Computer> Computers(Model.RAM ram);
        

    }
}
