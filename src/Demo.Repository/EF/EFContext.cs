using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository.EF
{
    public class EFContext : DbContext
    {
        // public EFContext(DbContextOptions options)
        //     : base(options)
        // {
        // }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}