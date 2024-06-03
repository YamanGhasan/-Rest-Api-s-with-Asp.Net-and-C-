using quotesApiCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace quotesApiCourse.Data
{
    public class QuotesDbContext : DbContext  // this class is responsible to work with database 
    {
        public DbSet<Quote> Quotes   { get; set; }
    }
} 