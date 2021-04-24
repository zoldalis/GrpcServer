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

        private Dictionary<int, MyFile> files_storage;

        private readonly FileDataContext _context;

        public FileManager(FileDataContext context)
        {
            files_storage = new Dictionary<int, MyFile>();

            _context = context;
        }
        
        public void FilePushBack(Id id,MyFile file)
        {

            files_storage.Add(id.NewId,file);
        }

        public MyFile GetFileById(Id id)
        {
            //_context.FileEntity.Add();

            _context.Examples.FirstOrDefault(x => x.Id == id.NewId);

            return files_storage[id.NewId];
        }

        public Id CreateFile(MyFile file)
        {
            _context.Examples.Add(new Models.Example());

            //_context.SaveChangesAsync

            int newid = 0;
            while(files_storage.ContainsKey(newid))
            {
                ++newid;
            }
            files_storage.Add(newid,file);
            Id id = new Id();
            id.NewId = newid;
            return id;
        }
    }
}
