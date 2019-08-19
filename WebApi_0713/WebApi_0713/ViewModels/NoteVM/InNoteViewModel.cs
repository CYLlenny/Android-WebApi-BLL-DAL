using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_0713.Models.DTO;

namespace WebApi_0713.ViewModels.NoteVM
{
    public class InNoteViewModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }
    }
}
