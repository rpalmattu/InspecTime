using InspecTime.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InspecTime.Data
{
    public class Tools_ProgramContext : DbContext
    {
        private DbModelBuilder modelBuilder;

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Tools_ProgramContext() : base("name=Tools_ProgramContext")
        {
            Database.SetInitializer<Tools_ProgramContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
