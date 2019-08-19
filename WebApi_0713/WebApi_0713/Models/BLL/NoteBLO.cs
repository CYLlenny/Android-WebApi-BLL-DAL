using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_0713.Factory;
using WebApi_0713.Models.DTO;
using WebApi_0713.Repository.BLL;
using WebApi_0713.Repository.DAL;
using WebApi_0713.ViewModels.NoteVM;

namespace WebApi_0713.Models.BLL
{
    [DependencyRegister]
    public class NoteBLO : INoteBLO
    {
        private INoteDAO inoteDAO;

        public NoteBLO(INoteDAO _inoteDAO)
        {
            inoteDAO = _inoteDAO;
        }


        //READ
        public IEnumerable<Note> GetNoteProc()
        {
            try
            {
                IEnumerable<Note> _note = inoteDAO.GetNotes();
                return _note;    
            }
            catch (Exception e)
            {

                throw new Exception();
            }
        }
        //CREATE
        public void CreateNoteProc(InNoteViewModel noteViewModel)
        {
            try
            {
                Guid guid = new Guid();
                DateTime dateTime = DateTime.UtcNow;
                
                Note note = new Note();
                note.Id = guid;
                note.Date = dateTime;
                note.Value1 = noteViewModel.Value1;
                note.Value2 = noteViewModel.Value2;
                inoteDAO.CreateNote(note);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //UPDATE
        public void UpdateNoteProc(InNoteViewModel noteViewModel)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow;
                Note note = new Note();
                note.Id = noteViewModel.Id;
                note.Date = dateTime;
                note.Value1 = noteViewModel.Value1;
                note.Value2 = noteViewModel.Value2;
                inoteDAO.UpdateNote(note);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //DELETE
        public void DeleteNoteProc(InNoteViewModel noteViewModel)
        {
            try
            {
                Note note = new Note();
                note.Id = noteViewModel.Id;
                inoteDAO.DeleteNote(note);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }



    }
}
