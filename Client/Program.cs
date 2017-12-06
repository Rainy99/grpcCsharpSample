using System;
using Grpc.Core;
using Sample;

namespace Client
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var chnanel = new Channel("localhost:8080", ChannelCredentials.Insecure);
      var client = new UserService.UserServiceClient(chnanel);
      var result = client.GetUser(new NotFound());
      Console.WriteLine(result.ToString());
    }
  }
}