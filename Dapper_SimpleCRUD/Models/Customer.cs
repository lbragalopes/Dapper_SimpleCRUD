using Dapper.Contrib.Extensions;

namespace Dapper_SimpleCRUD.Models
{
    public class Customer
    {
       [Key]
        public int CostumerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
