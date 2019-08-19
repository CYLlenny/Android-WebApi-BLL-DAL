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
using Android_0713.Repository.BLL;
using Android_0713.Repository.DAL;
using Android_0713.ViewModels.NoteVM;

namespace Android_0713.Models.BLL
{
    public class NoteBLO : INoteBLO
    {
        private INoteDAO inoteDAO;

        public NoteBLO(INoteDAO _inoteDAO)
        {
            inoteDAO = _inoteDAO;
        }

        public List<Note> GetNoteProc()
        {
            try
            {
                List<Note> _note = inoteDAO.GetNotes();
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
                Note note = new Note();

                note.Value1 = noteViewModel.Value1;
                note.Value2 = noteViewModel.Value2;

                inoteDAO.CreateNote(note);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //Update
        public void UpdateNoteProc(InNoteViewModel noteViewModel)
        {
            try
            {
                Note note = new Note();

                note.Value1 = noteViewModel.Value1;
                note.Value2 = noteViewModel.Value2;
                note.Id = noteViewModel.Id;

                inoteDAO.UpdateNote(note);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //Delete
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