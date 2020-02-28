using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api;

namespace Vehicles.GrpcService.Services
{
    public class MyVehiclesService : Api.VehiclesService.VehiclesServiceBase
    {
        private readonly ILogger<MyVehiclesService> logger;

        public MyVehiclesService(ILogger<MyVehiclesService> logger)
        {
            this.logger = logger;
        }

        public override Task<AddMeasureResponse> AddMeasure(AddMeasureRequest request, ServerCallContext context)
        {
            logger.LogInformation($"{request.FuelLevel} L {request.Speed} km/h");

            var response = new AddMeasureResponse { IsConfirmed = true };

            return Task.FromResult(response);
        }
    }
}
