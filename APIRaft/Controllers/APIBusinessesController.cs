using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRaft.Data;
using APIRaft.Models;
using Microsoft.AspNetCore.Hosting;

namespace APIRaft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIBusinessesController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;

        public APIBusinessesController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }



        [Route("GetBusinessOrderRaft/{busId}")]
        [HttpGet]
        public ActionResult GetBusinessOrderRaft(string busId)
        {
            var data = (from a in db.Business.Where(a => a.BusinessId == busId).ToList()
                        select new
                        {
                            BusinessId = a.BusinessId,
                            BusinessName = a.BusinessName,
                            BusinessTel = a.BusinessTel,
                            BusinessEmail = a.BusinessEmail,
                            BusinessIdline = a.BusinessIdline,
                            BusinessBank = a.BusinessBank,
                            BusinessAccountnumber = a.BusinessAccountnumber,
                            BusinessAddress = a.BusinessAddress,
                            BusinessDistrict = a.BusinessDistrict,
                            BusinessProvince = a.BusinessProvince,
                            BusinessSubdistrict = a.BusinessSubdistrict,
                            BusinessZipcode = a.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }

        [Route("GetMap/{busId}")]
        [HttpGet]
        public ActionResult GetMap(string busId)
        {
            var data = (from a in db.Map.Where(a => a.MapBusinessId == busId).ToList()
                        select new
                        {
                            MapLatitude = a.MapLatitude,
                            MapLongitude = a.MapLongitude,
                        }).ToList();
            return new JsonResult(data);

        }

        private bool BusinessExists(string id)
        {
            return db.Business.Any(e => e.BusinessId == id);
        }
    }
}
