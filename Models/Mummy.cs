using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models
{
    public class Mummy
    {
        [Key]
        public int MummyID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
