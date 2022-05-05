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
    public class APIPromotionsController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;
        public APIPromotionsController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

      

        [Route("GetPromotions/{busId}")]
        [HttpGet]
        public ActionResult GetPromotions(string busId)
        {
            var data = (from a in db.Promotion.Where(a => a.ProBusinessId == busId)
                        .Include(b => b.ProBusiness).Include(s=>s.PromotionStatus).ToList()
                        select new
                        {
                            PromotionId = a.PromotionId,
                            PromotionName = a.PromotionName,
                            PromotionImage = a.PromotionImage,
                            PromotionDetails = a.PromotionDetails,
                            PromotionDiscoun = a.PromotionDiscoun,
                            PromotionStartdate = a.PromotionStartdate,
                            PromotionLastdate = a.PromotionLastdate,
                            PromotionStatusId = a.PromotionStatusId,
                            SpromotionName = a.PromotionStatus.SpromotionName,
                            BusinessId = a.ProBusiness.BusinessId,
                            BusinessName = a.ProBusiness.BusinessName,
                            BusinessTel = a.ProBusiness.BusinessTel,
                            BusinessEmail = a.ProBusiness.BusinessEmail,
                            BusinessIdline = a.ProBusiness.BusinessIdline,
                            BusinessBank = a.ProBusiness.BusinessBank,
                            BusinessAccountnumber = a.ProBusiness.BusinessAccountnumber,
                            BusinessAddress = a.ProBusiness.BusinessAddress,
                            BusinessDistrict = a.ProBusiness.BusinessDistrict,
                            BusinessProvince = a.ProBusiness.BusinessProvince,
                            BusinessSubdistrict = a.ProBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.ProBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }

        private bool PromotionExists(string id)
        {
            return db.Promotion.Any(e => e.PromotionId == id);
        }
    }
}
