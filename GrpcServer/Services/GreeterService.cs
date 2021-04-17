using Grpc.Core;
using GrpcServer.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IFileManager _fileManager;
        
        public GreeterService(ILogger<GreeterService> logger, IFileManager fileManager)
        {
            _logger = logger;
            _fileManager = fileManager;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<MyFile> GetFile(Id id, ServerCallContext context)
        {
            var file = _fileManager.GetFileById(id);

            return Task.FromResult(new MyFile
            {
                Name = file.Name,
                Description = file.Description,
                File = file.File
            }); ;
        }

        public override Task<Id> CreateFile(MyFile file, ServerCallContext context)
        {
            var newFile = _fileManager.CreateFile(file);

            return Task.FromResult(new Id
            {
                NewId = newFile.NewId
            }); ;
        }

    }


}
