using System;
using System.Collections.Generic;

public class MessageFeedback
{
    public int Id { get; set; }
    public int? ContactMessageId { get; set; }
    public string Type { get; set; } = string.Empty; 
    public string? AdminResponse { get; set; }
    public DateTime ReviewedAt { get; set; } = DateTime.Now;
}
