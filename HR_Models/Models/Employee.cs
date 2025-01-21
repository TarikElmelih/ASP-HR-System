using HR_Models.EnumClass;
using HR_Models.Models.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class Employee: Entity
    {
        public string Name { get; set; }
        public string Father { get; set; }
        public string LastName { get; set; }
        public string Mather { get; set; }
        public DateTime BirthDate { get; set; } 
        public DateTime date_of_employment { get; set; }
        public int? Age { get; set; } 
        public decimal Salary_basis { get; set; }
        public University_degree UniversityDegree { get; set; }
        public string Functional_ID { get; set; }
        public List<Department> departments { get; set; } = new List<Department>();
        public bool IsActive { get; set; } = true;
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }
        public Guid UniverCityId { get; set; }

        [ForeignKey(nameof(UniverCityId))]
        public UniverCity? UniverCity { get; set; }
        public List<Salary> salaries { get; set; } = new List<Salary>();
        public List<Vacation> vacations { get; set; } = new List<Vacation>();
        public List<Leave_Balances> leave_Balances { get; set; } = new List<Leave_Balances>();
        public List<Rewards> rewards { get; set; } = new List<Rewards>();
        public List<Penalties> penalties { get; set; } = new List<Penalties>();



        public Employee() {
        }
    }
}
