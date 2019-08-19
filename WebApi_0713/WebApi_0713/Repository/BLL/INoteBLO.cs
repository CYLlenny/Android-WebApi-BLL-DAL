using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_0713.Models.DTO;
using WebApi_0713.ViewModels.NoteVM;

namespace WebApi_0713.Repository.BLL
{
    public interface INoteBLO
    {
        //READ
        IEnumerable<Note> GetNoteProc();
        //CREATE
        void CreateNoteProc(InNoteViewModel note);
        //UPDATE
        void UpdateNoteProc(InNoteViewModel note);
        //DELETE
        void DeleteNoteProc(InNoteViewModel note);

    }
}
