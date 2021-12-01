using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2.Models
{
    public class Organisation
    {
        ObservableCollection<Contract> contracts = new ObservableCollection<Contract>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ObservableCollection<Contract> Contracts { get => contracts; set => contracts = value; }
    }
}
