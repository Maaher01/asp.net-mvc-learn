using Day_10_Work_01.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Day_10_Work_01.ViewModels
{
    public class WorkerViewModel
    {
        public int WorkerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public Trade Trade { get; set; }
        [Required, StringLength(20)]
        public string Contact { get; set; }
        [Required, StringLength(40)]
        public string Picture { get; set; }
        [Required, DataType(DataType.Currency), Display(Name ="Pay rate/day"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? PayRate { get; set; }
        [Required, DataType(DataType.Date), Display(Name ="Started on"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Ended on"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }
        [Display(Name ="Total days")]
        public int? DaysWorked
        {
            get=> EndDate.HasValue ? (EndDate - StartDate).Value.Days + 1: 0;

        }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? Payment
        {
            get=> DaysWorked.Value*PayRate.Value;
        }
    }
}