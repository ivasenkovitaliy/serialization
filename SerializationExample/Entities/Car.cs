using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationExample.Entities
{
    [Serializable]
    public class Car
    {
        public string CarName { get; set; }
        public int CarCost { get; set; }
    }
}
