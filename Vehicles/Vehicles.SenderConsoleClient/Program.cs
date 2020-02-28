using Bogus;
using Grpc.Net.Client;
using System;
using Vehicles.Api;

namespace Vehicles.SenderConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Api.VehiclesService.VehiclesServiceClient(channel);

            var measures = new Faker<AddMeasureRequest>()
                .RuleFor(p => p.FuelLevel, f => f.Random.Float(0, 5))
                .RuleFor(p => p.Speed, f => f.Random.Float(0, 140))
                .GenerateForever();

            foreach (var measure in measures)
            {
                Console.WriteLine($"Send {measure.FuelLevel} {measure.Speed}");
                client.AddMeasure(measure);
            }
           

            
        }
    }
}
