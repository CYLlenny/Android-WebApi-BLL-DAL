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
using Android_0713.Models.BLL;
using Android_0713.Models.DAL;
using Android_0713.Repository.BLL;
using Android_0713.Repository.DAL;
using Autofac;

namespace Android_0713.Factory
{
 
    class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NoteBLO>().As<INoteBLO>();
            builder.RegisterType<NoteDAO>().As<INoteDAO>();
        }
    }
}