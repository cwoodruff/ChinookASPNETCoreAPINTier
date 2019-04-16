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
    public class PlaylistController : Controller
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public PlaylistController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<PlaylistApiModel>))]
        public async Task<ActionResult<List<PlaylistApiModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await _chinookSupervisor.GetAllPlaylistAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(PlaylistApiModel))]
        public async Task<ActionResult<PlaylistApiModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var playList = await _chinookSupervisor.GetPlaylistByIdAsync(id, ct);
                if ( playList == null)
                {
                    return NotFound();
                }

                return Ok(playList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(PlaylistApiModel))]
        public async Task<ActionResult<PlaylistApiModel>> Post([FromBody] PlaylistApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _chinookSupervisor.AddPlaylistAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(PlaylistApiModel))]
        public async Task<ActionResult<PlaylistApiModel>> Put(int id, [FromBody] PlaylistApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _chinookSupervisor.GetPlaylistByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _chinookSupervisor.UpdatePlaylistAsync(input, ct))
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
                if (await _chinookSupervisor.GetPlaylistByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _chinookSupervisor.DeletePlaylistAsync(id, ct))
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