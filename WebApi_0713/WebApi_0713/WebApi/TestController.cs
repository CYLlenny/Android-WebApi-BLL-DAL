using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_0713.Repository.BLL;
using WebApi_0713.ViewModels.NoteVM;
using WebApi_0713.ViewModels.UnitForm;

namespace WebApi_0713.WebApi
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private INoteBLO iNoteBLO; //物件指標宣告

         //ngrok http 2615 -host-header="localhost:2615" 

        /// <summary>
        /// 注入物件
        /// </summary>
        /// <param name="_iMasterBLO"></param>
        public TestController(INoteBLO _iNoteBLO)
        {
            iNoteBLO = _iNoteBLO;
        }

        //READ
        [HttpPost]
        public outUniResult Get_DB()
        {
            outUniResult _outUniResult = new outUniResult();
            try
            {           
                ///不可以把開資料庫的動作直接寫在WebApi這一層
                //IEnumerable<Master> _master = from x in _context.master
               //select x;
                _outUniResult.StatusCode = 200; //<--這種常式盡量不要出現
                _outUniResult.Result = iNoteBLO.GetNoteProc();
                _outUniResult.Error = null;

                return _outUniResult;
            }
            catch (Exception e)
            {
                ///例外處理要分兩塊，
                ///1.真正發生錯誤的部分，要送回資料庫讓工程師可以追蹤到
                ///2.送給前端的錯誤訊息，簡單就好
                _outUniResult.StatusCode = 404;
                _outUniResult.Result = "發生錯誤了";
                _outUniResult.Error = null;

                throw new Exception();
            }

        }

        //CREATE
        [HttpPost]
        public outUniResult Create_DB([FromBody] InNoteViewModel noteViewModel)
        {
            outUniResult _outUniResult = new outUniResult();
            try
            {
                iNoteBLO.CreateNoteProc(noteViewModel);
                _outUniResult.StatusCode = 200; //<--這種常式盡量不要出現
                _outUniResult.Result = null;
                _outUniResult.Error = null;
                return _outUniResult;
            }
            catch (Exception e)
            {          
                throw new Exception();
            }
        }

        [HttpPost]
        public outUniResult Update_DB([FromBody] InNoteViewModel noteViewModel)
        {
            outUniResult _outUniResult = new outUniResult();
            try
            {
                iNoteBLO.UpdateNoteProc(noteViewModel);
                _outUniResult.StatusCode = 200; //<--這種常式盡量不要出現
                _outUniResult.Result = null;
                _outUniResult.Error = null;
                return _outUniResult;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public outUniResult Delete_DB([FromBody] InNoteViewModel noteViewModel)
        {
            outUniResult _outUniResult = new outUniResult();
            try
            {
                iNoteBLO.DeleteNoteProc(noteViewModel);
                _outUniResult.StatusCode = 200; //<--這種常式盡量不要出現
                _outUniResult.Result = null;
                _outUniResult.Error = null;
                return _outUniResult;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }





    }
}