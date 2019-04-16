using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using Chinook.Domain.Supervisor;
using Chinook.Domain.ApiModels;

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
        [Produces(typeof(List<TrackApiModel>))]
        public async Task<ActionResult<List<TrackApiModel>>> Get(CancellationToken ct = default)
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
        [Produces(typeof(TrackApiModel))]
        public async Task<ActionResult<TrackApiModel>> Get(int id, CancellationToken ct = default)
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
        [Produces(typeof(List<TrackApiModel>))]
        public async Task<ActionResult<TrackApiModel>> GetByAlbumId(int id, CancellationToken ct = default)
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
        [Produces(typeof(List<TrackApiModel>))]
        public async Task<ActionResult<TrackApiModel>> GetByMediaTypeId(int id, CancellationToken ct = default)
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
        [Produces(typeof(List<TrackApiModel>))]
        public async Task<ActionResult<TrackApiModel>> GetByGenreId(int id, CancellationToken ct = default)
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
        [Produces(typeof(TrackApiModel))]
        public async Task<ActionResult<TrackApiModel>> Post([FromBody] TrackApiModel input,
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
        [Produces(typeof(TrackApiModel))]
        public async Task<ActionResult<TrackApiModel>> Put(int id, [FromBody] TrackApiModel input,
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