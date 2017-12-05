using System;
using System.Threading.Tasks;
using Grpc.Core;
using Sample;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Grpc.Core.Server
            {
                Services = { UserService.BindService(new SampleImpl()) },
                Ports = { new ServerPort("localhost", 8080, ServerCredentials.Insecure) }
            };

            server.Start();
            Console.WriteLine("server running on localhost:8080");
            server.ShutdownTask.Wait();

    }
  }

    class SampleImpl : UserService.UserServiceBase
    {
        public override Task<User> GetUser(NotFound request, ServerCallContext context)
        {
            return Task.FromResult(new User { Id = 1, Name = "陌上花开" });
        }
    }
}
