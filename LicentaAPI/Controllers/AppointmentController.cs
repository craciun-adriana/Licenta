using LicentaAPI.AppServices.Appointments;
using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/appointment")]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMappingCoordinator _mapper;

        public AppointmentController(IAppointmentService appointmentService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Appointment was created.")]
        [SwaggerResponse(404, "Appointment can't be created.")]
        public IActionResult CreateAppointment(AppointmentCreateRequest request)
        {
            var appointmentCreate = _mapper.Map<AppointmentCreateRequest, AppointmentCreate>(request);
            var appointment = _appointmentService.CreateAppointment(appointmentCreate);

            if (appointment == null)
            {
                return CreateResponse(500, new { Error = "DB error." });
            }
            return CreatedAtRoute("", new { appointment.ID }, appointment);
        }

        [AllowAnonymous]
        [HttpGet("get-appointment-for-user")]
        [SwaggerResponse(200, "All the user appointments.")]
        public IActionResult GetAllApointmentForUser()
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            return Ok(_appointmentService.GetAllAppointmentsForUser(idUser));
        }
    }
}