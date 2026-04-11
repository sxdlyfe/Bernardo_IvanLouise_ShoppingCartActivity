using System;
namespace ShoppingCartSystem
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id} {Name} {Price} {RemainingStock}");
        }

        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }

        public bool HasEnoughStock(int quantity)
        {
            if (RemainingStock < quantity)
            {
                Console.WriteLine("No Stock Available.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeductStock(int quantity)
        {
            RemainingStock -= quantity;
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {

        }
    }

}
