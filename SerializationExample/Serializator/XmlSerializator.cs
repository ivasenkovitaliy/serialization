using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SerializationExample.Entities;
using SerializationExample.Services;

namespace SerializationExample.Serializator
{
    class XmlSerializator<T> : ISerializator<T> where T : class
    {
        public void Serialize<T>(T val, string fileName)
        {
            var xsSubmit = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            var writer = XmlWriter.Create(stringWriter);
            xsSubmit.Serialize(writer, val);
            var xml = stringWriter.ToString();

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var unicode = new UnicodeEncoding();
                var bytes = unicode.GetBytes(xml);
                int size = unicode.GetByteCount(xml);

                fileStream.Write(bytes, 0, size);
            }
        }

        public T Deserialize(string fileName)
        {
            T value;
            using (var stream = System.IO.File.OpenRead(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                value = serializer.Deserialize(stream) as T;
            }

            return value;
        }
    }
}
