using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_0713.Models.DTO;
using Android_0713.ViewModels.NoteVM;

namespace Android_0713.Repository.BLL
{
    public interface INoteBLO
    {
        List<Note> GetNoteProc();

        void CreateNoteProc(InNoteViewModel note);
        void UpdateNoteProc(InNoteViewModel note);
        void DeleteNoteProc(InNoteViewModel note);

    }
}