using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data.SqlClient;
using System.Data;

namespace FashionShop.Models
{
    public class CartModel
    {
        private Provider provider = new Provider();
        
        public void save(string purchaseOrder, string ID, int quantity)
        {
            string sql = string.Format("Insert Into Details(ID, Product, Quantity, State) Values('{0}', '{1}', {2}, 1)", purchaseOrder, ID, quantity);
            this.provider.executeNonQuery(sql);
        }

        public void saveOrder(string user, string purchaseOrder)
        {
            string sql = string.Format("Insert Into PurchaseOrder(Customer, PurchaseOrder, Time, State) Values('{0}', '{1}', '{2}',  2)", user, purchaseOrder, DateTime.Now);
            this.provider.executeNonQuery(sql);
        }

        public Cart[] getCartByPurchaseOrder(string ID)
        {
            string sql = string.Format("Select Product, Quantity From Details Where ID = '{0}'", ID);
            DataTable result = this.provider.executeQuery(sql);
            Cart[] _cart = new Cart[result.Rows.Count];
            int index = 0;
            ProductModel productModel = new ProductModel();

            foreach (DataRow row in result.Rows)
            {
                Cart cart = new Cart();
                cart.Product = productModel.one(row["Product"].ToString());
                cart.Quantity = Int32.Parse(row["Quantity"].ToString());

                _cart[index] = cart;
                index++;
            }

            return _cart;
        }

        public void updateOrder(string purchaseOrder, string product, int quantity)
        {
            string sql = string.Format("Update Details Set Quantity = {0} Where ID = '{1}' And Product = '{2}'", quantity, purchaseOrder, product);
            this.provider.executeNonQuery(sql);
        }

        public void deleteOrder(string purchaseOrder, string product)
        {
            string sql = string.Format("Update Details Set State = 0 Where Id = '{0}' And Product = '{1}'", purchaseOrder, product);
            this.provider.executeNonQuery(sql);
        }
    }
}