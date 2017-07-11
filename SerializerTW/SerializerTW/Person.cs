using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializerTW
{
    [Serializable]
    public class Person  : IDeserializationCallback
    {

        public string name { get; }
        public string phone { get; }
        public string address { get; }
        [NonSerialized]
        private int ID;
        private static int IDCounter = 0;
        private DateTime startDate;
        private static int currentID = 0;

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
            bool append = File.Exists(path) ? true : false;
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        public static Person DeSerialize(bool isNext)
        {
            if (isNext) currentID++;
            else currentID--;
            if (currentID < 0) currentID = 0;
            if (currentID == IDCounter) currentID = IDCounter - 1;
            using (Stream stream = File.Open(@"C:\cica\person"+currentID + ".dat", FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                object obj = binaryFormatter.Deserialize(stream);
                Person person = (Person)obj;

                return person;
            }
        }

        public static Person DeSerializeLast()
        {
            using (Stream stream = File.Open(@"C:\cica\person" +( IDCounter-1) + ".dat", FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                object obj = binaryFormatter.Deserialize(stream);
                Person person = (Person)obj;

                return person;
            }
        }


        public override String ToString()
        {
            string output = this.name;

            return "sonkkk";
        }

        public void OnDeserialization(object sender)
        {
            this.ID = IDCounter;
        }
    }
}
