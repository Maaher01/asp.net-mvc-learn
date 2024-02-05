using System;

namespace Employee_Management_System.Models
{
    public enum Position
    {
        Director,
        Officer,
        Staff
    }
    internal class Employee : Person
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public DateTime JoinDate {  get; set; }
        
        public Employee() { }
        public Employee(string name, DateTime dateOfBirth, int id, Position position, DateTime joinDate): base(name, dateOfBirth)
        {
            this.Id = id;
            this.Position = position;
            this.JoinDate = joinDate;
        }

        public override int Age()
        {
            return (((DateTime.Now - this.DateOfBirth).Days) / 365);
        }

        public override string Details()
        {
            return $"{base.Details()}, ID: {Id}, Position: {Position}, Joined: {JoinDate}";
        }
    }
}
