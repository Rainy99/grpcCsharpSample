using System;
using Grpc.Core;
using Sample;

namespace Client
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      const int PORT = 8080;
      var port = args.Length == 0 ? PORT : int.Parse(args[0]);
      var chnanel = new Channel($"localhost:{port}", ChannelCredentials.Insecure);
      var client = new UserService.UserServiceClient(chnanel);
      var result = client.GetUser(new NotFound());
      Console.WriteLine(result.ToString());
    }
  }
}