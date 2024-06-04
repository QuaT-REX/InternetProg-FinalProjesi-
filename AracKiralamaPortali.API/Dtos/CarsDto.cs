using AracKiralamaPortali.Models;

namespace AracKiralamaPortali.Dtos
{
    public class CarsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
