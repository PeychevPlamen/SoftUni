const pizzUni = require('../03.Pizza-Place');
const { assert, expect } = require('chai');

describe("Tests PizzaUni", function () {
    describe("test makeAnOrder", function () {

        it("test if ordered a pizza return correct message", function () {

            let obj = { orderedPizza: 'Pepperoni' };

            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza}`);
        });
        it("test if ordered a pizza and drinks return correct message", function () {

            let obj = { orderedPizza: 'Pepperoni', orderedDrink: 'Fanta' };

            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`);
        });
        it("test if ordered only drinks or nothing throw error", function () {

            let obj = { orderedDrink: 'Fanta' };
            let objEmpty = {};

            assert.throw(() => pizzUni.makeAnOrder(obj), 'You must order at least 1 Pizza to finish the order.');
            assert.throw(() => pizzUni.makeAnOrder(objEmpty), 'You must order at least 1 Pizza to finish the order.');

        });
    });
    describe("test getRemainingWork", function () {

        it("test if all orders are ready", function () {

            let pizzaOrders = [{ pizzaName: 'Margatira', status: 'ready' }, { pizzaName: 'Pepperoni', status: 'ready' }];

            assert.equal(pizzUni.getRemainingWork(pizzaOrders), 'All orders are complete!');
        });
        it("test if not all orders are ready", function () {

            let pizzaOrders = [{ pizzaName: 'Margatira', status: 'ready' }, { pizzaName: 'Pepperoni', status: 'preparing' }];

            const remainingArr = pizzaOrders.filter(s => s.status != 'ready');
            let pizzaNames = remainingArr.map(p => p.pizzaName).join(', ')

            assert.equal(pizzUni.getRemainingWork(pizzaOrders), `The following pizzas are still preparing: ${pizzaNames}.`);
        });

    });
    describe("test orderType", function () {

        it("test if type of order is Carry Out and total sum is correct", function () {

            let totalSum = 10;
            let typeOfOrder = 'Carry Out';
            let expectedResult = totalSum - totalSum * 0.1;

            assert.equal(pizzUni.orderType(totalSum, typeOfOrder),expectedResult);
        });
        it("test if type of order is Delivery and total sum is correct", function () {

            let totalSum = 10;
            let typeOfOrder = 'Delivery';
            let expectedResult = totalSum;

            assert.equal(pizzUni.orderType(totalSum, typeOfOrder),expectedResult);
        });

    });

});
