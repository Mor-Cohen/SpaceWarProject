using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpaceWar.Classes
{
    public class Player
    {
        public int Cash { get; set; }
        public List<Spaceship> Ships { get; set; }
        public Spaceship UseShip { get; set; }
        public int BestLevel { get; set; }

        public Player()
        {
            Cash = 100000;
            var ship = new Spaceship("rocket1");
            UseShip = ship;
            Ships = new List<Spaceship>();
            Ships.Add(ship);
            BestLevel = 1;
        }

        public void WriteToJsonFile(string filePath, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(this);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public Player ReadFromJsonFile(string filePath)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Player>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }
    }
}
