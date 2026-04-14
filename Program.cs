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
            Console.WriteLine($"{Id,-5} | {Name,-35} | {Price,10} | {RemainingStock,5}");
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

            Console.WriteLine("|======== Car Shop and Auto Parts ======|");
            Console.WriteLine($"{"ID",-5} | {"NAME",-35} | {"PRICE",10} | {"REMAINING STOCK",15} ");
            Product[] products = new Product[]
            {
                new Product { Id = 1, Name = "Toyota Vios 2006", Price = 200000, RemainingStock = 1},
                new Product { Id = 2, Name = "Vios 2006 - 2009 Headlight Pair", Price = 6000, RemainingStock = 8 },
                new Product { Id = 3, Name = "Vios 2006 - 2009 Taillight Pair", Price = 8000, RemainingStock = 4 },
                new Product { Id = 4, Name = "Honda Civic 2010", Price = 350000, RemainingStock = 5},
                new Product { Id = 5, Name = "Toyota Fortuner", Price = 800000, RemainingStock = 3},
                new Product { Id = 6, Name = "Honda Civic Side Mirror Pair", Price = 3500, RemainingStock = 67},
                new Product { Id = 7, Name = "Fortuner Bumper Cover", Price = 12000, RemainingStock = 10},
                new Product { Id = 8, Name = "Lancer Brake Pads Set", Price = 2500, RemainingStock = 0},
                new Product { Id = 9, Name = "Universal Windshield Wipers", Price = 800, RemainingStock = 100},
                new Product { Id = 10, Name = "Car Battery 12V ", Price = 4500, RemainingStock = 5},
                new Product { Id = 11, Name = "Radiator Fan Assembly", Price = 6500, RemainingStock = 13 },
                new Product { Id = 12, Name = "Spark Plug Set ", Price = 1200, RemainingStock = 1000},
                new Product { Id = 13, Name = "Lancer Side Mirror Pair", Price = 2800, RemainingStock = 9},
                new Product { Id = 14, Name = "Oil Filter", Price = 500, RemainingStock = 50},
                new Product { Id = 15, Name = "Clutch Kit", Price = 8000, RemainingStock = 7},

            };
            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            bool exitShop = false;
            while (!exitShop)
            {
                Console.Write("\nEnter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int productID))
                {
                    bool isFound = false;
                    Product SelectedProduct = null;
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (productID == products[i].Id)
                        {
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
                            Console.Write("Enter Quantity: ");
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
                    Console.Write("\nProduct ID is not a number. Try Again: ");
                }

                Console.Write("\nContinue Shopping? Y/N: ");
                string choice = Console.ReadLine().ToUpper();

                double GrandTotal = 0;
                while (true)
                {
                    if (choice == "N")
                    {
                        for (int i = 0; i < ItemsInCart; i++)
                        {
                            double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                            GrandTotal += itemTotal;
                            Console.WriteLine($"\n{cart[i].product.Name} - x{cart[i].quantity} - {itemTotal:N2}");
                        }

                        Console.WriteLine($"Grand Total: {GrandTotal}");
                        if (GrandTotal >= 5000)
                        {
                            double discount = GrandTotal * 0.10;
                            double finalTotal = GrandTotal - discount;
                            Console.WriteLine($"Discount: {discount:N2}");
                            Console.WriteLine($"Final Total: {finalTotal:N2}");
                        }
                        else
                        {
                            Console.WriteLine("\nDiscount is not applied.");
                            Console.WriteLine($"Final Total: {GrandTotal:N2}");
                        }

                        Console.WriteLine("\n|======= UPDATED STOCK =======|");
                        Console.WriteLine($"{"ID",-5} | {"NAME",-35} | {"PRICE",10} | {"REMAINING STOCK",15} ");
                        for (int i = 0; i < products.Length; i++)
                        {
                            products[i].DisplayProduct();
                        }
                        exitShop = true;
                        break;
                    }

                    else if (choice == "Y")
                    {
                        Console.WriteLine("\nContinue Shopping....");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        Console.Write("Continue Shopping? Y/N: ");
                        choice = Console.ReadLine().ToUpper();
                    }
                }
            }
        }
    }
}
