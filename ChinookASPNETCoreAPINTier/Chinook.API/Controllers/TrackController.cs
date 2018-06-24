using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using Chinook.Domain.Supervisor;
using Chinook.Domain.ViewModels;

namespace Chinook.API.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : Controller
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public TrackController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<IActionResult> Get(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _chinookSupervisor.GetAllTrackAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(TrackViewModel))]
        public async Task<IActionResult> Get(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _chinookSupervisor.GetTrackByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }
                return Ok(await _chinookSupervisor.GetTrackByIdAsync(id, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("album/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<IActionResult> GetByAlbumId(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _chinookSupervisor.GetAlbumByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }
                return Ok(await _chinookSupervisor.GetTrackByAlbumIdAsync(id, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("mediatype/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<IActionResult> GetByMediaTypeId(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _chinookSupervisor.GetMediaTypeByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }
                return Ok(await _chinookSupervisor.GetTrackByMediaTypeIdAsync(id, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("genre/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<IActionResult> GetByGenreId(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _chinookSupervisor.GetGenreByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }
                return Ok(await _chinookSupervisor.GetTrackByGenreIdAsync(id, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(TrackViewModel))]
        public async Task<IActionResult> Post([FromBody]TrackViewModel input, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (input == null)
                    return BadRequest();
                
                return StatusCode(201, await _chinookSupervisor.AddTrackAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(TrackViewModel))]
        public async Task<IActionResult> Put(int id, [FromBody]TrackViewModel input, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _chinookSupervisor.GetTrackByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }
                var errors = JsonConvert.SerializeObject(ModelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _chinookSupervisor.UpdateTrackAsync(input, ct))
                {
                    return Ok(input);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(void))]
        public async Task<ActionResult> Delete(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _chinookSupervisor.GetTrackByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _chinookSupervisor.DeleteTrackAsync(id, ct))
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
