# RG.SecurityPrincipal

Simple primitive types for implementing security principals, providing compile-time authorization for .NET applications.

## Overview

This library provides a convention-based approach to authorization where developers specify the required principal in every repository and service method as the first parameter. This enforces authorization at compile-time rather than runtime.

## Installation

```bash
dotnet add package RG.SecurityPrincipal
```

## Core Concepts

### ISecurityPrincipal

`ISecurityPrincipal` is the base interface for all principal types. All custom session/principal types should implement this interface.

```csharp
public sealed record CustomerSession : ISecurityPrincipal
{
    public required Guid CustomerId { get; init; }
}

public sealed record MerchantSession : ISecurityPrincipal
{
    public required Guid MerchantId { get; init; }
}
```

### Anyone

`Anyone` is a built-in principal that indicates a method can be called by anyone, without any authentication requirement.

```csharp
// Anyone can search for products
Task<PaginatedList<Product>> SearchAsync(
    Anyone anyone,
    string searchQuery,
    int page,
    int pageSize,
    CancellationToken cancellationToken);
```

Access the `Anyone` singleton via:
```csharp
SecurityPrincipal.Anyone
```

### Either

`Either<T1, T2, ...>` allows multiple principal types to call a method. It supports up to 10 type parameters and uses implicit conversion operators for convenient usage.

```csharp
// Both customers and merchants can view order details
Task<Order> GetOrderAsync(
    Either<CustomerSession, MerchantSession> principal,
    OrderId orderId,
    CancellationToken cancellationToken);
```

## Usage Examples

### Repository Pattern

```csharp
// Only customers can get their orders
Task<Order> GetAsync(
    CustomerSession customerSession,
    OrderId orderId,
    CancellationToken cancellationToken);

// Only merchants can ship orders
Task<ShippedOrder> ShipAsync(
    MerchantSession merchantSession,
    OrderId orderId,
    ShipmentDetails shipmentDetails,
    CancellationToken cancellationToken);

// Anyone can search for products
Task<PaginatedList<Product>> SearchAsync(
    Anyone anyone,
    string searchQuery,
    int page,
    int pageSize,
    CancellationToken cancellationToken);
```

### Service Layer

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;
    
    public async Task<Order> GetOrderAsync(
        CustomerSession session,
        OrderId orderId,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(session, orderId, cancellationToken);
    }
}
```

### Using Either for Multiple Principals

```csharp
public interface IOrderService
{
    // Both customers and support agents can view order history
    Task<List<Order>> GetOrderHistoryAsync(
        Either<CustomerSession, SupportAgentSession> principal,
        CustomerId customerId,
        CancellationToken cancellationToken);
}

// Usage - implicit conversion handles the type
public async Task HandleCustomerRequestAsync(CustomerSession session)
{
    var orders = await _orderService.GetOrderHistoryAsync(
        session, // Implicitly converts to Either<CustomerSession, SupportAgentSession>
        session.CustomerId,
        cancellationToken);
}
```

## Benefits

- **Compile-time Safety**: Authorization requirements are enforced at compile-time, preventing accidental unauthorized access.
- **Self-documenting**: Method signatures clearly indicate who can call each method.
- **Type-safe**: No magic strings or runtime attribute checks.
- **Flexible**: Support for multiple principal types via `Either` and public access via `Anyone`.

## License

MIT License - See [LICENSE](LICENSE) for details.
