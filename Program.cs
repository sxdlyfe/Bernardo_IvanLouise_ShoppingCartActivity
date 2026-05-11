using System;
namespace ShoppingCartSystem
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;
        public string Category;

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id,-5} | {Name,-40} | {Category,-15} | {Price,15:N0} | {RemainingStock,15}");
        }
        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }
        public bool HasEnoughStock(int quantity)
        {
            if (RemainingStock < quantity)
            {
                Console.WriteLine("No enough stock available for this item.");
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

    public class OrderHistory
    {
        public int ReceiptNumber;
        public DateTime Date;
        public double FinalTotal;
        public string ItemsSummary;
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
            OrderHistory[] orderHistory = new OrderHistory[35];
            int orderCount = 0;

            CartItem[] cart = new CartItem[15]; // Carts array
            int ItemsInCart = 0;
            int receiptNumber = 1;

            Console.WriteLine("|==================== Bernardo's Car Parts and Auto Parts ====================|");
            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");
            Product[] products = new Product[] // Products array
                  {
                // Toyota Car Parts and Auto Parts
                new Product { Id = 1, Name = "Toyota Vios 2006-2009 Headlight Pair", Price = 6000, RemainingStock = 10, Category = "Toyota"},
                new Product { Id = 2, Name = "Toyota Vios 2006-2009 Taillight Pair", Price = 6000, RemainingStock = 0, Category = "Toyota" },
                new Product { Id = 3, Name = "Toyota Innova 2012-2015 Grille", Price = 3500, RemainingStock = 6, Category = "Toyota" },
                new Product { Id = 4, Name = "Toyota Wigo 2014-2019 Shock Absorber", Price = 3200, RemainingStock = 14, Category = "Toyota" },
                new Product { Id = 5, Name = "Toyota Hiace 2005-2018 Fuel Filter", Price = 900, RemainingStock = 30, Category = "Toyota" },
                
                // Honda Car Parts and Auto Parts
                new Product { Id = 6, Name = "Honda Civic 2016-2020 Front Bumper", Price = 8000, RemainingStock = 4, Category = "Honda"},
                new Product { Id = 7, Name = "Honda City 2014-2019 Brake Pads", Price = 2200, RemainingStock = 15, Category = "Honda"},
                new Product { Id = 8, Name = "Honda CR-V 2017-2022 Cabin Filter", Price = 1200, RemainingStock = 20, Category = "Honda" },
                new Product { Id = 9, Name = "Honda Jazz 2014-2021 Side Mirror", Price = 4500, RemainingStock = 5, Category = "Honda" },
                new Product { Id = 10, Name = "Honda Accord 2013-2018 Radiator", Price = 6500, RemainingStock = 3, Category = "Honda" },
        
                // Mitsubishi Car Parts and Auto Parts
                new Product { Id = 11, Name = "Mitsubishi Montero 2016+ Brake Rotor", Price = 4200, RemainingStock = 8, Category = "Mitsubishi" },
                new Product { Id = 12, Name = "Mitsubishi Mirage G4 2013+ Radiator", Price = 5500, RemainingStock = 10, Category = "Mitsubishi" },
                new Product { Id = 13, Name = "Mitsubishi L300 1990+ Alternator", Price = 7500, RemainingStock = 5, Category = "Mitsubishi" },
                new Product { Id = 14, Name = "Mitsubishi Strada 2015+ Wiper Motor", Price = 4800, RemainingStock = 4, Category = "Mitsubishi" },
                new Product { Id = 15, Name = "Mitsubishi Adventure 2004+ Clutch", Price = 8500, RemainingStock = 6, Category = "Mitsubishi" },
                
                // Miscellaneous Products 
                new Product { Id = 16, Name = "NGK Iridium Spark Plug Set (4pcs)", Price = 2400, RemainingStock = 50, Category = "Miscellaneous" },
                new Product { Id = 17, Name = "Motolite Gold 12V Car Battery", Price = 5200, RemainingStock = 8, Category = "Miscellaneous" },
                new Product { Id = 18, Name = "Denso Universal Horn Set (Pair)", Price = 1500, RemainingStock = 25, Category = "Miscellaneous" },
                new Product { Id = 19, Name = "Toyota/Mitsubishi Cabin Air Filter", Price = 450, RemainingStock = 100, Category = "Miscellaneous" },
                new Product { Id = 20, Name = "Brembo Dot 4 Brake Fluid 500ml", Price = 650, RemainingStock = 40, Category = "Miscellaneous" }
            };

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }
            bool exitShop = false;
            while (!exitShop)
            {
                bool exitCart = false;
                Console.WriteLine("\n|======= Main Menu =======|");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Search Item");
                Console.WriteLine("3. Filter Item by Category");
                Console.WriteLine("4. Cart Management Menu");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Order History");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter Choice (1 - 7): ");

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
                                bool isOutofStock = false;
                                while (!isNumber)
                                {
                                    if (SelectedProduct.RemainingStock == 0)
                                    {
                                        Console.WriteLine("\nThis product is out of stock.");
                                        bool validOOS = false;
                                        isOutofStock = true;
                                        while (!validOOS)
                                        {
                                            Console.Write("Do you want to try a different product? (Y/N): ");
                                            string oosChoice = Console.ReadLine().ToUpper();
                                            if (oosChoice == "Y")
                                            {
                                                addItemsAgain = true;
                                                validOOS = true;
                                                isNumber = true;
                                            }
                                            else if (oosChoice == "N")
                                            {
                                                addItemsAgain = false;
                                                isNumber = true;
                                                validOOS = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input, please enter only Y or N.");
                                            }
                                        }
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
                                                            SelectedProduct.DeductStock(quantity);
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

                                if (!isOutofStock)
                                {
                                    bool validChoice = false;
                                    while (!validChoice)
                                    {
                                        Console.Write("\nDo you want to add another item? (Y/N): ");
                                        string addAnother = Console.ReadLine().ToUpper();
                                        if (addAnother == "N")
                                        {
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
                                }
                            break;

                        case 2:
                            Console.Write("\nEnter product name to search: ");
                            string searchTerm = Console.ReadLine().ToLower();

                            bool found = false;
                            Console.WriteLine("\n|======= SEARCH RESULTS =======|");
                            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");

                            for (int i = 0; i < products.Length; i++)
                            {
                                if (products[i].Name.ToLower().Contains(searchTerm))
                                {
                                    products[i].DisplayProduct();
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("No products found matching your search.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("\n|======= FILTER BY CATEGORY =======|");
                            Console.WriteLine("1. Toyota");
                            Console.WriteLine("2. Honda");
                            Console.WriteLine("3. Mitsubishi");
                            Console.WriteLine("4. Miscellaneous");
                            Console.Write("\nEnter category number (1-4): ");

                            if (int.TryParse(Console.ReadLine(), out int categoryChoice))
                            {
                                string selectedCategory = "";
                                switch (categoryChoice)
                                {
                                    case 1: selectedCategory = "Toyota"; break;
                                    case 2: selectedCategory = "Honda"; break;
                                    case 3: selectedCategory = "Mitsubishi"; break;
                                    case 4: selectedCategory = "Miscellaneous"; break;
                                    default:
                                        Console.WriteLine("Invalid category choice.");
                                        break;
                                }

                                if (selectedCategory != "")
                                {
                                    Console.WriteLine($"\n|======= {selectedCategory.ToUpper()} PRODUCTS =======|");
                                    Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");

                                    bool categoryFound = false;  // ← Use this instead
                                    for (int i = 0; i < products.Length; i++)
                                    {
                                        if (products[i].Category == selectedCategory)
                                        {
                                            products[i].DisplayProduct();
                                            categoryFound = true;
                                        }
                                    }

                                    if (!categoryFound)
                                    {
                                        Console.WriteLine("No products found in this category.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                            break;

                        case 4:
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
                                                        
                                                        cart[i].product.RemainingStock += cart[i].quantity;

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
                                                bool updateAgain = true;
                                                while (updateAgain)
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
                                                                                int totalAvailable = cart[i].product.RemainingStock + oldQty;

                                                                                if (newQty > totalAvailable)
                                                                                {
                                                                                    Console.WriteLine($"Not enough stock. Available stock: {totalAvailable}");
                                                                                }
                                                                                else
                                                                                { 
                                                                                    cart[i].product.RemainingStock = totalAvailable - newQty;
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
                                                                isUpdated = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a number.");
                                                        }
                                                    }

                         
                                                    bool validUpdateChoice = false;
                                                    while (!validUpdateChoice)
                                                    {
                                                        Console.Write("\nWould you like to update another item? (Y/N): ");
                                                        string updateChoice = Console.ReadLine().ToUpper();
                                                        if (updateChoice == "Y")
                                                        {
                                                            updateAgain = true;
                                                            validUpdateChoice = true;
                                                        }

                                                        else if (updateChoice == "N")
                                                        { 
                                                            updateAgain = false;
                                                            validUpdateChoice = true;
                                                        }

                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter Y or N only.");
                                                        }
                                                    }
                                                }
                                            }
                                            break;

                                        case 4:
                                            bool validClearChoice = false;
                                            while (!validClearChoice)
                                            {
                                                Console.Write("Are you sure you want to clear all items from cart? (Y/N): ");
                                                string clearChoice = Console.ReadLine().ToUpper();
                                                if (clearChoice == "Y")
                                                {
                                                    for (int i = 0; i < ItemsInCart; i++)
                                                    {
                                                        cart[i].product.RemainingStock += cart[i].quantity;
                                                        cart[i] = null;
                                                    }
                                                    ItemsInCart = 0;
                                                    Console.WriteLine("Successfully removed items in cart.");
                                                    validClearChoice = true;
                                                }
                                                else if (clearChoice == "N")
                                                {
                                                    Console.WriteLine("Cart clear cancelled.");
                                                    validClearChoice = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Please enter Y or N only.");
                                                }
                                            }
                                            break;

                                        case 5:
                                            exitCart = true;
                                            break;
                                    }
                                }
                            }
                            break;

                        case 5:
                            if (ItemsInCart == 0)
                            {
                                Console.WriteLine("Cart is empty. Cannot checkout.");
                                break;
                            }

                            double GrandTotal = 0;
                            for (int i = 0; i < ItemsInCart; i++)
                            {
                                GrandTotal += cart[i].product.GetItemTotal(cart[i].quantity);
                            }

                            double finalTotal;
                            if (GrandTotal >= 5000)
                            {
                                double discount = GrandTotal * 0.10;
                                finalTotal = GrandTotal - discount;
                                Console.WriteLine($"| +++ Discount: P{discount:N2} +++|");
                            }
                            else
                            {
                                finalTotal = GrandTotal;
                                Console.WriteLine("\nDiscount is not applied.");
                            }

                            Console.WriteLine($"\nFinal Total: P{finalTotal:N2}");

                            bool validPayment = false;
                            double payment = 0;
                            while (!validPayment)
                            {
                                Console.Write("\nEnter payment amount: P");
                                if (double.TryParse(Console.ReadLine(), out payment))
                                {
                                    if (payment >= finalTotal)
                                    {
                                        validPayment = true;
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

                            double change = payment - finalTotal;
                            Console.WriteLine($"Change: P{change:N2}");

                            Console.WriteLine("\n|======== Receipt ========|");
                            Console.WriteLine($"Receipt No: {receiptNumber:D4}");
                            Console.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy h:mm tt}");

                            Console.WriteLine("\nITEM                                         | QTY  | UNIT PRICE | TOTAL      |");
                            Console.WriteLine("---------------------------------------------|------|------------|------------");
                            for (int i = 0; i < ItemsInCart; i++)
                            {
                                double itemTotal = cart[i].product.GetItemTotal(cart[i].quantity);
                                Console.WriteLine($"{cart[i].product.Name,-44} | {cart[i].quantity,4} | {cart[i].product.Price,10:N0} | {itemTotal,10:N2}");
                            }

                            Console.WriteLine($"\nGrand Total: P{GrandTotal:N2}");
                            Console.WriteLine($"Final Total: P{finalTotal:N2}");

                            string itemsSummary = "";
                            for (int i = 0; i < ItemsInCart; i++)
                            {
                                itemsSummary += $"{cart[i].product.Name} x{cart[i].quantity}, ";
                            }

                            Console.WriteLine("\n|=============================== UPDATED STOCK ===============================|");
                            for (int i = 0; i < products.Length; i++)
                            {
                                products[i].DisplayProduct();
                            }

                            Console.WriteLine("\n|====================== LOW STOCK ALERT ======================|");
                            bool hasLowStock = false;
                            for (int i = 0; i < products.Length; i++)
                            {
                                if (products[i].RemainingStock <= 5)
                                {
                                    Console.WriteLine($"LOW STOCK: {products[i].Name} has only {products[i].RemainingStock} left.");
                                    hasLowStock = true;
                                }
                            }
                            if (!hasLowStock) Console.WriteLine("No low stock alerts.");

                            if (orderCount < 35)
                            {
                                orderHistory[orderCount] = new OrderHistory
                                {
                                    ReceiptNumber = receiptNumber,
                                    Date = DateTime.Now,
                                    FinalTotal = finalTotal,
                                    ItemsSummary = itemsSummary.TrimEnd(',', ' ')
                                };
                                orderCount++;
                                receiptNumber++;
                            }

                            for (int i = 0; i < ItemsInCart; i++)
                            {
                                cart[i] = null;
                            }
                            ItemsInCart = 0;

                            Console.WriteLine("\n|======= ORDER HISTORY =======|");

                            if (orderCount == 0)
                            {
                                Console.WriteLine("No orders yet.");
                            }
                            else
                            {
                                for (int i = 0; i < orderCount; i++)
                                {
                                    Console.WriteLine($"Receipt #{orderHistory[i].ReceiptNumber:D4} - {orderHistory[i].Date:MMMM dd, yyyy h:mm tt} - Final Total: P{orderHistory[i].FinalTotal:N2}");
                                    Console.WriteLine($"Items: {orderHistory[i].ItemsSummary}");
                                    Console.WriteLine("----------------------------------------");
                                }
                            }

                            bool validCheckoutChoice = false;
                            while (!validCheckoutChoice)
                            {
                                Console.Write("\nWould you like to continue shopping? (Y/N): ");
                                string checkoutChoice = Console.ReadLine().ToUpper();
                                if (checkoutChoice == "Y")
                                {
                                    validCheckoutChoice = true;
                                }
                                else if (checkoutChoice == "N")
                                {
                                    validCheckoutChoice = true;
                                    exitShop = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter Y or N only.");
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("\n|======= ORDER HISTORY =======|");
                            if (orderCount == 0)
                            {
                                Console.WriteLine("No orders yet.");
                            }
                            else
                            {
                                for (int i = 0; i < orderCount; i++)
                                {
                                    Console.WriteLine($"Receipt #{orderHistory[i].ReceiptNumber:D4} - {orderHistory[i].Date:MMMM dd, yyyy h:mm tt} - Final Total: P{orderHistory[i].FinalTotal:N2}");
                                    Console.WriteLine($"Items: {orderHistory[i].ItemsSummary}");
                                    Console.WriteLine("----------------------------------------");
                                }
                            }
                            break;

                        case 7:
                            bool validExitChoice = false;
                            while (!validExitChoice)
                            {
                                Console.Write("Are you sure you want to exit the program? (Y/N): ");
                                string exitChoice = Console.ReadLine().ToUpper();
                                if (exitChoice == "Y")
                                {
                                    exitShop = true;
                                    validExitChoice = true;
                                }
                                else if (exitChoice == "N")
                                {
                                    validExitChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter Y or N only.");
                                }
                            }
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
