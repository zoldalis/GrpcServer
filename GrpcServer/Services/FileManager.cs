using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class FileManager : IFileManager
    {
        private static FileManager manager;

        private Dictionary<int, MyFile> files_storage;
        
        public FileManager()
        {
            files_storage = new Dictionary<int, MyFile>();
        }
        
        public void FilePushBack(Id id,MyFile file)
        {
            files_storage.Add(id.NewId,file);
        }

        public MyFile GetFileById(Id id)
        {
            return files_storage[id.NewId];
        }

        public Id CreateFile(MyFile file)
        {
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
