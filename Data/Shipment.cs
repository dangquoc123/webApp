using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public DateTime ShipmentDate { get; set; }

    public int? CustomerId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
