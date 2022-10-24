using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.PurchaseOrders.Application.DTO;
using CleanCode.PurchaseOrders.Infrastructure.EF.Models;

namespace CleanCode.PurchaseOrders.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PurchaseOrderDto AsDto(this PurchaseOrderReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                PurchaseOrderNumber = readModel.PurchaseOrderNumber,
                InvoiceItems = readModel.Items?.Select(po => new InvoiceItemDto
                {
                    Description = po.Description,
                    Quantity = po.Quantity,
                })!
            };
    }
}
