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
        public async Task<ActionResult<List<TrackViewModel>>> Get(CancellationToken ct = default)
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
        public async Task<ActionResult<TrackViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var track = await _chinookSupervisor.GetTrackByIdAsync(id, ct);
                if ( track == null)
                {
                    return NotFound();
                }

                return Ok(track);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("album/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<ActionResult<TrackViewModel>> GetByAlbumId(int id, CancellationToken ct = default)
        {
            try
            {
                var album = await _chinookSupervisor.GetAlbumByIdAsync(id, ct);
                if ( album == null)
                {
                    return NotFound();
                }

                return Ok(album);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("mediatype/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<ActionResult<TrackViewModel>> GetByMediaTypeId(int id, CancellationToken ct = default)
        {
            try
            {
                var mediaType = await _chinookSupervisor.GetMediaTypeByIdAsync(id, ct);
                if ( mediaType == null)
                {
                    return NotFound();
                }

                return Ok(mediaType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("genre/{id}")]
        [Produces(typeof(List<TrackViewModel>))]
        public async Task<ActionResult<TrackViewModel>> GetByGenreId(int id, CancellationToken ct = default)
        {
            try
            {
                var genre = await _chinookSupervisor.GetGenreByIdAsync(id, ct);
                if (genre == null)
                {
                    return NotFound();
                }

                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(TrackViewModel))]
        public async Task<ActionResult<TrackViewModel>> Post([FromBody] TrackViewModel input,
            CancellationToken ct = default)
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
        public async Task<ActionResult<TrackViewModel>> Put(int id, [FromBody] TrackViewModel input,
            CancellationToken ct = default)
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
        public async Task<ActionResult> Delete(int id, CancellationToken ct = default)
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