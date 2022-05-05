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
using APIRaft.Models.Data;
using System.IO;

namespace APIRaft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIOrdersController : ControllerBase
    {
        private readonly RaftpjContext db;
        private readonly IWebHostEnvironment _environment;

        public APIOrdersController(RaftpjContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
        }

        [Route("GetOrder/{userId}")]
        [HttpGet]
        public ActionResult GetOrder(string userId)
        {
            var data = (from r in db.Order.Where(a =>
                        a.OrderPromotion.ProBusinessId == a.OrderPromotion.ProBusiness.BusinessId &&
                        a.OrderUserId == userId)
                        .Include(s => s.OrderStatus)
                        .Include(p => p.OrderPromotion)
                        .Include(b => b.OrderPromotion.ProBusiness)
                        .Include(u => u.OrderUser).ToList()
                        select new
                        {
                            UserId = r.OrderUser.UserId,
                            UserName = r.OrderUser.UserName,
                            OrderId = r.OrderId,
                            OrderDate = r.OrderDate,
                            OrderLastdate = r.OrderLastdate,
                            OrderPrice = r.OrderPrice,
                            OrderImageDeposit = r.OrderImageDeposit,
                            OrderDeposit = r.OrderDeposit,
                            OrderImagePay = r.OrderImagePay,
                            OrderPay = r.OrderPay,
                            SorderId = r.OrderStatus.SorderId,
                            SorderName = r.OrderStatus.SorderName,
                            PromotionId = r.OrderPromotionId,
                            PromotionName = r.OrderPromotion.PromotionName,
                            PromotionImage = r.OrderPromotion.PromotionImage,
                            PromotionDiscoun = r.OrderPromotion.PromotionDiscoun,
                            BusinessId = r.OrderPromotion.ProBusiness.BusinessId,
                            BusinessName = r.OrderPromotion.ProBusiness.BusinessName,
                            BusinessTel = r.OrderPromotion.ProBusiness.BusinessTel,
                            BusinessEmail = r.OrderPromotion.ProBusiness.BusinessEmail,
                            BusinessIdline = r.OrderPromotion.ProBusiness.BusinessIdline,
                            BusinessBank = r.OrderPromotion.ProBusiness.BusinessBank,
                            BusinessAccountnumber = r.OrderPromotion.ProBusiness.BusinessAccountnumber,
                            BusinessAddress = r.OrderPromotion.ProBusiness.BusinessAddress,
                            BusinessDistrict = r.OrderPromotion.ProBusiness.BusinessDistrict,
                            BusinessProvince = r.OrderPromotion.ProBusiness.BusinessProvince,
                            BusinessSubdistrict = r.OrderPromotion.ProBusiness.BusinessSubdistrict,
                            BusinessZipcode = r.OrderPromotion.ProBusiness.BusinessZipcode,
                        }).ToList();

            return new JsonResult(data);
        }



        [Route("GetOrderPay/{userId}")]
        [HttpGet]
        public ActionResult GetOrderPay(string userId)
        {
            var data = (from r in db.Order.Where(a =>
                        a.OrderPromotion.ProBusinessId == a.OrderPromotion.ProBusiness.BusinessId &&
                        a.OrderUserId == userId
                        && a.OrderStatusId == 1)
                        .Include(s => s.OrderStatus)
                        .Include(p => p.OrderPromotion)
                        .Include(b => b.OrderPromotion.ProBusiness)
                        .Include(u => u.OrderUser).ToList()
                        select new
                        {
                            UserId = r.OrderUser.UserId,
                            UserName = r.OrderUser.UserName,
                            OrderId = r.OrderId,
                            OrderDate = r.OrderDate,
                            OrderLastdate = r.OrderLastdate,
                            OrderPrice = r.OrderPrice,
                            OrderImageDeposit = r.OrderImageDeposit,
                            OrderDeposit = r.OrderDeposit,
                            OrderImagePay = r.OrderImagePay,
                            OrderPay = r.OrderPay,
                            SorderId = r.OrderStatus.SorderId,
                            SorderName = r.OrderStatus.SorderName,
                            PromotionId = r.OrderPromotionId,
                            PromotionName = r.OrderPromotion.PromotionName,
                            PromotionImage = r.OrderPromotion.PromotionImage,
                            PromotionDiscoun = r.OrderPromotion.PromotionDiscoun,
                            BusinessId = r.OrderPromotion.ProBusiness.BusinessId,
                            BusinessName = r.OrderPromotion.ProBusiness.BusinessName,
                            BusinessTel = r.OrderPromotion.ProBusiness.BusinessTel,
                            BusinessEmail = r.OrderPromotion.ProBusiness.BusinessEmail,
                            BusinessIdline = r.OrderPromotion.ProBusiness.BusinessIdline,
                            BusinessBank = r.OrderPromotion.ProBusiness.BusinessBank,
                            BusinessAccountnumber = r.OrderPromotion.ProBusiness.BusinessAccountnumber,
                            BusinessAddress = r.OrderPromotion.ProBusiness.BusinessAddress,
                            BusinessDistrict = r.OrderPromotion.ProBusiness.BusinessDistrict,
                            BusinessProvince = r.OrderPromotion.ProBusiness.BusinessProvince,
                            BusinessSubdistrict = r.OrderPromotion.ProBusiness.BusinessSubdistrict,
                            BusinessZipcode = r.OrderPromotion.ProBusiness.BusinessZipcode,
                        }).ToList();

            return new JsonResult(data);
        }





        [Route("GetOrderId/{orderId}")]
        [HttpGet]
        public ActionResult GetOrderId(string orderId)
        {
            var data = (from r in db.Order.Where(a =>
                        a.OrderId == orderId)
                        .Include(s => s.OrderStatus)
                        .Include(p => p.OrderPromotion)
                        .Include(b => b.OrderPromotion.ProBusiness)
                        .Include(u => u.OrderUser).ToList()
                        select new
                        {
                            UserId = r.OrderUser.UserId,
                            UserName = r.OrderUser.UserName,
                            OrderId = r.OrderId,
                            OrderDate = r.OrderDate,
                            OrderLastdate = r.OrderLastdate,
                            OrderPrice = r.OrderPrice,
                            OrderImageDeposit = r.OrderImageDeposit,
                            OrderDeposit = r.OrderDeposit,
                            OrderImagePay = r.OrderImagePay,
                            OrderPay = r.OrderPay,
                            SorderId = r.OrderStatus.SorderId,
                            SorderName = r.OrderStatus.SorderName,
                            PromotionId = r.OrderPromotionId,
                            PromotionName = r.OrderPromotion.PromotionName,
                            PromotionImage = r.OrderPromotion.PromotionImage,
                            PromotionDiscoun = r.OrderPromotion.PromotionDiscoun,
                            BusinessId = r.OrderPromotion.ProBusiness.BusinessId,
                            BusinessName = r.OrderPromotion.ProBusiness.BusinessName,
                            BusinessTel = r.OrderPromotion.ProBusiness.BusinessTel,
                            BusinessEmail = r.OrderPromotion.ProBusiness.BusinessEmail,
                            BusinessIdline = r.OrderPromotion.ProBusiness.BusinessIdline,
                            BusinessBank = r.OrderPromotion.ProBusiness.BusinessBank,
                            BusinessAccountnumber = r.OrderPromotion.ProBusiness.BusinessAccountnumber,
                            BusinessAddress = r.OrderPromotion.ProBusiness.BusinessAddress,
                            BusinessDistrict = r.OrderPromotion.ProBusiness.BusinessDistrict,
                            BusinessProvince = r.OrderPromotion.ProBusiness.BusinessProvince,
                            BusinessSubdistrict = r.OrderPromotion.ProBusiness.BusinessSubdistrict,
                            BusinessZipcode = r.OrderPromotion.ProBusiness.BusinessZipcode,
                        }).ToList();

            return new JsonResult(data);
        }




        [Route("GetOrderRaft/{orderraftid}")]
        [HttpGet]
        public ActionResult GetOrderRaft(string orderraftid)
        {
            var data = (from r in db.OrderDetails.Where(a =>
                            a.OrderDetailsOrderId == orderraftid &&
                            a.OrderDetailsRaftId == a.OrderDetailsRaft.RaftId)
                            .Include(p => p.OrderDetailsRaft)
                            .ToList()
                        select new
                        {
                            orderDetails_price = r.OrderDetailsPrice,
                            RaftName = r.OrderDetailsRaft.RaftName,
                            RaftPrice = r.OrderDetailsRaft.RaftPrice,
                            RaftImage = r.OrderDetailsRaft.RaftImage,

                        }).ToList();

            return new JsonResult(data);
        }

        [Route("GetOrderServices/{orderservicesid}")]
        [HttpGet]
        public ActionResult GetOrderServices(string orderservicesid)
        {
            var data = (from r in db.OrderServices.Where(a =>
                            a.OsOrderId == orderservicesid &&
                            a.OsServiceId == a.OsService.ServicesId)
                            .Include(p => p.OsService)
                            .ToList()
                        select new
                        {
                            ServicesName = r.OsService.ServicesName,
                            ServicesPrice = r.OsService.ServicesPrice,
                            ServicesImagePaht = r.OsService.ServicesImagePaht,

                        }).ToList();

            return new JsonResult(data);
        }

        private string AutoKey()
        {
            string Data = "";
            var id = db.Order.OrderByDescending(z => z.OrderId).FirstOrDefault();
            if (id == null)
            {
                return Data = "ORD00001";
            }
            else
            {
                var g = id.OrderId.Length;
                var length = g - 3;
                var lastz = id.OrderId.Substring(3, length);
                return Data = "ORD" + (Convert.ToInt32(lastz) + 1).ToString("D5");

            }

        }

        private string AutoKeyDetails()
        {
            string Data = "";
            var id = db.OrderDetails.OrderByDescending(z => z.OrderDetailsId).FirstOrDefault();
            if (id == null)
            {
                return Data = "ODT00001";
            }
            else
            {
                var g = id.OrderDetailsId.Length;
                var length = g - 3;
                var lastz = id.OrderDetailsId.Substring(3, length);
                return Data = "ODT" + (Convert.ToInt32(lastz) + 1).ToString("D5");

            }

        }

        private string AutoKeyDetailService()
        {
            string Data = "";
            var id = db.OrderServices.OrderByDescending(z => z.OsId).FirstOrDefault();
            if (id == null)
            {
                return Data = "ODS00001";
            }
            else
            {
                var g = id.OsId.Length;
                var length = g - 3;
                var lastz = id.OsId.Substring(3, length);
                return Data = "ODS" + (Convert.ToInt32(lastz) + 1).ToString("D5");
                //assessment.AssessmentID = "AS" + (Convert.ToInt32(lastassessment.AssessmentID.Substring(2, lastassessment.AssessmentID.Length - 2)) + 1).ToString("D5");
            }
        }


        //[Route("DepositeOrder")]
        //[HttpPost]
        //public async Task<ActionResult<Order>> DepositeOrder([FromBody] Order data)
        //{
        //    var keyID = AutoKey();
        //    var Order = new Order()
        //    {
        //        OrderId = keyID,
        //        OrderDate = data.OrderDate,
        //        OrderLastdate = data.OrderLastdate,
        //        OrderPrice = Convert.ToInt32(data.OrderPrice),
        //        OrderStatusId = 1,
        //        OrderUserId = data.OrderUserId,
        //        OrderPromotionId = data.OrderPromotionId,
        //        OrderDeposit = data.OrderDeposit,
        //        OrderImageDeposit = "",
        //        OrderPay = 0,
        //        OrderImagePay = "ยังไม่ได้ชำระเงินยอดคงเหลือ",
        //    };
        //    db.Order.Add(Order);
        //    db.SaveChanges();


        //    var AutoKeyDe = AutoKeyDetails();
        //    var OrderDetails = new OrderDetails()
        //    {
        //        OrderDetailsId = AutoKeyDe,
        //        OrderDetailsOrderId = keyID,
        //        //OrderDetailsPrice = orderDetails.OrderDetailsPrice,
        //        //OrderDetailsRaftId = orderDetails.OrderDetailsRaftId,
        //    };
        //    db.OrderDetails.Add(OrderDetails);
        //    db.SaveChanges();


        //    return base.StatusCode(200);
        //}

        [Route("SaveImage")]
        [HttpPost]
        public ActionResult SaveImage([FromForm] IFormFile files)
        {
            //var oldUser = db.User.AsNoTracking().FirstOrDefault(p => p.UserEmail.Equals(user.UserEmail));
            //if (oldUser == null) return NotFound();

            //#region ImageManageMent

            var pathSql = "/CS60/60123250114/Images/";
            var pathSaveSQL = "";
            //var pathDel = "/CS60/60123250114/Images/";
            string uniqueFileName = null;

            if (files?.Length > 0)
            {
                try
                {
                    var filename = "";
                    if (files.FileName != null)
                    {
                        filename = Path.GetFileName(files.FileName);
                    }
                    
                    string pathsave = "C:\\inetpub\\wwwroot\\CS60\\60123250114";
                    //string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                    string uploadsFolder = Path.Combine(pathsave, "Images");

                    uniqueFileName = /*Guid.NewGuid().ToString() + "_" +*/ filename;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    //}
                    pathSaveSQL = pathSql + filename;
                }
                catch (Exception ex)
                {
                    return CreatedAtAction(nameof(SaveImage), ex.ToString());
                }
            }
         
            return Ok(pathSaveSQL);
        }



        [Route("SaveImagePay")]
        [HttpPost]
        public ActionResult SaveImagePay([FromForm] IFormFile files)
        {
            //var oldUser = db.User.AsNoTracking().FirstOrDefault(p => p.UserEmail.Equals(user.UserEmail));
            //if (oldUser == null) return NotFound();

            //#region ImageManageMent

            var pathSql = "/CS60/60123250114/Images/";
            var pathSaveSQL = "";
            //var pathDel = "/CS60/60123250114/Images/";
            string uniqueFileName = null;

            if (files?.Length > 0)
            {
                try
                {
                    var filename = "";
                    if (files.FileName != null)
                    {
                        filename = Path.GetFileName(files.FileName);
                    }

                    string pathsave = "C:\\inetpub\\wwwroot\\CS60\\60123250114";
                    //string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                    string uploadsFolder = Path.Combine(pathsave, "Images");

                    uniqueFileName = /*Guid.NewGuid().ToString() + "_" +*/ filename;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    //}
                    pathSaveSQL = pathSql + filename;
                }
                catch (Exception ex)
                {
                    return CreatedAtAction(nameof(SaveImage), ex.ToString());
                }
            }

            return Ok(pathSaveSQL);
        }


        [Route("UpdateImage")]
        [HttpPut]
        public ActionResult UpdateImage([FromForm] IFormFile files, [FromForm] Order order, [FromForm] string sumtotal)
        {
            var oldOrder = db.Order.AsNoTracking().FirstOrDefault(p => p.OrderId.Equals(order.OrderId));
            if (oldOrder == null) return NotFound();

            //#region ImageManageMent

            var pathSql = "/CS60/60123250114/Images/";
            var pathSaveSQL = "";
            //var pathDel = "/CS60/60123250114/Images/";
            string uniqueFileName = null;

            if (files?.Length > 0)
            {
                try
                {
                    var filename = "";
                    if (files.FileName != null)
                    {
                        filename = Path.GetFileName(files.FileName);
                    }

                    string pathsave = "C:\\inetpub\\wwwroot\\CS60\\60123250114";
                    //string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                    string uploadsFolder = Path.Combine(pathsave, "Images");

                    uniqueFileName = /*Guid.NewGuid().ToString() + "_" +*/ filename;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    //}
                    pathSaveSQL = pathSql + filename;
                }
                catch (Exception ex)
                {
                    return CreatedAtAction(nameof(SaveImage), ex.ToString());
                }
            }

            try
            {
                order.OrderId = oldOrder.OrderId;
                order.OrderDate = oldOrder.OrderDate;
                order.OrderLastdate = oldOrder.OrderLastdate;
                order.OrderPrice = oldOrder.OrderPrice;
                order.OrderImageDeposit = oldOrder.OrderImageDeposit;
                order.OrderDeposit = oldOrder.OrderDeposit;

                order.OrderImagePay = pathSaveSQL;
                order.OrderPay = Convert.ToInt32(sumtotal);
                order.OrderStatusId = 3;
                order.OrderUserId = oldOrder.OrderUserId;
                order.OrderPromotionId = oldOrder.OrderPromotionId;
                db.Order.Update(order);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CreatedAtAction(nameof(UpdateImage), e.ToString());
            }

            return Ok(pathSaveSQL);
        }


        [Route("ConfirmOrder")]
        [HttpPost]
        public ActionResult ConfirmOrder([FromBody] GetOrder getOrder)
        {
            string cus = getOrder.userid;
            string idpro = null;
            var dataOrder = db.Order.ToList();
            var CheckData = dataOrder.Where(x => x.OrderDate == getOrder.date).ToList();
            var count = CheckData.Count();

            string DRaft = getOrder.raft.Replace("[", "").Replace("]", "").Replace(" ", "");
            string DService = getOrder.services.Replace("[", "").Replace("]", "").Replace(" ", "");

            var RaftID = DRaft.Split(',');
            var ServiceID = DService.Split(',');

            if (count == 0)
            {
                var keyID = AutoKey();
                var Order = new Order()
                {
                    OrderId = keyID,
                    OrderDate = getOrder.date,
                    OrderLastdate = getOrder.datelast,
                    OrderPrice = Convert.ToInt32(getOrder.price),

                    OrderStatusId = 1,
                    OrderUserId = cus,

                    OrderDeposit = Convert.ToInt32(getOrder.deposit),
                    OrderImageDeposit = getOrder.Pathfile,
                    OrderPay = 0,
                    OrderImagePay = "/CS60/60123250114/Images/NullPay.png",
                    OrderPromotionId = getOrder.iDPro
                };
                db.Order.Add(Order);
                db.SaveChanges();

                foreach (var item1 in ServiceID)
                {
                    var AutoKeyDeSer = AutoKeyDetailService();
                    OrderServices OrderServices = new OrderServices()
                    {
                        OsId = AutoKeyDeSer,
                        OsOrderId = keyID,
                        OsServiceId = item1
                    };
                    db.OrderServices.Add(OrderServices);
                    db.SaveChanges();
                }


                foreach (var item in RaftID)
                {

                    var AutoKeyDe = AutoKeyDetails();


                    OrderDetails DetailOrder = new OrderDetails()
                    {
                        OrderDetailsId = AutoKeyDe,
                        OrderDetailsOrderId = keyID,
                        OrderDetailsRaftId = item,
                        OrderDetailsPrice = Convert.ToInt32(getOrder.price)

                    };


                    db.OrderDetails.Add(DetailOrder);
                    db.SaveChanges();

                }


                return base.StatusCode(200);
            }
            else
            {
                return base.StatusCode(500);
            }

        }

        private bool OrderExists(string id)
        {
            return db.Order.Any(e => e.OrderId == id);
        }
    }
}