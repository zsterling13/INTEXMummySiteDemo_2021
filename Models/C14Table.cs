using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace INTEX2Mock.Models
{
    public partial class C14Table
    {
        //model for C14 table
        [Key]
        public string Id { get; set; }
        public string BurialLocation { get; set; }
        public int? Rack { get; set; }
        public int? NsLowPar { get; set; }
        public string Ns { get; set; }
        public string EwLowPair { get; set; }
        public string Ew { get; set; }
        public string Square { get; set; }
        public string Area { get; set; }
        public string Burial { get; set; }
        public int? Rack2 { get; set; }
        public string Tube { get; set; }
        public string Description { get; set; }
        public int? SizeMl { get; set; }
        public string Foci { get; set; }
        public string C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string QuestionS { get; set; }
        public string Column19 { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public int? _14cCalendarDate { get; set; }
        public int? Calibrated95CalendarDateMax { get; set; }
        public int? Calibrated95CalendarDateMin { get; set; }
        public int? Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
    }
}
