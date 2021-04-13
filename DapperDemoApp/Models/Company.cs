using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DapperDemoApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string PostCode { get; set; }

        public List<Employee>  Employees{ get; set; }

    }
}
