using System;
namespace ShoppingCartSystem
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;
        public void DisplayProduct()
        {
            Console.WriteLine($" {Id,-5} {Name,-15}     {Price,-15}        {RemainingStock,-10}");
        }
        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }
        public int HasEnoughStock(int quantity)
        {
            return RemainingStock * quantity;
        }
    } class Program
    {
        static void Main(string[] args)
        {
            
            Product[] product = new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Apple",
                    Price = 10,
                    RemainingStock = 10000,

                }, new Product
                {
                    Id = 2,
                    Name = "Antig",
                    Price = 1000000,
                    RemainingStock = 1,
                }, new Product
                {
                    Id = 3,
                    Name = "Navarro's Balls",
                    Price = 0,
                    RemainingStock = 2,
                }, new Product
                {
                    Id = 4,
                    Name = "Mharimar",
                    Price = 100000000000000,
                    RemainingStock = 1,
                }
            };
            Console.WriteLine("ID     Name                Price             Remaining Stock");

            for (int i = 0; i < product.Length; i++)
            {
               product[i].DisplayProduct();
            }
            
        }
    }
}



