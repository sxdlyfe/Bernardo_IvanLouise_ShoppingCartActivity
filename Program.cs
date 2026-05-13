using System;
namespace ShoppingCartSystem
{
    public class Product
    {
        private int id;
        private string name;
        private double price;
        private int remainingStock;
        private string category;

        public int GetId() 
        { 
            return id; 
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetName() 
        { 
            return name; 
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public double GetPrice() 
        { 
            return price; 
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public int GetRemainingStock() 
        { 
            return remainingStock; 
        }

        public void SetRemainingStock(int remainingStock)
        {
            this.remainingStock = remainingStock;
        }

        public string GetCategory()
        {
            return category;
        }

        public void SetCategory(string category) 
        { 
            this.category = category; 
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"{GetId(),-5} | {GetName(),-40} | {GetCategory(),-15} | {GetPrice(),15:N0} | {GetRemainingStock(),15}");
        }

        public double GetItemTotal(int quantity)
        {
            return GetPrice() * quantity;
        }

        public bool HasEnoughStock(int quantity)
        {
            if (GetRemainingStock() < quantity)
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
            SetRemainingStock(GetRemainingStock() - quantity);
        }
    }

    public class OrderHistory
    {
        private int receiptNumber;
        private DateTime date;
        private double finalTotal;
        private string itemsSummary;

        public int GetReceiptNumber() 
        { 
            return receiptNumber; 
        }

        public void SetReceiptNumber(int receiptNumber)
        {
            this.receiptNumber = receiptNumber;
        }

        public DateTime GetDate() 
        { 
            return date; 
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        public double GetFinalTotal() 
        { 
            return finalTotal; 
        }

        public void SetFinalTotal(double finalTotal)
        {
            this.finalTotal = finalTotal;
        }

        public string GetItemsSummary() 
        { 
            return itemsSummary; 
        }

        public void SetItemsSummary(string itemsSummary) 
        { 
            this.itemsSummary = itemsSummary; 
        }
    }

    public class CartItem
    {
        private Product product;
        private int quantity;

        public Product GetProduct() 
        { 
            return product; 
        }

        public int GetQuantity() 
        {
            return quantity; 
        }

        public void SetProduct(Product product) 
        { 
            this.product = product;
        }

        public void SetQuantity(int quantity) 
        { 
            this.quantity = quantity; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderHistory[] orderHistory = new OrderHistory[35];
            int orderCount = 0;

            CartItem[] cart = new CartItem[15];
            int ItemsInCart = 0;
            int receiptNumber = 1;

            Console.WriteLine("|==================== Bernardo's Car Parts and Auto Parts ====================|");
            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");

            // Toyota
            Product p1 = new Product();
            p1.SetId(1); p1.SetName("Toyota Vios 2006-2009 Headlight Pair"); p1.SetPrice(6000); p1.SetRemainingStock(10); p1.SetCategory("Toyota");

            Product p2 = new Product();
            p2.SetId(2); p2.SetName("Toyota Vios 2006-2009 Taillight Pair"); p2.SetPrice(6000); p2.SetRemainingStock(0); p2.SetCategory("Toyota");

            Product p3 = new Product();
            p3.SetId(3); p3.SetName("Toyota Innova 2012-2015 Grille"); p3.SetPrice(3500); p3.SetRemainingStock(6); p3.SetCategory("Toyota");

            Product p4 = new Product();
            p4.SetId(4); p4.SetName("Toyota Wigo 2014-2019 Shock Absorber"); p4.SetPrice(3200); p4.SetRemainingStock(14); p4.SetCategory("Toyota");

            Product p5 = new Product();
            p5.SetId(5); p5.SetName("Toyota Hiace 2005-2018 Fuel Filter"); p5.SetPrice(900); p5.SetRemainingStock(30); p5.SetCategory("Toyota");

            // Honda
            Product p6 = new Product();
            p6.SetId(6); p6.SetName("Honda Civic 2016-2020 Front Bumper"); p6.SetPrice(8000); p6.SetRemainingStock(4); p6.SetCategory("Honda");

            Product p7 = new Product();
            p7.SetId(7); p7.SetName("Honda City 2014-2019 Brake Pads"); p7.SetPrice(2200); p7.SetRemainingStock(15); p7.SetCategory("Honda");

            Product p8 = new Product();
            p8.SetId(8); p8.SetName("Honda CR-V 2017-2022 Cabin Filter"); p8.SetPrice(1200); p8.SetRemainingStock(20); p8.SetCategory("Honda");

            Product p9 = new Product();
            p9.SetId(9); p9.SetName("Honda Jazz 2014-2021 Side Mirror"); p9.SetPrice(4500); p9.SetRemainingStock(5); p9.SetCategory("Honda");

            Product p10 = new Product();
            p10.SetId(10); p10.SetName("Honda Accord 2013-2018 Radiator"); p10.SetPrice(6500); p10.SetRemainingStock(3); p10.SetCategory("Honda");

            // Mitsubishi
            Product p11 = new Product();
            p11.SetId(11); p11.SetName("Mitsubishi Montero 2016+ Brake Rotor"); p11.SetPrice(4200); p11.SetRemainingStock(8); p11.SetCategory("Mitsubishi");

            Product p12 = new Product();
            p12.SetId(12); p12.SetName("Mitsubishi Mirage G4 2013+ Radiator"); p12.SetPrice(5500); p12.SetRemainingStock(10); p12.SetCategory("Mitsubishi");

            Product p13 = new Product();
            p13.SetId(13); p13.SetName("Mitsubishi L300 1990+ Alternator"); p13.SetPrice(7500); p13.SetRemainingStock(5); p13.SetCategory("Mitsubishi");

            Product p14 = new Product();
            p14.SetId(14); p14.SetName("Mitsubishi Strada 2015+ Wiper Motor"); p14.SetPrice(4800); p14.SetRemainingStock(4); p14.SetCategory("Mitsubishi");

            Product p15 = new Product();
            p15.SetId(15); p15.SetName("Mitsubishi Adventure 2004+ Clutch"); p15.SetPrice(8500); p15.SetRemainingStock(6); p15.SetCategory("Mitsubishi");

            // Miscellaneous
            Product p16 = new Product();
            p16.SetId(16); p16.SetName("NGK Iridium Spark Plug Set (4pcs)"); p16.SetPrice(2400); p16.SetRemainingStock(50); p16.SetCategory("Miscellaneous");

            Product p17 = new Product();
            p17.SetId(17); p17.SetName("Motolite Gold 12V Car Battery"); p17.SetPrice(5200); p17.SetRemainingStock(8); p17.SetCategory("Miscellaneous");

            Product p18 = new Product();
            p18.SetId(18); p18.SetName("Denso Universal Horn Set (Pair)"); p18.SetPrice(1500); p18.SetRemainingStock(25); p18.SetCategory("Miscellaneous");

            Product p19 = new Product();
            p19.SetId(19); p19.SetName("Toyota/Mitsubishi Cabin Air Filter"); p19.SetPrice(450); p19.SetRemainingStock(100); p19.SetCategory("Miscellaneous");

            Product p20 = new Product();
            p20.SetId(20); p20.SetName("Brembo Dot 4 Brake Fluid 500ml"); p20.SetPrice(650); p20.SetRemainingStock(40); p20.SetCategory("Miscellaneous");

            Product[] products = new Product[]
            {
                p1, p2, p3, p4, p5,
                p6, p7, p8, p9, p10,
                p11, p12, p13, p14, p15,
                p16, p17, p18, p19, p20
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
                                            if (productID == products[i].GetId())
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
                                    if (SelectedProduct.GetRemainingStock() == 0)
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
                                                    if (cart[i].GetProduct().GetId() == SelectedProduct.GetId())
                                                    {
                                                        if (quantity > SelectedProduct.GetRemainingStock())
                                                            Console.WriteLine($"Not enough stock. Available: {SelectedProduct.GetRemainingStock()}");
                                                        else
                                                        {
                                                            cart[i].SetQuantity(cart[i].GetQuantity() + quantity);
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
                                                        CartItem newItem = new CartItem();
                                                        newItem.SetProduct(SelectedProduct);
                                                        newItem.SetQuantity(quantity);
                                                        cart[ItemsInCart] = newItem;
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
                            while (string.IsNullOrEmpty(searchTerm) || double.TryParse(searchTerm, out _))
                            {
                                if (string.IsNullOrEmpty(searchTerm))
                                    Console.WriteLine("Product name cannot be empty.");
                                else
                                    Console.WriteLine("Product name cannot be a number.");
                                Console.Write("Enter product name to search: ");
                                searchTerm = Console.ReadLine().ToLower();
                            }

                            bool found = false;
                            Console.WriteLine("\n|======= SEARCH RESULTS =======|");
                            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");

                            for (int i = 0; i < products.Length; i++)
                            {
                                if (products[i].GetName().ToLower().Contains(searchTerm))
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

                            int categoryChoice;
                            while (!int.TryParse(Console.ReadLine(), out categoryChoice) || categoryChoice < 1 || categoryChoice > 4)
                            {
                                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                                Console.Write("Enter category number (1-4): ");
                            }

                            string selectedCategory = "";
                            switch (categoryChoice)
                            {
                                case 1: selectedCategory = "Toyota"; break;
                                case 2: selectedCategory = "Honda"; break;
                                case 3: selectedCategory = "Mitsubishi"; break;
                                case 4: selectedCategory = "Miscellaneous"; break;
                            }

                            Console.WriteLine($"\n|======= {selectedCategory.ToUpper()} PRODUCTS =======|");
                            Console.WriteLine($"{"ID",-5} | {"NAME",-40} | {"CATEGORY",-15} | {"PRICE (PESOS)",15} | {"REMAINING STOCK",15}");

                            bool categoryFound = false;
                            for (int i = 0; i < products.Length; i++)
                            {
                                if (products[i].GetCategory() == selectedCategory)
                                {
                                    products[i].DisplayProduct();
                                    categoryFound = true;
                                }
                            }

                            if (!categoryFound)
                            {
                                Console.WriteLine("No products found in this category.");
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
                                                    double itemTotal = cart[i].GetProduct().GetItemTotal(cart[i].GetQuantity());
                                                    Console.WriteLine($"{i + 1}. [ID: {cart[i].GetProduct().GetId()}] {cart[i].GetProduct().GetName()} - x{cart[i].GetQuantity()} - P{itemTotal:N2}");
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
                                                    if (cart[i] != null && cart[i].GetProduct().GetId() == removeID)
                                                    {
                                                        cart[i].GetProduct().SetRemainingStock(cart[i].GetProduct().GetRemainingStock() + cart[i].GetQuantity());

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
                                                        double itemTotal = cart[i].GetProduct().GetItemTotal(cart[i].GetQuantity());
                                                        Console.WriteLine($"{i + 1}. [ID: {cart[i].GetProduct().GetId()}] {cart[i].GetProduct().GetName()} - x{cart[i].GetQuantity()} - P{itemTotal:N2}");
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
                                                                if (cart[i].GetProduct().GetId() == ProductID)
                                                                {
                                                                    foundInCart = true;
                                                                    bool validQty = false;
                                                                    while (!validQty)
                                                                    {
                                                                        Console.Write($"\nEnter new quantity for {cart[i].GetProduct().GetName()} (current: {cart[i].GetQuantity()}): ");
                                                                        if (int.TryParse(Console.ReadLine(), out int newQty))
                                                                        {
                                                                            if (newQty <= 0)
                                                                            {
                                                                                Console.WriteLine("Quantity must be greater than zero.");
                                                                            }
                                                                            else
                                                                            {
                                                                                int oldQty = cart[i].GetQuantity();
                                                                                int totalAvailable = cart[i].GetProduct().GetRemainingStock() + oldQty;

                                                                                if (newQty > totalAvailable)
                                                                                {
                                                                                    Console.WriteLine($"Not enough stock. Available stock: {totalAvailable}");
                                                                                }
                                                                                else
                                                                                {
                                                                                    cart[i].GetProduct().SetRemainingStock(totalAvailable - newQty);
                                                                                    cart[i].SetQuantity(newQty);
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
                                                        cart[i].GetProduct().SetRemainingStock(cart[i].GetProduct().GetRemainingStock() + cart[i].GetQuantity());
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
                                GrandTotal += cart[i].GetProduct().GetItemTotal(cart[i].GetQuantity());
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
                                double itemTotal = cart[i].GetProduct().GetItemTotal(cart[i].GetQuantity());
                                Console.WriteLine($"{cart[i].GetProduct().GetName(),-44} | {cart[i].GetQuantity(),4} | {cart[i].GetProduct().GetPrice(),10:N0} | {itemTotal,10:N2}");
                            }

                            Console.WriteLine($"\nGrand Total: P{GrandTotal:N2}");
                            Console.WriteLine($"Final Total: P{finalTotal:N2}");

                            string itemsSummary = "";
                            for (int i = 0; i < ItemsInCart; i++)
                            {
                                itemsSummary += $"{cart[i].GetProduct().GetName()} x{cart[i].GetQuantity()}, ";
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
                                if (products[i].GetRemainingStock() <= 5)
                                {
                                    Console.WriteLine($"LOW STOCK: {products[i].GetName()} has only {products[i].GetRemainingStock()} left.");
                                    hasLowStock = true;
                                }
                            }
                            if (!hasLowStock) Console.WriteLine("No low stock alerts.");

                            if (orderCount < 35)
                            {
                                OrderHistory order = new OrderHistory();
                                order.SetReceiptNumber(receiptNumber);
                                order.SetDate(DateTime.Now);
                                order.SetFinalTotal(finalTotal);
                                order.SetItemsSummary(itemsSummary.TrimEnd(',', ' '));
                                orderHistory[orderCount] = order;
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
                                    Console.WriteLine($"Receipt #{orderHistory[i].GetReceiptNumber():D4} - {orderHistory[i].GetDate():MMMM dd, yyyy h:mm tt} - Final Total: P{orderHistory[i].GetFinalTotal():N2}");
                                    Console.WriteLine($"Items: {orderHistory[i].GetItemsSummary()}");
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
                                    Console.WriteLine($"Receipt #{orderHistory[i].GetReceiptNumber():D4} - {orderHistory[i].GetDate():MMMM dd, yyyy h:mm tt} - Final Total: P{orderHistory[i].GetFinalTotal():N2}");
                                    Console.WriteLine($"Items: {orderHistory[i].GetItemsSummary()}");
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
