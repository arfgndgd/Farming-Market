using PagedList;
using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WebUI.Models.ShoppingTools;
using Project.WebUI.Models.ViewModels;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class ShoppingController : Controller
    {
        ProductRepository pRep;
        CategoryRepository cRep;
        OrderRepository oRep;
        OrderDetailRepository odRep;
        ShipperRepository sRep;

        public ShoppingController()
        {
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
            oRep = new OrderRepository();
            odRep = new OrderDetailRepository();
            sRep = new ShipperRepository();

        }

        // GET: Shopping

        //PagedList burada kullanıldı 
        public ActionResult ShoppingList(int? page, int? categoryID)
        {
            PAVM pavm = new PAVM
            {
                
                PagedProducts = categoryID == null ? pRep.GetActives().ToPagedList(page ?? 1,15) : pRep.Where(x=>x.CategoryID == categoryID).ToPagedList(page ?? 1,15),Categories =cRep.GetActives()
            };
            if (categoryID != null)
            {
                TempData["catID"] = categoryID;
            }

            return View(pavm);
        }

        //public ActionResult Search(string search)
        //{
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        pRep.Where(x => x.ProductName.StartsWith(search)).ToList();

        //    }
        //    return RedirectToAction("ShoppingList");
        //}

        public ActionResult AddToCart(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product addProduct = pRep.Find(id);

            CartItem ci = new CartItem
            {
                ID = addProduct.ID,
                Name = addProduct.ProductName,
                Price = addProduct.UnitPrice,
                ImagePath = addProduct.ImagePath
            };
            if (c.MyCart.Count == 0)
            {
                c.AddToCart(ci);
                Session["scart"] = c;
                return RedirectToAction("ShoppingList");
            }
            c.AddToCart(ci);
            Session["scart"] = c;

            return RedirectToAction("ShoppingList");
        }

        public ActionResult AddToCartCartPage(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product addProduct = pRep.Find(id);

            CartItem ci = new CartItem
            {
                ID = addProduct.ID,
                Name = addProduct.ProductName,
                Price = addProduct.UnitPrice,
                ImagePath = addProduct.ImagePath
            };
            if (c.MyCart.Count >=1)
            {
                c.AddToCart(ci);
                Session["scart"] = c;
                return RedirectToAction("CartPage");
            }
            c.AddToCart(ci);
            Session["scart"] = c;

            return RedirectToAction("ShoppingList");
        }

        public ActionResult CartPage()
        {
            if (Session["scart"] != null)
            {
                CartPageVM cpvm = new CartPageVM();
                Cart c = Session["scart"] as Cart;
                cpvm.Cart = c;
                return View(cpvm);
            }
            TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";
            return RedirectToAction("ShoppingList");
        }
        public ActionResult DeleteFromCart(int id)
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                c.DeleteToCart(id);
                if (c.MyCart.Count == 0)
                {
                    Session.Remove("scart");
                    TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";
                    return RedirectToAction("ShoppingList");
                }
                return RedirectToAction("CartPage");
            }
            return RedirectToAction("ShoppingList");
        }

        public ActionResult ProductDetail(int? id)
        {
          
            ProductVM pvm = new ProductVM
            {
                Product = pRep.FirstOrDefault(x => x.ID == id)
            };
            return View(pvm);
            
        }


        public ActionResult ConfirmOrder()
        {
            if (Session["scart"] != null)
            {
                AppUser mevcutKullanici;
                if (Session["member"] != null)
                {
                    mevcutKullanici = Session["member"] as AppUser;
                }
                else
                {
                    TempData["anonim"] = "Kullanıcı üye değil";
                }
                OrderVM ovm = new OrderVM
                {
                    Shippers = sRep.GetAll()
                };
                return View(ovm);
            }
            TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";
            return RedirectToAction("ShoppingList");
        }


        [HttpPost]
        public ActionResult ConfirmOrder(OrderVM ovm)
        {
            bool result;
            Cart sepet = Session["scart"] as Cart;


            ovm.Order.TotalPrice = ovm.PaymentVM.ShoppingPrice = sepet.TotalPrice.Value;
            TempData["sepetBos"] = "Sepetinizde ürün bulunmamaktadır";


            //API
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363/api/");

                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", ovm.PaymentVM);

                HttpResponseMessage sonuc;

                try
                {
                    sonuc = postTask.Result;
                }
                catch (Exception)
                {
                    TempData["baglantiRed"] = "Banka baglantıyı reddetti";
                    return RedirectToAction("ShoppingList");
                }
                if (sonuc.IsSuccessStatusCode)
                {
                    result = true;
                }
                else result = false;

                if (result)
                {
                    if (Session["member"] != null)
                    {
                        AppUser kullanici = Session["member"] as AppUser;
                        ovm.Order.AppUserID = kullanici.ID;
                        ovm.Order.UserName = kullanici.UserName;
                    }
                    else
                    {
                        ovm.Order.AppUserID = null;
                        ovm.Order.UserName = TempData["anonim"].ToString();
                    }

                    oRep.Add(ovm.Order); //OrderRepository bu noktada Order'i eklerken onun ID'sini olusturuyor...

                    foreach (CartItem item in sepet.MyCart)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderID = ovm.Order.ID;
                        od.ProductID = item.ID;
                        od.TotalPrice = item.SubTotal;
                        od.Quantity = item.Amount;
                        odRep.Add(od);

                        //Stoktan düsmesini istiyorsanız 
                        Product stokDus = pRep.Find(item.ID);
                        stokDus.UnitInStock -= item.Amount;
                        pRep.Update(stokDus);
                    }

                    TempData["odeme"] = "Siparişiniz bize ulasmıstır...Tesekkür ederiz";

                    MailSender.Send(ovm.Order.Email, body: $"Siparişiniz basarıyla alındı...{ovm.Order.TotalPrice}");

                    return RedirectToAction("ShoppingList");




                }

                else
                {
                    TempData["sorun"] = "Odeme ile ilgili bir sorun olustu..Lutfen bankanız iletişime geciniz";
                    return RedirectToAction("ShoppingList");
                }
            }

           
        }
    }
}