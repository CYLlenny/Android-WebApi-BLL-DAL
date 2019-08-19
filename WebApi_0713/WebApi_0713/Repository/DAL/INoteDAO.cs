using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_0713.Models.DTO;

namespace WebApi_0713.Repository.DAL
{
    public interface INoteDAO
    {
        //READ
         //CREATE
        void CreateNote(Note note);       IEnumerable<Note> GetNotes();

        //UPDATE
        void UpdateNote(Note note);
        //DELETE
        void DeleteNote(Note note);

    }
}
