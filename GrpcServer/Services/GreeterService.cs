using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public Task<MyFile> GetFile(Id id, ServerCallContext context)
        {
            return Task.FromResult(new MyFile
            {
                Name = FileManager.GetFileManager().GetFileById(id).Name,
                Description = FileManager.GetFileManager().GetFileById(id).Description,
                File = FileManager.GetFileManager().GetFileById(id).File
            }); ;
        }

        public Task<Id> Create(MyFile file, ServerCallContext context)
        {
            return Task.FromResult(new Id
            {
                //Id = FileManager.GetFileManager().CreateFile(file)
            }); ;
        }

    }


}
