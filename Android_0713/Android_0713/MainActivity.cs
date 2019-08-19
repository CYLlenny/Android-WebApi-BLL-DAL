using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android_0713.Factory;
using Android_0713.Models.DTO;
using Android_0713.Repository.BLL;
using Android_0713.ViewModels.NoteVM;
using Autofac;
using Newtonsoft.Json;

namespace Android_0713
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        

        public MainActivity()
        {
        }

        private static ContainerBuilder ContainerBuilder { get; set; }
        HttpClient _client;
        List<Note> datalist;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            ContainerBuilder = new ContainerBuilder();
            ContainerBuilder.RegisterModule<AutofacConfig>();
            var container = ContainerBuilder.Build();
        
            Button Btn_InsertData  = FindViewById<Button>(Resource.Id.button1);
            Button Btn_SelectData  = FindViewById<Button>(Resource.Id.button2);
            Button Btn_UpdateData  = FindViewById<Button>(Resource.Id.button3);
            Button Btn_DeleteData  = FindViewById<Button>(Resource.Id.button4);

            //VALUE1 VALUE2
            EditText EditText1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText EditText2 = FindViewById<EditText>(Resource.Id.editText2);
            //ID
            EditText EditText3 = FindViewById<EditText>(Resource.Id.editText3);


            //READ
            ListView listView1 = FindViewById<ListView>(Resource.Id.listView1);
            //ObservableCollection<Note> note2 = datalist;
            Btn_SelectData.Click += (s, e) =>
            {
                datalist = container.Resolve<INoteBLO>().GetNoteProc();
                //var myAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, datalist);
                //listView1.Adapter = myAdapter;
                listView1.Adapter = new CustomListAdapter(this, datalist);
                // listView1.ItemClick += listView_ItemClick;
                listView1.ItemClick += listView_Click;
                Toast.MakeText(this, "查詢成功", ToastLength.Long).Show();
            };

          
            //CREATE
            Btn_InsertData.Click +=  (s, e) =>
            {
                InNoteViewModel note = new InNoteViewModel(); 

                note.Value1 = EditText1.Text;
                note.Value2 = EditText2.Text;

                container.Resolve<INoteBLO>().CreateNoteProc(note);
                Toast.MakeText(this, "新增成功", ToastLength.Long).Show();
            };
            //UPDATE
            Btn_UpdateData.Click += (s, e) =>
            {
                InNoteViewModel note = new InNoteViewModel();
                note.Value1 = EditText1.Text;
                note.Value2 = EditText2.Text;

                Guid guid = Guid.Parse(EditText3.Text);
                note.Id = guid;
                container.Resolve<INoteBLO>().UpdateNoteProc(note);
                Toast.MakeText(this, "更新成功", ToastLength.Long).Show();
            };
            //DELETE
            Btn_DeleteData.Click += (s, e) =>
            {
                InNoteViewModel note = new InNoteViewModel();
                Guid guid = Guid.Parse(EditText3.Text);
                note.Id = guid;

                container.Resolve<INoteBLO>().DeleteNoteProc(note);
                Toast.MakeText(this, "刪除成功", ToastLength.Long).Show();
            };


        }

        void listView_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}

