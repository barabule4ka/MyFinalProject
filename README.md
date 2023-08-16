# Prestashop UI tests

This is the solution with UI tests for [Prestashop - online shop with  woman clothes](http://prestashop.qatestlab.com.ua/ru/) (RU)

## Test set

#### E2e tests:
- Make order from real user account
- Make order from new user

#### Other tests
- several login tests
- change languge test
- check cart test
- create different entities (user, address)

## Approaches used to build a framework and tests

- Driver Factory
- Browser
- Page Object
- Builder (for models)
- Chain of invocation
- Bogus

## Technologies used in solution
- NUnit - test framework
- Nlog - for logging
- Bogus - for generating fake test data
- Allure - for reports
- Selenium - for browser actions automation 

## Configuration

Use ```appsettings.json``` file to set configuration and real user credentials

## Installation

1. Register new user on [Prestashop](http://prestashop.qatestlab.com.ua/ru/), later you'll need to save users credentials in ```appsettings.json```.
2. Create new delivery address for this user.
3. Clone this repository
4. Open solution in suiteable IDE
5. Edit configuration files
6. Build solution and run tests
7. Have a good day:)

## Author
Barabule4ka
