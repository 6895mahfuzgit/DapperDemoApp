
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

//using System.ComponentModel.DataAnnotations;

namespace DapperDemoApp.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key] //Dapper.Contrib.Extensions
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string PostCode { get; set; }

        [Write(false)]
        public List<Employee> Employees { get; set; }

    }
}
