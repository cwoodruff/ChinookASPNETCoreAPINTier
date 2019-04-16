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
    public class InvoiceLineController : Controller
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public InvoiceLineController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<InvoiceLineApiModel>))]
        public async Task<ActionResult<List<InvoiceLineApiModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await _chinookSupervisor.GetAllInvoiceLineAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(InvoiceLineApiModel))]
        public async Task<ActionResult<InvoiceLineApiModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var invoiceLine = await _chinookSupervisor.GetInvoiceLineByIdAsync(id, ct);
                if ( invoiceLine == null)
                {
                    return NotFound();
                }

                return Ok(invoiceLine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("invoice/{id}")]
        [Produces(typeof(List<InvoiceLineApiModel>))]
        public async Task<ActionResult<InvoiceLineApiModel>> GetByInvoiceId(int id, CancellationToken ct = default)
        {
            try
            {
                var invoice = await _chinookSupervisor.GetInvoiceByIdAsync(id, ct);
                if ( invoice == null)
                {
                    return NotFound();
                }

                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("track/{id}")]
        [Produces(typeof(List<InvoiceLineApiModel>))]
        public async Task<ActionResult<InvoiceLineApiModel>> GetByArtistId(int id, CancellationToken ct = default)
        {
            try
            {
                var track = await _chinookSupervisor.GetTrackByIdAsync(id, ct);
                if (track == null)
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

        [HttpPost]
        [Produces(typeof(InvoiceLineApiModel))]
        public async Task<ActionResult<InvoiceLineApiModel>> Post([FromBody] InvoiceLineApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _chinookSupervisor.AddInvoiceLineAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(InvoiceLineApiModel))]
        public async Task<ActionResult<InvoiceLineApiModel>> Put(int id, [FromBody] InvoiceLineApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _chinookSupervisor.GetInvoiceLineByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _chinookSupervisor.UpdateInvoiceLineAsync(input, ct))
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
                if (await _chinookSupervisor.GetInvoiceLineByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _chinookSupervisor.DeleteInvoiceLineAsync(id, ct))
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