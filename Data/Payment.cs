﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}
