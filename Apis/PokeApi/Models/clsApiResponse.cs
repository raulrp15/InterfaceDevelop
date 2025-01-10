using ENT;

namespace DTO
{
    public class clsApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<clsPokemon> Results { get; set; }
    }
}

