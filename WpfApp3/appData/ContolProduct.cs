using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.appData
{
    public class ContolProduct
    {
        public ObservableCollection<Products> Pr { get; set; }
        public ContolProduct()
        {
            Pr = new ObservableCollection <Products>();
        }
        public void AddToCart(Products product)
        {
            try
            {
                Pr.Add(product);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void RemoveFromCart(Products product)
        {
            Pr.Remove(product);
        }

    }
}
