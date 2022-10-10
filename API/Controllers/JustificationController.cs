using API.EmpAttendance.Contracts.Justifications;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using AutoMapper;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JustificationController : ControllerBase
    {
        private readonly IJustificationService _justificationService;
        private readonly ILogger<JustificationController> _logger;
        private readonly IMapper _mapper;

        public JustificationController(IJustificationService justificationService, ILogger<JustificationController> logger, IMapper mapper)
        {
            _justificationService = justificationService;
            _logger = logger;
            _mapper = mapper;
        }

        // POST api/Justifications
        [ProducesDefaultResponseType(typeof(AddJustificationResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddJustification(AddJustificationRequest request)
        {
            try
            {
                var justification = _mapper.Map<Justification>(request.Justification);

                justification.JustificationId = await _justificationService.AddJustification(justification);
                if (justification.JustificationId <= 0)
                    return BadRequest();
                
                return CreatedAtAction(
                    actionName: nameof(GetJustification),
                    routeValues: new { id = justification.JustificationId },
                    value: new AddJustificationResponse(
                        JustificationId: justification.JustificationId));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(AddJustification)}");
                return Problem();
            }
        }

        // GET api/Justifications/{{id}}
        [ProducesDefaultResponseType(typeof(GetJustificationResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJustification(int id)
        {
            try
            {
                var justification = await _justificationService.GetJustification(id);
                if (justification != null)
                    return Ok(new GetJustificationResponse(
                        Justification: _mapper.Map<JustificationDTO>(justification)
                    ));

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetJustification)}");
                return Problem();
            }
        }

        // GET api/Justifications/Employee/{{id}}
        [ProducesDefaultResponseType(typeof(GetJustificationListByEmpIdResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Employee/{id:int}")]
        public async Task<IActionResult> GetJustificationListByEmpId(int id)
        {
            try
            {
                var justifications = await _justificationService.GetJustificationsByEmpId(id);
                if (justifications != null)
                    return Ok(new GetJustificationListByEmpIdResponse(
                        Justifications: _mapper.Map<List<JustificationDTO>>(justifications)
                    ));
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(GetJustificationListByEmpId)}");
                return Problem();
            }
        }


        // PUT api/Justifications/{{id}}
        [ProducesDefaultResponseType(typeof(AcceptJustificationResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> AcceptJustification(AcceptJustificationRequest request)
        {
            try
            {
                if (!request.Justification.Accepted)
                    return BadRequest(new AcceptJustificationResponse(
                            Status: "Failure: Acceptance status of the justification was not changed"));

                var justification = _mapper.Map<Justification>(request.Justification);

                if (await _justificationService.AcceptJustification(justification.JustificationId))
                    return Ok(new AcceptJustificationResponse(
                            Status: "Success"));
                
                return NotFound(new AcceptJustificationResponse(
                            Status: "Failure"));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(AcceptJustification)}");
                return Problem();
            }
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType(typeof(GetJustificationListResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _justificationService.List();
                if (list != null)
                    return Ok(new GetJustificationListResponse(list));
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error at {nameof(List)}");
                return Problem();
            }
        }

    }
}
