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
            Console.WriteLine($"{Id,-5} | {Name,-40} | {Price,15:N0} | {RemainingStock,5}");
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
            CartItem[] cart = new CartItem[15]; // Carts array
            int ItemsInCart = 0;

            Console.WriteLine("|======== Bernardo's Car Parts and Auto Parts ======|");
            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15} ");
            Product[] products = new Product[] // Products array
            {
                // Toyota Car Parts and Auto Parts
                new Product { Id = 1, Name = "Toyota Vios 2006-2009 Headlight Pair", Price = 6000, RemainingStock = 10 },
                new Product { Id = 2, Name = "Toyota Vios 2006-2009 Taillight Pair", Price = 6000, RemainingStock = 10 },
                new Product { Id = 3, Name = "Toyota Innova 2012-2015 Grille", Price = 3500, RemainingStock = 6 },
                new Product { Id = 4, Name = "Toyota Wigo 2014-2019 Shock Absorber", Price = 3200, RemainingStock = 14 },
                new Product { Id = 5, Name = "Toyota Hiace 2005-2018 Fuel Filter", Price = 900, RemainingStock = 30 },
                
                // Honda Car Parts and Auto Parts
                new Product { Id = 6, Name = "Honda Civic 2016-2020 Front Bumper", Price = 8000, RemainingStock = 4 },
                new Product { Id = 7, Name = "Honda City 2014-2019 Brake Pads", Price = 2200, RemainingStock = 15 },
                new Product { Id = 8, Name = "Honda CR-V 2017-2022 Cabin Filter", Price = 1200, RemainingStock = 20 },
                new Product { Id = 9, Name = "Honda Jazz 2014-2021 Side Mirror", Price = 4500, RemainingStock = 5 },
                new Product { Id = 10, Name = "Honda Accord 2013-2018 Radiator", Price = 6500, RemainingStock = 3 },

                // Mitsubishi Car Parts and Auto Parrts
                new Product { Id = 11, Name = "Mitsubishi Montero 2016+ Brake Rotor", Price = 4200, RemainingStock = 8 },
                new Product { Id = 12, Name = "Mitsubishi Mirage G4 2013+ Radiator", Price = 5500, RemainingStock = 10 },
                new Product { Id = 13, Name = "Mitsubishi L300 1990+ Alternator", Price = 7500, RemainingStock = 5 },
                new Product { Id = 14, Name = "Mitsubishi Strada 2015+ Wiper Motor", Price = 4800, RemainingStock = 4 },
                new Product { Id = 15, Name = "Mitsubishi Adventure 2004+ Clutch", Price = 8500, RemainingStock = 6 },
                
                // Miscellaneous Produts 
                new Product { Id = 16, Name = "NGK Iridium Spark Plug Set (4pcs)", Price = 2400, RemainingStock = 50 },
                new Product { Id = 17, Name = "Motolite Gold 12V Car Battery", Price = 5200, RemainingStock = 8 },
                new Product { Id = 18, Name = "Denso Universal Horn Set (Pair)", Price = 1500, RemainingStock = 25 },
                new Product { Id = 19, Name = "Toyota/Mitsubishi Cabin Air Filter", Price = 450, RemainingStock = 100 },
                new Product { Id = 20, Name = "Brembo Dot 4 Brake Fluid 500ml", Price = 650, RemainingStock = 40 }
            };

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }
            bool exitShop = false;
            while (!exitShop)
            {
                bool isFound = false;
                Product SelectedProduct = null;
                while (!isFound)
                {
                    Console.WriteLine("");
                    Console.Write("Enter Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int productID))
                    {
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
                            Console.WriteLine("Product ID is not found, please input valid product ID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter valid product ID");
                    }
                }

                bool isNumber = false;
                while (!isNumber)
                {
                    if (SelectedProduct.RemainingStock == 0)
                    {
                        Console.WriteLine("\nThis product is out of stock.");
                    }
                    else
                    {
                        Console.Write("\nEnter Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            if (quantity > 0)
                            {
                                if (SelectedProduct.HasEnoughStock(quantity))
                                {
                                    bool isDuplicate = false;
                                    for (int i = 0; i < ItemsInCart; i++)
                                    {
                                        if (cart[i].product.Id == SelectedProduct.Id)
                                        {
                                            cart[i].quantity += quantity;
                                            SelectedProduct.DeductStock(quantity);
                                            isDuplicate = true;
                                            isNumber = true;
                                            Console.WriteLine("\nAdded to Cart!");
                                        }
                                    }
                                    if (!isDuplicate)
                                    {
                                        if (ItemsInCart < 15)
                                        {
                                            cart[ItemsInCart] = new CartItem { product = SelectedProduct, quantity = quantity };
                                            ItemsInCart++;
                                            SelectedProduct.DeductStock(quantity);
                                            isNumber = true;
                                            Console.WriteLine("\nAdded to Cart!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nCart is full! Cannot add new products.");
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
                            Console.WriteLine("Invalid Input.");
                        }
                    }
                }

                // after completing from Product ID until Quantity, program would ask to continue shopping.
                Console.Write("\nContinue Shopping? Y/N: ");
                string choice = Console.ReadLine().ToUpper();

                // if user wants to stop shopping, the program would start to take note of the cart, and calculate everything.
                double GrandTotal = 0;
                while (true)
                {
                    if (choice == "N")
                    {
                        // Printing receipts
                        Console.WriteLine("\n|======== Receipt ========|");
                        // Showing items in cart, quantity of product bought, and total amount of items bought.
                        for (int i = 0; i < ItemsInCart; i++)
                        {
                            double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                            GrandTotal += itemTotal; //
                            Console.WriteLine($"\n{cart[i].product.Name} - x{cart[i].quantity} - P{itemTotal:N2}");
                        }
                        //Grand total print
                        Console.WriteLine($"\nGrand Total: P{GrandTotal:N2}");
                        // Discount applied if cart > 5000 amount
                        if (GrandTotal >= 5000)
                        {
                            double discount = GrandTotal * 0.10;
                            double finalTotal = GrandTotal - discount;
                            Console.WriteLine($"| +++ Discount: P{discount:N2} +++|");
                            Console.WriteLine($"\n|====== Final Total: P{finalTotal:N2} ======|");
                        }

                        // No discount if cart < 5000 amount
                        else
                        {
                            Console.WriteLine("\nDiscount is not applied.");
                            Console.WriteLine($"|====== Final Total: P{GrandTotal:N2} ======|");
                        }
                        // Updated stocks, showing remaining stock of products.
                        Console.WriteLine("\n|======= UPDATED STOCK =======|");
                        Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15} ");
                        for (int i = 0; i < products.Length; i++)
                        {
                            products[i].DisplayProduct();
                        }
                        exitShop = true;
                        break;
                    }
                    // Restart from the start (loop)
                    else if (choice == "Y")
                    {
                        break;
                    }
                    // If input is invalid, program would ask again until the requirements are meeted.
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        Console.Write("\nContinue Shopping? Y/N: ");
                        choice = Console.ReadLine().ToUpper();
                    }
                }
            }
        }
    }
}
