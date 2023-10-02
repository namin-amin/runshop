using System;
using System.Collections.Generic;
using System.Text;

namespace runShop.Models.models
{
    public class BaseModel
    {
        public ulong Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
    }
}
