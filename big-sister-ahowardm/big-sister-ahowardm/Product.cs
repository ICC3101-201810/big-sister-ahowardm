using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOO
{
  [Serializable]
  class Product
  {
    public delegate void AddedProductEventHandler(object source, Product product);
    public event AddedProductEventHandler AddedProduct;
    private string name;
    private int stock;
    private int price; //Price for one unit of the product
    private string unit;

    public Product(string name, int price, int stock, string unit)
    {
      this.name = name;
      this.stock = stock;
      this.price = price;
      this.unit = unit;
    }

    public bool Agregar(List<Product> carrito)
    {
      if (stock > 0)
      {
        carrito.Add(this);
        stock--;
        OnAddedProduct(this, this);
        return true;
      }
      return false;
    }

    public bool Quitar(List<Product> carrito){
      carrito.Remove(this);
      stock++;
      return true;
    }

    public string Name { get => name; }
    public int Stock { get => stock; }
    public int Price { get => price; }
    public string Unit { get => unit; }

    protected virtual void OnAddedProduct(object source, Product product)
    {
      if (AddedProduct != null)
        AddedProduct(this, product);

      //if (!IsNeeded(product))
       // RemoveFromCart(product);
    }
  }
}
