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
   // [Route("[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class APIRaftsController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;


        public APIRaftsController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

        [Route("GetRaft")]
        [HttpGet]
        public ActionResult GetRaft()
        {
            var data = (from a in db.Raft.Where(a => a.RaftBusinessId == a.RaftBusiness.BusinessId)
                        .Include(b => b.RaftBusiness).ToList()
                        select new
                        {
                            RaftId = a.RaftId,
                            RaftName = a.RaftName,
                            RaftDetails = a.RaftDetails,
                            RaftPrice = a.RaftPrice,
                            RaftImage = a.RaftImage,
                            BusinessId = a.RaftBusiness.BusinessId,
                            BusinessName = a.RaftBusiness.BusinessName,
                            BusinessTel = a.RaftBusiness.BusinessTel,
                            BusinessEmail = a.RaftBusiness.BusinessEmail,
                            BusinessIdline = a.RaftBusiness.BusinessIdline,
                            BusinessBank = a.RaftBusiness.BusinessBank,
                            BusinessAccountnumber = a.RaftBusiness.BusinessAccountnumber,
                            BusinessAddress = a.RaftBusiness.BusinessAddress,
                            BusinessDistrict = a.RaftBusiness.BusinessDistrict,
                            BusinessProvince = a.RaftBusiness.BusinessProvince,
                            BusinessSubdistrict = a.RaftBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.RaftBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }

        [Route("GetRaftBusiness/{busId}")]
        [HttpGet]
        public ActionResult GetRaftBusiness(string busId)
        {
            var data = (from a in db.Raft.Where(a => a.RaftBusinessId == busId)
                        .Include(b => b.RaftBusiness).ToList()
                        select new
                        {
                            RaftId = a.RaftId,
                            RaftName = a.RaftName,
                            RaftDetails = a.RaftDetails,
                            RaftPrice = a.RaftPrice,
                            RaftImage = a.RaftImage,
                            BusinessId = a.RaftBusiness.BusinessId,
                            BusinessName = a.RaftBusiness.BusinessName,
                            BusinessTel = a.RaftBusiness.BusinessTel,
                            BusinessEmail = a.RaftBusiness.BusinessEmail,
                            BusinessIdline = a.RaftBusiness.BusinessIdline,
                            BusinessBank = a.RaftBusiness.BusinessBank,
                            BusinessAccountnumber = a.RaftBusiness.BusinessAccountnumber,
                            BusinessAddress = a.RaftBusiness.BusinessAddress,
                            BusinessDistrict = a.RaftBusiness.BusinessDistrict,
                            BusinessProvince = a.RaftBusiness.BusinessProvince,
                            BusinessSubdistrict = a.RaftBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.RaftBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }


        [Route("GetRaft/{raftId}")]
        [HttpGet]
        public ActionResult GetRaft(String raftId)
        {
            var data = (from a in db.Raft.Where(a => a.RaftBusinessId == a.RaftBusiness.BusinessId && a.RaftId == raftId)
                        .Include(b => b.RaftBusiness).ToList()
                        select new
                        {
                            RaftId = a.RaftId,
                            RaftName = a.RaftName,
                            RaftDetails = a.RaftDetails,
                            RaftPrice = a.RaftPrice,
                            RaftImage = a.RaftImage,
                            BusinessId = a.RaftBusiness.BusinessId,
                            BusinessName = a.RaftBusiness.BusinessName,
                            BusinessTel = a.RaftBusiness.BusinessTel,
                            BusinessEmail = a.RaftBusiness.BusinessEmail,
                            BusinessIdline = a.RaftBusiness.BusinessIdline,
                            BusinessBank = a.RaftBusiness.BusinessBank,
                            BusinessAccountnumber = a.RaftBusiness.BusinessAccountnumber,
                            BusinessAddress = a.RaftBusiness.BusinessAddress,
                            BusinessDistrict = a.RaftBusiness.BusinessDistrict,
                            BusinessProvince = a.RaftBusiness.BusinessProvince,
                            BusinessSubdistrict = a.RaftBusiness.BusinessSubdistrict,
                            BusinessZipcode = a.RaftBusiness.BusinessZipcode,
                        }).ToList();
            return new JsonResult(data);

        }


        [Route("GetRaftService/{raftIdService}")]
        [HttpGet]
        public ActionResult GetRaftService(string raftIdService)
        {
            var data = (from r in db.DetailServices.Where(a => a.DetailservicesRaftId == raftIdService
                        && a.DetailservicesServicesId == a.DetailservicesServices.ServicesId)
                        .Include(s => s.DetailservicesServices).ToList()
                        select new
                        {
                            DetailservicesId = r.DetailservicesId,
                            ServicesId = r.DetailservicesServices.ServicesId,
                            ServicesName = r.DetailservicesServices.ServicesName,
                            ServicesPrice = r.DetailservicesServices.ServicesPrice,
                            ServicesImagePaht = r.DetailservicesServices.ServicesImagePaht,

                        }).ToList();

            return new JsonResult(data);

        }

        private bool RaftExists(string id)
        {
            return db.Raft.Any(e => e.RaftId == id);
        }
    }
}
