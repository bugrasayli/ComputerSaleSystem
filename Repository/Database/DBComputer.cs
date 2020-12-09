using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBComputer : IComputer
    {
        private readonly IDB db;
        private List<Computer> computers;
        SqlConnection con;
        public DBComputer(IDB _db)
        {
            this.db = _db;
            computers = new List<Computer>();
        }
        public Computer Computer(int ID)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers()
        {
            SqlConnection con = this.db.getDB();
            con.Open();
            string SqlString = "select Computer.ID,Computer.Name,Brand.ID,Brand.Name,GraphicCard.ID," +
                "GraphicCard.Brand,GraphicCard.Name,CPU.ID, CPU.Name, Detail.Price, Detail.Discount, Detail.Stocksize," +
                " Detail.Image, Detail.MoreInfo,Country.ID,Country.Name, Type.ID,Type.Name,Memory.ID,Memory.HDD,Memory.SSD,Ram.ID,Ram.Size from Computer INNER JOIN Brand on Computer.BrandID = Brand.ID inner " +
                "JOIN GraphicCard on Computer.GraphicID = GraphicCard.ID inner JOIN CPU on Computer.CPUID = CPU.ID " +
                "inner JOIN Detail on Computer.ID = Detail.ComputerID inner JOIN Country on Country.ID = Computer.CountryID inner join Type on Type.ID = Computer.TypeID inner join Memory on Computer.MemoryID=Memory.ID " +
                "inner join Ram on Ram.ID = Computer.RamID ";
            List<Computer> computers = new List<Computer>();
            computers = ComputersWithReader(SqlString);
            con.Close();
            return computers;
        }
        public List<Computer> Computers(Model.Type type)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers(Brand brand)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers(CPU cpu)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers(GraphicCard graphics)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers(Memory memory)
        {
            throw new NotImplementedException();
        }
        public List<Computer> Computers(RAM ram)
        {
            throw new NotImplementedException();
        }


        public List<Computer> ComputersWithReader(String Query)
        {
            SqlConnection con = db.getDB();
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Computer> computers = new List<Computer>();
            while (reader.Read())
            {
                Computer computer = new Computer();
                computer.ID = Convert.ToInt32(reader[0]);
                computer.Name = reader[1].ToString();

                Brand brand = new Brand();
                brand.ID = Convert.ToInt32(reader[2]);
                brand.Name = reader[3].ToString();
                computer.Brand = brand;

                GraphicCard graphicCard = new GraphicCard();
                graphicCard.ID = Convert.ToInt32(reader[4]);
                graphicCard.Name = reader[5].ToString() + " " + reader[6].ToString();
                computer.GraphicCard = graphicCard;

                CPU cpu = new CPU();
                cpu.ID = Convert.ToInt32(reader[7]);
                cpu.Name = reader[8].ToString();
                computer.Processor = cpu;

                Detail detail = new Detail();
                detail.price = Convert.ToSingle(reader[9]);
                detail.Discount = Convert.ToInt32(reader[10]);
                detail.StockSize = Convert.ToInt32(reader[11]);
                detail.Image = reader[12].ToString();
                if (reader[13].ToString() != "")
                    detail.MoreInfo = reader[13].ToString();

                computer.Detail = detail;

                Country country = new Country();
                country.ID = Convert.ToInt32(reader[14]);
                country.Name = reader[15].ToString();
                computer.Country = country;


                Model.Type type = new Model.Type();
                type.ID = Convert.ToInt32(reader[16]);
                type.Name = (reader[17]).ToString();
                computer.Type = type;

                Memory memory = new Memory();
                memory.ID = Convert.ToInt32(reader[18]);
                memory.HDD = reader[19].ToString();
                memory.SSD = reader[20].ToString();
                computer.Memory = memory;

                RAM ram = new RAM();
                ram.ID = Convert.ToInt32(reader[21]);
                ram.Name = (reader[22]).ToString();
                computer.Ram = ram;
                computers.Add(computer);
            }
            return computers;


        }
    }
}
