using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Models
{
    public class FileEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }
    }
}
