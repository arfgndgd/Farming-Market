using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.ShoppingTools
{
    public class Cart
    {
        Dictionary<int, CartItem> myCart;

        public Cart()
        {
            myCart = new Dictionary<int, CartItem>();
        }

        //Sepet CartItem sınıfını da içinde tutar
        public List<CartItem> MyCart
        {
            get
            {
                return myCart.Values.ToList();
            }
        }

        //Sepete ekleme CartItem içindeki Amount propu sayesinde arttırma yapar
        public void AddToCart(CartItem item)
        {
            if (myCart.ContainsKey(item.ID))
            {
                myCart[item.ID].Amount += 1;
                return;
            }
            myCart.Add(item.ID, item);
        }

        //Amount sayesinde yine çıkarma yapılabilir
        public void DeleteToCart(int id)
        {
            if (myCart[id].Amount > 1)
            {
                myCart[id].Amount--;
                return;
            }
            myCart.Remove(id);
        }

        //Sepetin Toplamı (CartItem classında Price*Amount çarpımından gelen fiyat)
        public decimal? TotalPrice
        {
            get
            {
                return myCart.Sum(x => x.Value.SubTotal);
            }
        }


    }
}