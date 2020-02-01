using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestPlaner.models;

namespace TestPlaner.Data
{
    public class TestPlanContext : DbContext
    {
        public TestPlanContext (DbContextOptions<TestPlanContext> options)
            : base(options)
        {
        }

        public DbSet<TestPlaner.models.TestCase> TestCase { get; set; }
        public DbSet<TestPlaner.models.TestSuite> TestSuite { get; set; }
        public DbSet<TestPlaner.models.User> Users { get; set; }
    }
}
