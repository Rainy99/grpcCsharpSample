using System;
using System.Threading.Tasks;
using Grpc.Core;
using Sample;

namespace Server
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      const int PORT = 8080;
      var port = args.Length == 0 ? PORT : int.Parse(args[0]);

      var server = new Grpc.Core.Server
      {
        Services = {UserService.BindService(new SampleImpl())},
        Ports = {new ServerPort("localhost", port, ServerCredentials.Insecure)}
      };

      server.Start();
      Console.WriteLine($"server running on localhost:{port}");
      server.ShutdownTask.Wait();
    }
  }

  internal class SampleImpl : UserService.UserServiceBase
  {
    public override Task<User> GetUser(NotFound request, ServerCallContext context)
    {
      return Task.FromResult(new User {Id = 1, Name = "陌上花开"});
    }
  }
}