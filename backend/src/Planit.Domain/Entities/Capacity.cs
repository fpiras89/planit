﻿namespace Planit.Domain.Entities;

public class Capacity
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }

    public virtual Resource Resource { get; set; }
}