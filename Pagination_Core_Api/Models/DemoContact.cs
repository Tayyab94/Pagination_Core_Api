using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Core_Api.Models
{
    public class DemoContact :DbContext
    {

        public DemoContact(DbContextOptions<DemoContact> options): base(options)
        {
        }


       public DbSet<Customer> Customers { get; set; }
    }
}
