using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_0713.Models.DTO;
using Android_0713.Repository.DAL;
using Android_0713.ViewModels.UnitForm;
using Newtonsoft.Json;

namespace Android_0713.Models.DAL
{
    public class NoteDAO : INoteDAO
    {
        HttpClient _client;
        public NoteDAO()
        {
            _client = new HttpClient();
        }

        
        public List<Note> GetNotes()
        {
            try
            {
                var webClient = new System.Net.WebClient();
               // var result = webClient.DownloadString("http://1a6ea6f2.ngrok.io/api/Test/Get_DB");
                var result = webClient.UploadString("http://1a6ea6f2.ngrok.io/api/Test/Get_DB", "POST");

                OutUniResult datalist = new OutUniResult();
                JsonConvert.PopulateObject(result, datalist);
                List<Note> myObject = new List<Note>();
                myObject = datalist.Result;

                return myObject;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //CREATE
        public void CreateNote(Note note)
        {
            try
            {
                var webClient = new System.Net.WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                var result = webClient.UploadString("http://1a6ea6f2.ngrok.io/api/Test/Create_DB", "POST", JsonConvert.SerializeObject(note));
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //CREATE
        public void UpdateNote(Note note)
        {
            try
            {
                var webClient = new System.Net.WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                var result = webClient.UploadString("http://1a6ea6f2.ngrok.io/api/Test/Update_DB", "POST", JsonConvert.SerializeObject(note));
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        //CREATE
        public void DeleteNote(Note note)
        {
            try
            {
                var webClient = new System.Net.WebClient();
                webClient.Headers.Add("Content-Type", "application/json");
                var result = webClient.UploadString("http://1a6ea6f2.ngrok.io/api/Test/Delete_DB", "POST", JsonConvert.SerializeObject(note));
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}