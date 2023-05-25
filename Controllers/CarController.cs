using cars_api.Application;
using cars_api.Application.Features.Cars.Commands;
using cars_api.Application.Features.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cars_api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getCars")]
        public async Task<ActionResult<List<CarDTO>>> Get()
        {
            return await _mediator.Send(new GetCars.carList());
        }

        [HttpPost("/createCar")]
        public async Task<ActionResult<Unit>> Post(CreateCar.Execute data)
        {
            return await _mediator.Send(data);
        }
    }
}
