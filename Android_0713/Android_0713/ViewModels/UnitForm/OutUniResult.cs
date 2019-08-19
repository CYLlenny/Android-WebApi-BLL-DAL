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
using Android_0713.Models.DTO;

namespace Android_0713.ViewModels.UnitForm
{
    public class OutUniResult
    {
        public int StatusCode { get; set; } //統一回傳的狀態碼
        public List<Note> Result { get; set; } //回傳的物件
        public object Error { get; set; } //統一回傳的錯誤訊息摘要
    }


}