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
    public class APIServicesController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;

        public APIServicesController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

        [Route("GetServices/{busId}")]
        [HttpGet]
        public ActionResult GetServices(string busId)
        {
            var data = (from a in db.Services.Where(a => a.SerBusinessId == busId)
                        .Include(b => b.SerBusiness).ToList()
                        select new
                        {
                            ServicesId = a.ServicesId,
                            ServicesName = a.ServicesName,
                            ServicesImagePaht = a.ServicesImagePaht,
                            ServicesPrice = a.ServicesPrice,
                            ServicesVedioPaht = a.ServicesVedioPaht,
                            ServicesDetails = a.ServicesDetails,
                            BusinessId = a.SerBusiness.BusinessId,
                            BusinessName = a.SerBusiness.BusinessName,
                            BusinessTel = a.SerBusiness.BusinessTel,
                            BusinessEmail = a.SerBusiness.BusinessEmail,
                            BusinessIdline = a.SerBusiness.BusinessIdline,
                            BusinessBank = a.SerBusiness.BusinessBank,
                            BusinessAccountnumber = a.SerBusiness.BusinessAccountnumber,
                            BusinessAddress = a.SerBusiness.BusinessAddress,
                            BusinessDistrict = a.SerBusiness.BusinessDistrict,
                            BusinessProvince = a.SerBusiness.BusinessProvince,
                            BusinessSubdistrict = a.SerBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.SerBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }

        private bool ServicesExists(string id)
        {
            return db.Services.Any(e => e.ServicesId == id);
        }
    }
}
