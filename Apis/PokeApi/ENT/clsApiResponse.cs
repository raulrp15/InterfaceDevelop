using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<clsPokemonResult> Results { get; set; }
    }

    public class clsPokemonResult()
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
