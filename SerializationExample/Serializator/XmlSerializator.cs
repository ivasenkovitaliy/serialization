using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SerializationExample.Entities;
using SerializationExample.Services;

namespace SerializationExample.Serializator
{
    class XmlSerializator : ISerializator<Person>
    {
        public void Serialize(Person person, string fileName)
        {
            var xsSubmit = new XmlSerializer(typeof(Person));
            var stringWriter = new StringWriter();
            var writer = XmlWriter.Create(stringWriter);
            xsSubmit.Serialize(writer, person);
            var xml = stringWriter.ToString();

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var unicode = new UnicodeEncoding();
                var bytes = unicode.GetBytes(xml);
                int size = unicode.GetByteCount(xml);

                fileStream.Write(bytes, 0, size);
            }
        }

        public Person Deserialize(string fileName)
        {
            Person person;
            using (var stream = System.IO.File.OpenRead(fileName))
            {
                var serializer = new XmlSerializer(typeof(Person));
                person = serializer.Deserialize(stream) as Person;
            }

            return person;
        }
    }
}
