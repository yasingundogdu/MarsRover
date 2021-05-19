using MarsRover.Commands;
using MarsRover.CommandValidators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarsRover.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICalculateFinalPositionCommandValidator _calculateFinalPositionCommandValidator;
        public HomeController(IMediator mediator, ICalculateFinalPositionCommandValidator calculateFinalPositionCommandValidator)
        {
            _mediator = mediator;
            _calculateFinalPositionCommandValidator = calculateFinalPositionCommandValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Calculate")]
        public JsonResult Calculate([FromBody] CalculateFinalPositionCommand command)
        {
            var checkCoordinates = _calculateFinalPositionCommandValidator.PlateauCoordinatesValidator(command.PlateauCoordinates);
            var checkPositions = _calculateFinalPositionCommandValidator.RoverPositionValidator(command.RoverPosition);

            if (checkCoordinates.IsValid && checkPositions.IsValid)
            {
                ViewData["Output"] = _mediator.Send(command).Result;
            }
            else
            {
                ViewData["Output"] = $"{checkCoordinates.Message} {checkPositions.Message}"; 
            }

            return Json(JsonConvert.SerializeObject(ViewData["Output"]));
        }

    }
}
