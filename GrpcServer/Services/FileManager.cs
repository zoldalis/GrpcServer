using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace GrpcServer.Services
{
    public class FileManager : IFileManager
    {

        private Dictionary<int, MyFile> files_storage;
        
        public FileManager()
        {
            files_storage = new Dictionary<int, MyFile>();

            var cs = "Host=localhost;Username=postgres;Password=s$cret;Database=testdb";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DROP TABLE IF EXISTS files";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE files(id SERIAL PRIMARY KEY, 
                    name VARCHAR(255), price INT)";

            cmd.CommandText = "INSERT INTO files(name, price) VALUES('filename.dat',52642)";
            cmd.ExecuteNonQuery();
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
