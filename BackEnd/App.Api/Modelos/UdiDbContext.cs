using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Api.Modelos{
    public class UdiDbContext : DbContext{

        public UdiDbContext(DbContextOptionsExtensions): base(options){

        }


    }

}