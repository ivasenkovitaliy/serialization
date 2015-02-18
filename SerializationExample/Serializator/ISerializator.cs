namespace SerializationExample.Services
{
    interface ISerializator<T>
    {
        void Serialize<T>(T objectToSerialize, string fileName);

        T Deserialize(string fileName);
    }
}
