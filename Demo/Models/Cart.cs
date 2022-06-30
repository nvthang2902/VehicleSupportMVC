using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class CartItem
    {
        public DichVu _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }
    //Gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }

        }
        public void Add(DichVu _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.IdDV == _pro.IdDV);
            if (item == null)
            {
                items.Add(new CartItem{_shopping_product = _pro,_shopping_quantity = _quantity});
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.IdDV == id);
            if (item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.GiaDV * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.IdDV == id);
        }

    }
}