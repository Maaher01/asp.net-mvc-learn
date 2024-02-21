namespace Day_10_Work_01.Migrations
{
    using Day_10_Work_01.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Day_10_Work_01.Models.WorkerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Day_10_Work_01.Models.WorkerDbContext context)
        {
            if(!context.Workers.Any())
            {
                context.Workers.AddRange(new Worker[]
                {
                    new Worker{ Name="W1", Contact="01710XXXXXX", PayRate=900.00M, Picture="e1.jpeg", Trade=Trade.Painting, StartDate=new DateTime(2024, 2,2)},
                    new Worker{ Name="W2", Contact="01810XXXXXX", PayRate=950.00M, Picture="e2.jpeg", Trade=Trade.Plumbing, StartDate=new DateTime(2024, 2,2), EndDate=DateTime.Parse("2024-02-07")},
                    new Worker{ Name="W3", Contact="01910XXXXXX", PayRate=1200.00M, Picture="e3.jpg", Trade=Trade.Masonry, StartDate=new DateTime(2024, 1,30), EndDate=DateTime.Parse("2024-02-04")}
                });
                context.SaveChanges();
            }
            
        }
    }
}
