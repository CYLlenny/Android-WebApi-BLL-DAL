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

namespace Android_0713.Repository.DAL
{
    public interface INoteDAO
    {
        List<Note> GetNotes();
        //CREATE
        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}