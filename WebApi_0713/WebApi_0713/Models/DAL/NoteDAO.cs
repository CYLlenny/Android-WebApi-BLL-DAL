using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_0713.Factory;
using WebApi_0713.Models.DTO;
using WebApi_0713.Repository.DAL;
using WebApi_0713.ViewModels.NoteVM;

namespace WebApi_0713.Models.DAL
{
    [DependencyRegister]
    public class NoteDAO : INoteDAO
    {
        private readonly MyDBContext _context;

        public NoteDAO(MyDBContext context)
        {
            _context = context;
        }

        //READ
        public IEnumerable<Note> GetNotes()
        {
            try
            {
                IEnumerable<Note> _note =
                    from x in _context.note select x;
                return _note;
            }
            catch(Exception e)
            {
                throw new Exception();
            }
        }

        //CREATE
        public void CreateNote(Note note)
        {
            try
            {
                _context.note.Add(note);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //UPDATE
        public void UpdateNote(Note note)
        {
            try
            {        
                var data = _context.note.FirstOrDefault(t => t.Id == note.Id);

                data.Id = note.Id;
                data.Date = note.Date;
                data.Value1 = note.Value1;
                data.Value2 = note.Value2;

                _context.note.Update(data);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception();
            }
        }

        //DELETE
        public void DeleteNote(Note note)
        {
            try
            {
                var data = _context.note.FirstOrDefault(t => t.Id == note.Id);
                _context.note.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception e)
            { 
                throw new Exception();
            }
        }

    }
}
