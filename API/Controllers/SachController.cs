using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private ISachBusiness _SachBusiness;
        public SachController(ISachBusiness SachBusiness)
        {
            _SachBusiness = SachBusiness;
        }

        //[Route("create-Sach")]
        //[HttpPost]
        //public SachModel CreateSach([FromBody] SachModel model)
        //{
        //    _SachBusiness.Create(model);
        //    return model;
        //}

        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public SachModel GetDatabyID(string id)
        //{
        //    return _SachBusiness.GetDatabyID(id);
        //}
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SachModel> GetDatabAll()
        {
            return _SachBusiness.GetDataAll();
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
