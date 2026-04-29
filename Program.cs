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
            int receiptNumber = 1;

            Console.WriteLine("|==================== Bernardo's Car Parts and Auto Parts ====================|");
            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");
            Product[] products = new Product[] // Products array
            {
                // Toyota Car Parts and Auto Parts
                new Product { Id = 1, Name = "Toyota Vios 2006-2009 Headlight Pair", Price = 6000, RemainingStock = 10, },
                new Product { Id = 2, Name = "Toyota Vios 2006-2009 Taillight Pair", Price = 6000, RemainingStock = 10, },
                new Product { Id = 3, Name = "Toyota Innova 2012-2015 Grille", Price = 3500, RemainingStock = 6, },
                new Product { Id = 4, Name = "Toyota Wigo 2014-2019 Shock Absorber", Price = 3200, RemainingStock = 14, },
                new Product { Id = 5, Name = "Toyota Hiace 2005-2018 Fuel Filter", Price = 900, RemainingStock = 30 },
                
                // Honda Car Parts and Auto Parts
                new Product { Id = 6, Name = "Honda Civic 2016-2020 Front Bumper", Price = 8000, RemainingStock = 4, },
                new Product { Id = 7, Name = "Honda City 2014-2019 Brake Pads", Price = 2200, RemainingStock = 15, },
                new Product { Id = 8, Name = "Honda CR-V 2017-2022 Cabin Filter", Price = 1200, RemainingStock = 20,  },
                new Product { Id = 9, Name = "Honda Jazz 2014-2021 Side Mirror", Price = 4500, RemainingStock = 5,  },
                new Product { Id = 10, Name = "Honda Accord 2013-2018 Radiator", Price = 6500, RemainingStock = 3,  },

                // Mitsubishi Car Parts and Auto Parts
                new Product { Id = 11, Name = "Mitsubishi Montero 2016+ Brake Rotor", Price = 4200, RemainingStock = 8,  },
                new Product { Id = 12, Name = "Mitsubishi Mirage G4 2013+ Radiator", Price = 5500, RemainingStock = 10,  },
                new Product { Id = 13, Name = "Mitsubishi L300 1990+ Alternator", Price = 7500, RemainingStock = 5,  },
                new Product { Id = 14, Name = "Mitsubishi Strada 2015+ Wiper Motor", Price = 4800, RemainingStock = 4,  },
                new Product { Id = 15, Name = "Mitsubishi Adventure 2004+ Clutch", Price = 8500, RemainingStock = 6, },
                
                // Miscellaneous Products 
                new Product { Id = 16, Name = "NGK Iridium Spark Plug Set (4pcs)", Price = 2400, RemainingStock = 50, },
                new Product { Id = 17, Name = "Motolite Gold 12V Car Battery", Price = 5200, RemainingStock = 8, },
                new Product { Id = 18, Name = "Denso Universal Horn Set (Pair)", Price = 1500, RemainingStock = 25, },
                new Product { Id = 19, Name = "Toyota/Mitsubishi Cabin Air Filter", Price = 450, RemainingStock = 100, },
                new Product { Id = 20, Name = "Brembo Dot 4 Brake Fluid 500ml", Price = 650, RemainingStock = 40, }
            };

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }
            bool exitShop = false;
            while (!exitShop)
            {
                bool exitCart = false;
                bool addItem = false;
                while (!addItem)
                {
                    Console.WriteLine("\n|======= Cart Management Menu =======|");
                    Console.WriteLine("1. Add Item");
                    Console.WriteLine("2. Cart Management Menu");
                    Console.WriteLine("3. Checkout");
                    Console.Write("\nEnter Choice (1 - 3): ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                bool addItemsAgain = true;
                                while (addItemsAgain)
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
                                                Console.WriteLine("Product ID is not found, please input valid product ID");
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
                                            break;
                                        }
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
                                                            if (quantity > SelectedProduct.RemainingStock)
                                                                Console.WriteLine($"Not enough stock. Available: {SelectedProduct.RemainingStock}");
                                                            else
                                                            {
                                                                cart[i].quantity += quantity;
                                                                SelectedProduct.RemainingStock -= quantity;
                                                                Console.WriteLine("\nAdded to Cart!");
                                                                isDuplicate = true;
                                                                isNumber = true;
                                                            }
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
                                                            Console.WriteLine("\nCart is full!");
                                                    }
                                                }
                                            }
                                            else
                                                Console.WriteLine("Quantity cannot be Zero or Negative!");
                                        }
                                        else
                                            Console.WriteLine("Invalid Input.");
                                    }

                                    bool validChoice = false;
                                    while (!validChoice)
                                    {
                                        Console.Write("\nDo you want to add another item? (Y/N): ");
                                        string addAnother = Console.ReadLine().ToUpper();
                                        if (addAnother == "N")
                                        {
                                            addItem = true;
                                            addItemsAgain = false;
                                            validChoice = true;
                                        }
                                        else if (addAnother == "Y")
                                        {
                                            addItemsAgain = true;
                                            validChoice = true;
                                        }
                                        else
                                            Console.WriteLine("Invalid input, please enter only Y or N.");
                                    }
                                }
                                break;

                            case 2:
                                while (!exitCart)
                                {
                                    Console.WriteLine("\n|======== Cart Management Menu ========|");
                                    Console.WriteLine("1. View Cart");
                                    Console.WriteLine("2. Remove Item");
                                    Console.WriteLine("3. Update Quantity");
                                    Console.WriteLine("4. Clear Cart");
                                    Console.WriteLine("5. Back to Main Menu");

                                    Console.Write("\nEnter Choice (1 - 5): ");
                                    if (int.TryParse(Console.ReadLine(), out int cartchoice))
                                    {
                                        switch (cartchoice)
                                        {
                                            case 1:
                                                if (ItemsInCart == 0)
                                                {
                                                    Console.WriteLine("Cart is empty.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n|======= UPDATED CART =======|");
                                                    for (int i = 0; i < ItemsInCart; i++)
                                                    {
                                                        double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                                                        Console.WriteLine($"{i + 1}. [ID: {cart[i].product.Id}] {cart[i].product.Name} - x{cart[i].quantity} - P{itemTotal:N2}");
                                                    }
                                                }
                                                break;

                                            case 2:
                                                if (ItemsInCart == 0)
                                                {
                                                    Console.WriteLine("Cart is empty.");
                                                    break;
                                                }

                                                Console.Write("Enter Product ID to remove: ");
                                                if (int.TryParse(Console.ReadLine(), out int removeID))
                                                {
                                                    bool isRemoved = false;

                                                    for (int i = 0; i < ItemsInCart; i++)
                                                    {
                                                        if (cart[i] != null && cart[i].product.Id == removeID)
                                                        {
                                                            // restore stock
                                                            cart[i].product.RemainingStock += cart[i].quantity;

                                                            // shift items left
                                                            for (int j = i; j < ItemsInCart - 1; j++)
                                                            {
                                                                cart[j] = cart[j + 1];
                                                            }

                                                            cart[ItemsInCart - 1] = null;
                                                            ItemsInCart--;

                                                            isRemoved = true;
                                                            Console.WriteLine("Item removed from cart.");
                                                            break;
                                                        }
                                                    }

                                                    if (!isRemoved)
                                                    {
                                                        Console.WriteLine("Product ID not found in cart.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input.");
                                                }
                                                break;

                                            case 3:
                                                if (ItemsInCart == 0)
                                                {
                                                    Console.WriteLine("Cart is empty.");
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n|======= UPDATE ITEM QUANTITY =======|");
                                                    for (int i = 0; i < ItemsInCart; i++)
                                                    {
                                                        double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                                                        Console.WriteLine($"{i + 1}. [ID: {cart[i].product.Id}] {cart[i].product.Name} - x{cart[i].quantity} - P{itemTotal:N2}");
                                                    }

                                                    bool isUpdated = false;
                                                    while (!isUpdated)
                                                    {
                                                        Console.Write("\nEnter Product ID to update quantity: ");
                                                        if (int.TryParse(Console.ReadLine(), out int ProductID))
                                                        {
                                                            bool foundInCart = false;
                                                            for (int i = 0; i < ItemsInCart; i++)
                                                            {
                                                                if (cart[i].product.Id == ProductID)
                                                                {
                                                                    foundInCart = true;
                                                                    bool validQty = false;
                                                                    while (!validQty)
                                                                    {
                                                                        Console.Write($"\nEnter new quantity for {cart[i].product.Name} (current: {cart[i].quantity}): ");
                                                                        if (int.TryParse(Console.ReadLine(), out int newQty))
                                                                        {
                                                                            if (newQty <= 0)
                                                                            {
                                                                                Console.WriteLine("Quantity must be greater than zero.");
                                                                            }
                                                                            else
                                                                            {
                                                                                int oldQty = cart[i].quantity;
                                                                                int restoredStock = cart[i].product.RemainingStock + oldQty;

                                                                                if (newQty > restoredStock)
                                                                                {
                                                                                    Console.WriteLine($"Not enough stock. Available stock: {restoredStock}");
                                                                                }
                                                                                else
                                                                                {
                                                                                    cart[i].product.RemainingStock = restoredStock - newQty;
                                                                                    cart[i].quantity = newQty;
                                                                                    Console.WriteLine($"Quantity updated to {newQty}.");
                                                                                    validQty = true;
                                                                                    isUpdated = true;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Invalid input. Please enter a number.");
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            }
                                                            if (!foundInCart)
                                                            {
                                                                Console.WriteLine("Product ID not found in cart. Try again.");
                                                            }
                                                            else
                                                            {
                                                                isUpdated = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a number.");
                                                        }
                                                    }
                                                }
                                                break;

                                            case 4:
                                                for (int i = 0; i < ItemsInCart; i++)
                                                {
                                                    cart[i].product.RemainingStock += cart[i].quantity;
                                                    cart[i] = null;
                                                }
                                                ItemsInCart = 0;
                                                Console.WriteLine("Successfully removed items in cart.");
                                                break;

                                            case 5:
                                                exitCart = true;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input, please try again");
                                                break;
                                        }
                                    }
                                }
                                break;

                            case 3:
                                if (ItemsInCart == 0)
                                {
                                    Console.WriteLine("Cart is empty. Cannot checkout.");
                                    break;
                                }

                                double GrandTotal = 0;
                                Console.WriteLine("\n|======== Receipt ========|");
                                Console.WriteLine($"Receipt No: {receiptNumber:D4}");
                                Console.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy h:mm tt}");  

                                for (int i = 0; i < ItemsInCart; i++)
                                {
                                    double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                                    GrandTotal += itemTotal;
                                    Console.WriteLine($"{cart[i].product.Name} - x{cart[i].quantity} - P{itemTotal:N2}");
                                }

                                Console.WriteLine($"\nGrand Total: P{GrandTotal:N2}");

                                double finalTotal;

                                if (GrandTotal >= 5000)
                                {
                                    double discount = GrandTotal * 0.10;
                                    finalTotal = GrandTotal - discount;
                                    Console.WriteLine($"| +++ Discount: P{discount:N2} +++|");
                                    Console.WriteLine($"\n|====== Final Total: P{finalTotal:N2} ======|");
                                }

                                else
                                {
                                    finalTotal = GrandTotal;
                                    Console.WriteLine("\nDiscount is not applied.");
                                    Console.WriteLine($"|====== Final Total: P{GrandTotal:N2} ======|");
                                }

                                bool validPayment = false;
                                while (!validPayment)
                                {
                                    Console.Write($"\nEnter payment amount: P");
                                    if (double.TryParse(Console.ReadLine(), out double payment))
                                    {
                                        if (payment >= finalTotal)
                                        {
                                            double change = payment - finalTotal;
                                            Console.WriteLine($"|==== Payment: P{payment:N2} ====|");
                                            Console.WriteLine($"|==== Change: P{change:N2} ====|");
                                            validPayment = true;
                                            receiptNumber++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Insufficient payment. You need P{finalTotal:N2}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter a number.");
                                    }
                                }

                                Console.WriteLine("\n|======= UPDATED STOCK =======|");
                                Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15} ");
                                for (int i = 0; i < products.Length; i++)
                                {
                                    products[i].DisplayProduct();
                                }

                                Console.WriteLine("\n|======= LOW STOCK ALERT =======|");
                                bool hasLowStock = false;
                                for (int i = 0; i < products.Length; i++)
                                {
                                    if (products[i].RemainingStock <= 5)
                                    {
                                        Console.WriteLine($"LOW STOCK: {products[i].Name} has only {products[i].RemainingStock} left.");
                                        hasLowStock = true;
                                    }
                                }
                                if (!hasLowStock)
                                {
                                    Console.WriteLine("No low stock alerts.");
                                }
                                exitShop = true;
                                break;

                            default:
                                Console.WriteLine("Invalid input, try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is not a number, try again.");
                    }
                }
            }
        }
    }
}
