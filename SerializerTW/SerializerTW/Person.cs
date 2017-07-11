using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTW
{
    [Serializable]
    public class Person
    {

        private string name;
        private string phone;
        private string address;
        [NonSerialized]
        private int ID;
        private static int IDCounter =0;
        private DateTime startDate;

        public Person(string name, string phone, string address)
        {
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.ID = IDCounter++;
            this.startDate = DateTime.Now;
        }


        public void Serialize()
        {
            string path = @"C:\cica\person" + this.ID + ".dat";
            // Create and use a BinaryFormatter object to perform the serialization 
            bool append = File.Exists(path) ? true : false;
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        override
        public string ToString()
        {
            string output = this.name;

            return "";
        }
    }
}
