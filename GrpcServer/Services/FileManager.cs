using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class FileManager
    {
        private static FileManager manager;

        private Dictionary<int, MyFile> files_storage;
        
        public static FileManager GetFileManager()
        {
            manager = new FileManager();
            return manager;
        }

        private FileManager()
        {
               
        }
        public void FilePushBack(Id id,MyFile file)
        {
            files_storage.Add(id.Id_,file);
        }

        public MyFile GetFileById(Id id)
        {
            return files_storage[id.Id_];
        }

        public Id CreateFile(MyFile file)
        {
            int newid = 0;
            while(!files_storage.ContainsKey(newid))
            {
                ++newid;
            }
            files_storage.Add(newid,file);
            Id id = new Id();
            id.Id_ = newid;
            return id;
        }



    }
}
