using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTCRApp.Models
{
    public class TestTCRModelContext : DbContext
    {
        public TestTCRModelContext(DbContextOptions<TestTCRModelContext> options) : base(options)
        {

        }

        public DbSet<TestTCRModel> testTCRModels { get; set; }
    }
}
