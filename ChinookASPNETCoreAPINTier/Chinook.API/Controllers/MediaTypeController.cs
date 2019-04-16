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
    [ResponseCache(Duration = 604800)] // cache for a week
    public class MediaTypeController : Controller
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public MediaTypeController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<MediaTypeApiModel>))]
        [ResponseCache(Duration = 604800)] // cache for a week
        public async Task<ActionResult<List<MediaTypeApiModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await _chinookSupervisor.GetAllMediaTypeAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(MediaTypeApiModel))]
        public async Task<ActionResult<MediaTypeApiModel>> Get(int id, CancellationToken ct = default)
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

        [HttpPost]
        [Produces(typeof(MediaTypeApiModel))]
        public async Task<ActionResult<MediaTypeApiModel>> Post([FromBody] MediaTypeApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _chinookSupervisor.AddMediaTypeAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(MediaTypeApiModel))]
        public async Task<ActionResult<MediaTypeApiModel>> Put(int id, [FromBody] MediaTypeApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _chinookSupervisor.GetMediaTypeByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _chinookSupervisor.UpdateMediaTypeAsync(input, ct))
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
                if (await _chinookSupervisor.GetMediaTypeByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _chinookSupervisor.DeleteMediaTypeAsync(id, ct))
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