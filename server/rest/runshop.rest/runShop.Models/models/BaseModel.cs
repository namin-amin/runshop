using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace runShop.Models.models;
public class BaseModel
{
    public ulong Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}


