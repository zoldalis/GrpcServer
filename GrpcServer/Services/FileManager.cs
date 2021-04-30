using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.DataAccess;
using Npgsql;

namespace GrpcServer.Services
{
    public class FileManager : IFileManager
    {


        private readonly FileDataContext _context;

        public FileManager(FileDataContext context)
        {

            _context = context;
        }
        

        public MyFile GetFileById(Id id)
        {
            Models.FileEntity file = _context.FileEntity.FirstOrDefault(x => x.Id == id.NewId);
            MyFile myfile = new MyFile();
            myfile.Name = file.FileName;
            myfile.File = Google.Protobuf.ByteString.CopyFrom(file.Data);
            myfile.Description = file.Description;
            return myfile;
        }

        public Id CreateFile(MyFile file)
        {
            Models.FileEntity newfile = new Models.FileEntity();
            newfile.Data = file.File.ToByteArray();
            newfile.Description = file.Description;
            newfile.FileName = file.Name;
            _context.FileEntity.Add(newfile);
            _context.SaveChangesAsync();

            Id id = new Id();
            id.NewId = newfile.Id;
            return id;
        }
    }
}
