using GrpcServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataAccess
{
    public class FileDataContext : DbContext
    {
        public FileDataContext(DbContextOptions<FileDataContext> options) : base(options)
        {

        }

        public DbSet<Example> Examples { get; set; }
        public DbSet<FileEntity> FileEntity { get; set; }
    }
}
