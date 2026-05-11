# Bernardo, Ivan Louise S. | BSIT 1-2 Computer Programming 2

A shopping cart system for an auto parts store. Products include headlights, taillights, from car models such as Vios, Innova, Fortuner and more car brands and car models.

**Language Used:** C#

# Shopping Cart System Program Part 1

## AI Usage

AI was used but only as a guide. AI was not directly tasked to generate the code, instead it was only used as a guide to help me build the shopping cart system from scratch. In some parts like creating methods and classes, since I still had no idea, I asked AI what their uses were and how I could apply them in my program.

**Prompts/questions I asked:**
- "How do classes and methods work in C#?"
- "How to apply int.TryParse() for input validation?"
- "How to use the out keyword in int.TryParse()?"
- "How to check for duplicate arrays?"
- "How to create arrays using a class (e.g., Product[], CartItem[])?"
- "How to call methods from a class (e.g., DisplayProduct(), HasEnoughStock(), DeductStock(), GetItemTotal())?"

**Changes I made after using AI:**
AI helped me to understand classes and methods better, but I came up with an idea to make it into a auto parts store. I used my own knowledge to build the logic, chose the products, designed the store layout, and structured the cart system myself. I reviewed my code to ensure a better understanding of the program.

# Shopping Cart System Program Part 2

## AI Usage

AI was used still as a guide and as a tool to help debug and improve the program. There were times I still felt lost on how to fix certain issues, but with the help of AI, I was able to solve those problems. AI was not directly tasked to generate the code, instead it was used to point out bugs and logical errors in my program and guide me toward the correct fix. I would provide my code and AI would help me understand what was wrong and how to approach the solution.

**Prompts/questions I asked:**
- "How do I implement cart management features like removing and updating items?"
- "How do I store and display order history using arrays?"
- "How do I debug loop and validation issues in my program?"
- "Is there any major bugs in my program? (provided my code)"
- "How do I fix the loop issue that prevented the main menu from working correctly after adding items?"
- "How do I handle out of stock products with a Y/N prompt to try a different product?"
- "How do I store and display order history with receipt number, date, and final total?"
- "How do I fix stock restoration when removing or clearing items from the cart?"
  
**Changes I made after using AI:**
AI helped me fix bugs and problems that I could not figure out on my own. With the help of AI, I was able to fix issues like the main menu not working properly after adding items, handling out of stock products with a Y/N prompt, making sure the stock goes back to normal when items are removed or the cart is cleared, and fixing the validation for all menus and Y/N prompts. I still came up with my own ideas and improvements, and I only used AI when I was stuck on something. I also made sure to read and understand every fix so I know what was changed and why.

## Part 2 Features

**Main Menu**
- Main menu with 7 options (Add Item, Search, Filter by Category, Cart Management, Checkout, Order History, Exit)

**Add Item system**
- Add items to cart by product ID
- Merges quantity if item already exists in cart
- Validates product ID and quantity
- Handles out of stock products with option to try a different product

**Cart Management Menu**
- View cart contents
- Remove specific item from cart with stock restoration
- Update item quantity with stock restoration
- Clear entire cart with confirmation prompt

**Search and Filter**
- Search products by name using partial matching
- Filter products by category (Toyota, Honda, Mitsubishi, Miscellaneous)

**Checkout System**
- Prevents checkout if cart is empty
- Calculates grand total, 10% discount for orders P5,000 and above, and final total
- Validates payment input and ensures sufficient amount
- Calculates and displays change

**Receipt System**
- Generates receipt number
- Displays date and time
- Shows itemized purchase with name, quantity, unit price, and total
- Displays grand total, final total after discount

**Order History**
- Stores up to 35 completed transactions
- Displays receipt number, date, final total, and items per transaction
- Viewable anytime from the main menu

**Low Stock Alert**
- Warns when product stock is 5 or below after checkout

**Better implementation of validation on menu options**
- Strict input validation for all menus and Y/N prompts
- Confirmation prompt for clearing cart and exiting the program
- Continue shopping prompt after checkout
