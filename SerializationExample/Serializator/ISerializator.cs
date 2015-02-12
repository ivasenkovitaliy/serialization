namespace SerializationExample.Services
{
    interface ISerializator<T>
    {
        void Serialize(T objectToSerialize, string fileName);

        T Deserialize(string fileName);
    }
}
