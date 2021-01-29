using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.ShoppingTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetim;

        public Cart()
        {
            _sepetim = new Dictionary<int, CartItem>();
        }

        //Sepet CartItem sınıfını da içinde tutar
        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetim.Values.ToList();
            }
        }

        //Sepete ekleme CartItem içindeki Amount propu sayesinde arttırma yapar
        public void SepeteEkle(CartItem item)
        {
            if (_sepetim.ContainsKey(item.ID))
            {
                _sepetim[item.ID].Amount += 1;
                return;
            }
            _sepetim.Add(item.ID, item);
        }

        //Amount sayesinde yine çıkarma yapılabilir
        public void SepettenSil(int id)
        {
            if (_sepetim[id].Amount > 1)
            {
                _sepetim[id].Amount--;
                return;
            }
            _sepetim.Remove(id);
        }

        //Sepetin Toplamı (CartItem classında Price*Amount çarpımından gelen fiyat)
        public decimal? TotalPrice
        {
            get
            {
                return _sepetim.Sum(x => x.Value.SubTotal);
            }
        }


    }
}