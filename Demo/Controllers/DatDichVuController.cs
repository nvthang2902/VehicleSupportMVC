using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Common;
using Demo.Models;
using Newtonsoft.Json.Linq;

namespace Demo.Controllers
{
    public class DatDichVuController : Controller

    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: DatDichVu
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Phuong thguc Add item vao gio hang
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.DichVus.SingleOrDefault(s => s.IdDV == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowtoCart", "DatDichVu");
        }
        //Trang gio hang
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "DatDichVu");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_DichVu"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity(id_pro, quantity);
            return RedirectToAction("ShowtoCart", "DatDichVu");
        }
        public ActionResult Update_Quantity_CartDemo(FormCollection form)
        {
            string[] quantities = form.GetValues("Quantity");
            List<CartItem> cart = (List < CartItem >) Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                cart[i]._shopping_quantity = Convert.ToInt32(quantities[i]);
            Session["cart"] = cart;
            return RedirectToAction("ShowtoCart", "DatDichVu");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowtoCart", "DatDichVu");
        }
        //method checkout
        public ActionResult CheckOutDichVu(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            SuDungDichVu _datDichVu = new SuDungDichVu();
            _datDichVu.TenTK = form["TenTK"];
            _datDichVu.ThoiGianDat = DateTime.Now;
            _datDichVu.DiaChiDat = form["DiaChiDat"];
            _datDichVu.MoTa = form["MoTa"];
            
            _db.SuDungDichVus.Add(_datDichVu);
            foreach (var item in cart.Items)
            {
                ChiTietSuDungDV _chiTietSuDung = new ChiTietSuDungDV();
                _chiTietSuDung.IdSDDV = _datDichVu.IdSDDV;
                _chiTietSuDung.IdDV = item._shopping_product.IdDV;
                _chiTietSuDung.GiaDV = item._shopping_product.GiaDV;
                _chiTietSuDung.SoLuongDV = item._shopping_quantity;
                _db.ChiTietSuDungDVs.Add(_chiTietSuDung);
            }
            _db.SaveChanges();
            return RedirectToAction("DatThanhCong", "DatDichVu");
        }
        public ActionResult DatThanhCong()
        {
            return View();
        }

        public ActionResult ShowToCartTest()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCartTest", "DatDichVu");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Payment()
        {
            Cart cart = Session["Cart"] as Cart;
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOMOYR20220512";
            string accessKey = "tKDG70PVNu3zMusn";
            string serectkey = "SwzdUTM6xZ8eKRWbV5hEJTWRk2OlMjPm";
            string orderInfo = "DH"+DateTime.Now.ToString("yyyyMMddHHmmss");
            string returnUrl = "http://localhost:59595/DatDichVu/DatThanhCong";
            string notifyurl = "http://ba1adf48beba.ngrok.io/DatDichVu/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = cart.Total_Money().ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //string param = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature")-1);
            //param = Server.UrlDecode(param);
            //MoMoSecurity crypto = new MoMoSecurity();
            //string serectkey = "SwzdUTM6xZ8eKRWbV5hEJTWRk2OlMjPm";
            //string signature = crypto.signSHA256(param, serectkey);
            
            //if(signature != Request["signature"].ToString())
            //{
            //    ViewBag.message = "Thông tin Request không hợp lệ!";
            //    return View();
            //}
            //if (!Request.QueryString["errorCode"].Equals("0"))
            //{
            //    ViewBag.message = "Thanh toán thất bại!";

            //}
            //else
            //{
            //    ViewBag.message = "Thanh toán thành công!";
            //    Session["Cart"] = new Cart();
            //}

            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db
        }
    }


}

