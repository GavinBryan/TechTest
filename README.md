## Tech Test - Shopping Basket Discount Task
A company issues two types of voucher for customers to gain discounts on shopping baskets. 

**Gift Voucher**  
- Can be redeemed against the value of a basket.
- Multiple gift vouchers can be applied to a basket.

**Offer vouchers**  
- Have a threshold that needs to be matched or exceeded before a discount can be applied e.g. £5.00 off of baskets totalling £50
- Only a single offer voucher can be applied to a basket.
- Maybe applicable to only a subset of products.

**Functionality / Business Logic**
- Offer and Gift vouchers can be used in conjunction. 
- If a customer applies an offer voucher to a basket that will not satisfy the threshold or a customer removes item/changes an items quantity resulting in a voucher not being a message will need to be displayed to the customer.
- Gift vouchers can only be redeemed against non gift voucher products and purchase of gift vouchers do no contribute to discountable basket total.

**Task**  
- You need not create a UI for this application. 
- Write an application that represents a basket and has the ability to handle the following scenarios:

**Basket 1**\
1 Hat @ £10.50\
1 Jumper @ £54.65\
<ins>-------------</ins>\
1 x £5.00 Gift Voucher XXX-XXX applied\
<ins>-------------</ins>\
Total: £60.15\
<ins>-------------</ins>

**Basket 2**\
1 Hat @ £25.00\
1 Jumper @ £26.00\
<ins>-------------</ins>\
1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied\
<ins>-------------</ins>\
Total: £51.00\
<ins>-------------</ins>\
Message: “There are no products in your basket applicable to voucher Voucher YYY-YYY .”

**Basket 3**\
1 Hat @ £25.00\
1 Jumper @ £26.00\
1 Head Light (Head Gear Category of Product) @ £3.50\
<ins>-------------</ins>\
1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied\
<ins>-------------</ins>\
Total: £51.00\
<ins>-------------</ins>

**Basket 4**\
1 Hat @ £25.00\
1 Jumper @ £26.00\
<ins>-------------</ins>\
1 x £5.00 Gift Voucher XXX-XXX applied\
1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied\
<ins>-------------</ins>\
Total: £41.00\
<ins>-------------</ins>

**Basket 5**\
1 Hat @ £25.00\
1 £30 Gift Voucher @ £30.00\
<ins>-------------</ins>\
1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied\
<ins>-------------</ins>\
Total: £55.00\
<ins>-------------</ins>\
Message: “You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.”




## Solution 
 
This repo contains code for the tech test above, there are things I would change with more time and refactor down more. Have tried to add some design patterns here decorator, factory, strategy, specification ...
 
- Have created a shopping basket that handles different voucher types and has the ability to easily create new voucher types and have them applied to the shopping cart. This is done through a VoucherFactory.

- Vouchers have spefication property to decide if they can be applied to a cart and a strategy property which determines how they are applied to the cart.

- Have implemented the 5 basket examples from the tech test. 

- Gym.Tests has various unit tests and the BasketScenarioTests contains a test for each of the 5 basket examples (covering a lot of the logic for each basket example)

- Gym.Console runs the 5 basket examples as well and outputs a display property from the basket which shows the state of the basket.
     
| Project | Description |
| ------ | ------ |
| Gym.Ecommerce | Main functional logic |
| Gym.Tests | Some unit tests |
| Gym.Console | Console app that outputs 5 baskets from tech test |

Have added [FluentAssertions](https://www.nuget.org/packages/FluentAssertions/) for the unit tests 
