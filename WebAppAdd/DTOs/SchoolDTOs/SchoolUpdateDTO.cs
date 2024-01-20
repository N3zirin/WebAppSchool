using Microsoft.Identity.Client;

namespace WebAppAdd.DTOs.SchoolDTOs
{
    public class SchoolUpdateDTO
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
