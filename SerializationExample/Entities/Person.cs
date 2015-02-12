using System;

namespace SerializationExample.Entities
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
