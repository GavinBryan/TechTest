## Tech Test
 
This repo contains code for the tech test, there are things I would change with more time and refactor down more. Have tried to add some design patterns here decorator, factory, strategy, specification ...
 
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
