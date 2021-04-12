using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace INTEX2Mock.Models
{
    public partial class BurialTable
    {
        [Key]
        public int BioSampleId { get; set; }
        public string LocationConcat { get; set; }
        public string Rack { get; set; }
        public string Bag { get; set; }
        public string LowNs { get; set; }
        public string HighNs { get; set; }
        public string Ns { get; set; }
        public string LowEw { get; set; }
        public string HighEw { get; set; }
        public string Ew { get; set; }
        public string Area { get; set; }
        public string BurialNumber { get; set; }
        public string Cluster { get; set; }
        public string Date { get; set; }
        public string PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }
        public string Notes2 { get; set; }
    }
}
