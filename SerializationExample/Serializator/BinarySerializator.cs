using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SerializationExample.Entities;

namespace SerializationExample.Services
{
    class BinarySerializator<T> : ISerializator<T> where T:class 
    {
        public void Serialize<T>(T val, string fileName)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, val);
            }
        }

        public T Deserialize(string fileName)
        {
            T value;
            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                value = (T) binaryFormatter.Deserialize(fileStream);
            }

            return value;
        }
    }
}
