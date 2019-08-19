using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_0713.Models.DTO;

namespace Android_0713.ViewModels.NoteVM
{
    public class InNoteViewModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }
    }
}