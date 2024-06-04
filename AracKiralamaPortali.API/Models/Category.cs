using Microsoft.AspNetCore.Http.HttpResults;

namespace AracKiralamaPortali.Models

{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Cars> Cars { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
