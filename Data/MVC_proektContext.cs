using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_proekt.Models;

namespace MVC_proekt.Data
{
    public class MVC_proektContext : DbContext
    {
        public MVC_proektContext (DbContextOptions<MVC_proektContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_proekt.Models.Student>? Student { get; set; }

        public DbSet<MVC_proekt.Models.Professor>? Professor { get; set; }

        public DbSet<MVC_proekt.Models.Subject>? Subject { get; set; }

        public DbSet<MVC_proekt.Models.StudentSubject>? StudentSubject { get; set; }
    }
}
