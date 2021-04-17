using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public interface IFileManager
    {
        void FilePushBack(Id id, MyFile file);

        MyFile GetFileById(Id id);

        Id CreateFile(MyFile file);
    }
}
