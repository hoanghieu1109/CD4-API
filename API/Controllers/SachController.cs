using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SachController : ControllerBase
    {
        private string _path;
        private ISachBusiness _SachBusiness;
        public SachController(ISachBusiness SachBusiness)
        {
            _SachBusiness = SachBusiness;
        }

        [Route("create-sach")]
        [HttpPost]
        public SachModel CreateSach([FromBody] SachModel model)
        {
            if (model.anhbia != null)
            {
                var arrData = model.anhbia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.anhbia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.masach = Guid.NewGuid().ToString();
            _SachBusiness.Create(model);
            return model;
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("delete-sach")]
        [HttpPost]
        public IActionResult DeleteSach([FromBody] Dictionary<string, object> formData)
        {
            string MaSach = "";
            if (formData.Keys.Contains("MaSach") && !string.IsNullOrEmpty(Convert.ToString(formData["MaSach"])))
            { MaSach = Convert.ToString(formData["MaSach"]); }
            _SachBusiness.Delete(MaSach);
            return Ok();
        }

        [Route("update-sach")]
        [HttpPost]
        public SachModel UpdateSach([FromBody] SachModel model)
        {
            if (model.anhbia != null)
            {
                var arrData = model.anhbia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.anhbia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _SachBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SachModel GetDatabyID(string id)
        {
            return _SachBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SachModel> GetDatabAll()
        {
            return _SachBusiness.GetDataAll();
        }
        [Route("sp-get-by-chude/{id}")]
        [HttpGet]
        public List<SachModel> GetDataByChuDe(string id)
        {
            return _SachBusiness.GetDataByChuDe(id);
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel phantrang([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
               
                long total = 0;
                var data = _SachBusiness.phantrang(page, pageSize, out total);
                response.TotalSachs = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
