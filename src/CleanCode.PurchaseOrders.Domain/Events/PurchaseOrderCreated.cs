using CleanCode.PurchaseOrders.Domain.Entities;
using CleanCode.Shared.Abstractions.Domain;

namespace CleanCode.PurchaseOrders.Domain.Events;

public record PurchaseOrderCreated(PurchaseOrder PurchaseOrder) : IDomainEvent;