using Day_10_Work_01.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Day_10_Work_01.ViewModels.Input
{
    public class WorkerEditModel
    {
        public int WorkerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public Trade Trade { get; set; }
        [Required, StringLength(20)]
        public string Contact { get; set; }
        
        public HttpPostedFileBase Picture { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Pay rate/day")]
        public decimal? PayRate { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Started on")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Currency), Display(Name = "Ended on")]
        public DateTime? EndDate { get; set; }
    }
}