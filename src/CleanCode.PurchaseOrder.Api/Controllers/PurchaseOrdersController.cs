using CleanCode.PurchaseOrders.Application.Commands;
using CleanCode.PurchaseOrders.Application.DTO;
using CleanCode.PurchaseOrders.Application.Queries;
using CleanCode.Shared.Abstractions.Commands;
using CleanCode.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCode.PurchaseOrder.Api.Controllers
{
    public class PurchaseOrdersController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PurchaseOrdersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{purchaseOrderNumber}")]
        public async Task<ActionResult<PurchaseOrderDto>> Get([FromRoute] GetPurchaseOrder query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePurchaseOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new {purchaseOrderNumber = command.PurchaseOrderNumber}, null);
        }

        
        [HttpPut("{purchaseOrderNumber}/items")]
        public async Task<IActionResult> Put([FromBody] AddInvoiceItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
