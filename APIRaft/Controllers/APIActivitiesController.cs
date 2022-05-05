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
    public class APIActivitiesController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;

        public APIActivitiesController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

        // GET: api/APIActivities
        [Route("GetActivity")]
        [HttpGet]
        public ActionResult GetActivity()
        {
            var data = (from a in db.Activity.Where(a => a.ActivityBusinessId == a.ActivityBusiness.BusinessId )
                        .Include(b=>b.ActivityBusiness).Include(m=>m.ActivityBusiness.Map).ToList()
                        select new {
                            ActivityId = a.ActivityId,
                            ActivityName = a.ActivityName,
                            ActivityDetails = a.ActivityDetails,
                            ActivityImagePaht = a.ActivityImagePaht,
                            ActivityVideoPaht = a.ActivityVideoPaht,
                            BusinessName = a.ActivityBusiness.BusinessName,
                            BusinessTel = a.ActivityBusiness.BusinessTel,
                            BusinessEmail = a.ActivityBusiness.BusinessEmail,
                            BusinessIdline = a.ActivityBusiness.BusinessIdline,
                            BusinessBank = a.ActivityBusiness.BusinessBank,
                            BusinessAccountnumber = a.ActivityBusiness.BusinessAccountnumber,
                            BusinessAddress = a.ActivityBusiness.BusinessAddress,
                            BusinessDistrict = a.ActivityBusiness.BusinessDistrict,
                            BusinessProvince = a.ActivityBusiness.BusinessProvince,
                            BusinessSubdistrict = a.ActivityBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.ActivityBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);
            //return await db.Activity.ToListAsync();
           
        }

        [Route("GetActivity/{activityId}")]
        [HttpGet]
        public ActionResult GetActivity(string activityId)
        {
            var data = (from a in db.Activity.Where(a => a.ActivityId == activityId)
                        .Include(b => b.ActivityBusiness).ToList()
                        select new
                        {
                            ActivityId = a.ActivityId,
                            ActivityName = a.ActivityName,
                            ActivityDetails = a.ActivityDetails,
                            ActivityImagePaht = a.ActivityImagePaht,
                            ActivityVideoPaht = a.ActivityVideoPaht,
                            BusinessName = a.ActivityBusiness.BusinessName,
                            BusinessTel = a.ActivityBusiness.BusinessTel,
                            BusinessEmail = a.ActivityBusiness.BusinessEmail,
                            BusinessIdline = a.ActivityBusiness.BusinessIdline,
                            BusinessBank = a.ActivityBusiness.BusinessBank,
                            BusinessAccountnumber = a.ActivityBusiness.BusinessAccountnumber,
                            BusinessAddress = a.ActivityBusiness.BusinessAddress,
                            BusinessDistrict = a.ActivityBusiness.BusinessDistrict,
                            BusinessProvince = a.ActivityBusiness.BusinessProvince,
                            BusinessSubdistrict = a.ActivityBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.ActivityBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }


        private bool ActivityExists(string id)
        {
            return db.Activity.Any(e => e.ActivityId == id);
        }
    }
}
