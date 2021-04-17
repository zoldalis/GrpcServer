using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.Collections.Generic;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Id> replies = new List<Id>();
            Thread.Sleep(200);
            byte[] bytes =  {55,33,111,123,3 };
            byte[] bytes1 = { 155, 33, 111, 123, 3 };
            byte[] bytes2 = { 255, 33, 161, 0, 3 };
            byte[] bytes3 = { 65, 73, 101, 123, 3 };
            Google.Protobuf.ByteString sendingfile = Google.Protobuf.ByteString.CopyFrom(bytes);
            Google.Protobuf.ByteString sendingfile1 = Google.Protobuf.ByteString.CopyFrom(bytes1);
            Google.Protobuf.ByteString sendingfile2 = Google.Protobuf.ByteString.CopyFrom(bytes2);

            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            Console.WriteLine("Accessing to server...");
            var reply = await client.CreateFileAsync(
                              new MyFile { Name = "FileExample.dat", Description = "this is file example", File = sendingfile
                              });
            replies.Add(await client.CreateFileAsync(
                              new MyFile
                              {
                                  Name = "Image2.png",
                                  Description = "this is an image",
                                  File = sendingfile1
                              }));
            replies.Add(await client.CreateFileAsync(
                              new MyFile
                              {
                                  Name = "FileExxxxample.dat",
                                  Description = "this is file exxxxample",
                                  File = sendingfile2
                              }));
            replies.Add(await client.CreateFileAsync(
                              new MyFile
                              {
                                  Name = "FileExample.txt",
                                  Description = "this is text file example",
                                  File = sendingfile
                              }));
            for(int i = 0; i < 100; i ++)
            {
                replies.Add(await client.CreateFileAsync(
                              new MyFile
                              {
                                  Name = "FileExample.txt",
                                  Description = "this is text file example",
                                  File = sendingfile
                              }));
            }
            MyFile ff = await client.GetFileAsync(
                             new Id
                             {
                                 NewId=2
                             });
            foreach (var item in replies)
            {
                Console.WriteLine($"Id is: {item.NewId}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        } 
    }
}
