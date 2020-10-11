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
    public class ChuDeController : ControllerBase
    {
        private IChuDeBusiness _ChuDeBusiness;
        public ChuDeController(IChuDeBusiness ChuDeBusiness)
        {
            _ChuDeBusiness = ChuDeBusiness;
        }

        //[Route("create-ChuDe")]
        //[HttpPost]
        //public ChuDeModel CreateChuDe([FromBody] ChuDeModel model)
        //{
        //    _ChuDeBusiness.Create(model);
        //    return model;
        //}

        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public ChuDeModel GetDatabyID(string id)
        //{
        //    return _ChuDeBusiness.GetDatabyID(id);
        //}
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ChuDeModel> GetDatabAll()
        {
            return _ChuDeBusiness.GetDataAll();
        }

        //[Route("search")]
        //[HttpPost]
        //public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        //{
        //    var response = new ResponseModel();
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string ChuDe_group_id = "";
        //        if (formData.Keys.Contains("ChuDe_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["ChuDe_group_id"]))) { ChuDe_group_id = Convert.ToString(formData["ChuDe_group_id"]); }
        //        long total = 0;
        //        var data = _ChuDeBusiness.Search(page, pageSize,out total,  ChuDe_group_id);
        //        response.TotalChuDes = total;
        //        response.Data = data;
        //        response.Page = page;
        //        response.PageSize = pageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return response;
        //}

    }
}
