using System;
namespace ShoppingCartSystem
{
    public class Product
    {
        public int id;
        public string name;
        public double price;
        public int remainingStock;

        public void DisplayProduct()
        {
            Console.WriteLine($"{id}   {name,5}                 {price} {remainingStock, -5}");
        }

        public double GetItemTotal(int quantity)
        {
            return price * quantity;
        }

        public bool HasEnoughStock(int quantity)
        {
            if (remainingStock < quantity)
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
            remainingStock -= quantity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ID | NAME | PRICE | REMAINING STOCK ");
            Product[] products = new Product[]
            {
                new Product { id = 1, name = "Toyota Vios 2006", price = 200000, remainingStock = 1},
                new Product { id = 2, name = "Vios 2006 - 2009 Headlight Pair", price = 6000, remainingStock = 8 },
                new Product { id = 3, name = "Vios 2006 - 2009 Taillight Pair", price = 8000, remainingStock = 4 },
            };
            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            while (true)
            {
                int number;
                Console.WriteLine("Enter Product ID: ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid product ID, please try again: ");
                }

                int quantity;
                Console.WriteLine("Enter Quantity: ");
                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid Quantity, please try again: ");
                }

                for (int i = 0; i < products.Length; ++i)
                {
                    if (number && quantity)
                }
            }
        }
    }
}
