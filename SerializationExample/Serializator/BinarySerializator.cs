using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SerializationExample.Entities;

namespace SerializationExample.Services
{
    /*class BinarySerializator : ISerializator<Person>
    {
        public void Serialize(Person person, string fileName)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, person);
            }
        }

        public Person Deserialize(string fileName)
        {
            Person person;
            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                person = (Person) binaryFormatter.Deserialize(fileStream);
            }

            return person;
        }
    }*/
}
