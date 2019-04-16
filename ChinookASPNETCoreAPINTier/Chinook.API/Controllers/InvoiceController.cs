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
    public class InvoiceController : Controller
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public InvoiceController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<InvoiceApiModel>))]
        public async Task<ActionResult<List<InvoiceApiModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await _chinookSupervisor.GetAllInvoiceAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(InvoiceApiModel))]
        public async Task<ActionResult<InvoiceApiModel>> Get(int id, CancellationToken ct = default)
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

        [HttpGet("customer/{id}")]
        [Produces(typeof(List<InvoiceApiModel>))]
        public async Task<ActionResult<InvoiceApiModel>> GetByCustomerId(int id, CancellationToken ct = default)
        {
            try
            {
                if (await _chinookSupervisor.GetCustomerByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                return Ok(await _chinookSupervisor.GetInvoiceByCustomerIdAsync(id, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(InvoiceApiModel))]
        public async Task<ActionResult<InvoiceApiModel>> Post([FromBody] InvoiceApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _chinookSupervisor.AddInvoiceAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(InvoiceApiModel))]
        public async Task<ActionResult<InvoiceApiModel>> Put(int id, [FromBody] InvoiceApiModel input,
            CancellationToken ct = default)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _chinookSupervisor.GetInvoiceByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _chinookSupervisor.UpdateInvoiceAsync(input, ct))
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
                if (await _chinookSupervisor.GetInvoiceByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _chinookSupervisor.DeleteInvoiceAsync(id, ct))
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