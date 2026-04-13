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
            Console.WriteLine($"{Id}   {Name,5}                 {Price} {RemainingStock, -5}");
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
    public class CartItem
    {
        public Product product;
        public int quantity;
    }
    class Program
    {
        static void Main(string[] args)
        {
            CartItem[] cart = new CartItem[20];
            int ItemsInCart = 0;
            
            Console.WriteLine(" ID | NAME | PRICE | REMAINING STOCK ");
            Product[] products = new Product[]
            {
                new Product { Id = 1, Name = "Toyota Vios 2006", Price = 200000, RemainingStock = 1},
                new Product { Id = 2, Name = "Vios 2006 - 2009 Headlight Pair", Price = 6000, RemainingStock = 8 },
                new Product { Id = 3, Name = "Vios 2006 - 2009 Taillight Pair", Price = 8000, RemainingStock = 4 },
            };
            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            while (true)
            {
                Console.Write("\nEnter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int productID))
                {
                    bool isFound = false;
                    Product SelectedProduct = null;
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (productID  == products[i].Id)
                        {
                            Console.WriteLine("ID is Found.");
                            SelectedProduct = products[i];
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine("ID is not found.");
                    }
                    else
                    {
                        if (SelectedProduct.RemainingStock == 0)
                        {
                            Console.WriteLine("This product is out of stock.");
                        }
                        else
                        {
                            Console.WriteLine("Enter Quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                if (quantity > 0)
                                {
                                    if (SelectedProduct.HasEnoughStock(quantity))
                                    {
                                        if (ItemsInCart >= 20)
                                        {
                                            Console.WriteLine("Cart is full!");
                                        }
                                        else
                                        {
                                            bool isDuplicate = false;
                                            for (int i = 0; i < ItemsInCart; i++)
                                            {
                                                if (cart[i].product.Id == SelectedProduct.Id)
                                                {
                                                    cart[i].quantity += quantity;
                                                    SelectedProduct.DeductStock(quantity);
                                                    isDuplicate = true;
                                                }
                                            }
                                            if (!isDuplicate)
                                            {
                                                cart[ItemsInCart] = new CartItem { product = SelectedProduct, quantity = quantity };
                                                ItemsInCart++;
                                                SelectedProduct.DeductStock(quantity);
                                                Console.WriteLine("Added to Cart!");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Quantity can not be Zero or Negative!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input. ");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Product ID is not a number. Try Again: ");
                }

                Console.WriteLine("Continue Shopping? Y/N: ");
                string choice = Console.ReadLine().ToUpper();
                {
                    if (choice == "N")
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Continuing Shopping....");
                    }
                }
            }
        }
    }
}
