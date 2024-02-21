using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day_10_Work_01.Models
{
    public enum Trade {  Masonry=1, Plumbing, Painting, Carpentry}
    public class Worker
    {
        public int WorkerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public Trade Trade { get; set; }
        [Required, StringLength(20)]
        public string Contact {  get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; }
        [Required,Column(TypeName ="money")]
        public decimal? PayRate { get; set; }
        [Required,Column(TypeName ="date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
    }
    public class WorkerDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set;}
    }
}