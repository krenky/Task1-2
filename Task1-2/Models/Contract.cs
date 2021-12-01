using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public Organisation Organisation { get; set; }
        public int OrganisationId { get; set; }
    }
}
