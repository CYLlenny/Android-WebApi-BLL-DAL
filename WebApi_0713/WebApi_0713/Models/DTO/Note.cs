using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_0713.Models.DTO
{
    public class Note
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

    }
}
