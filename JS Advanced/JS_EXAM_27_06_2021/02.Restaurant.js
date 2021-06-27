class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = Number(budgetMoney);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products = []) {

        products.forEach(product => {
            let [productName, productQuantity, productTotalPrice] = product.split(' ');
            productQuantity = Number(productQuantity);
            productTotalPrice = Number(productTotalPrice);

            if (productTotalPrice <= this.budgetMoney) {
                this.budgetMoney -= productTotalPrice;

                if (this.stockProducts[productName]) {
                    this.stockProducts[productName] += productQuantity
                } else {
                    this.stockProducts[productName] = productQuantity;
                }
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);

            }
        });

        return this.history.join("\n");
    }

    addToMenu(meal, neededProducts = [], price) {

        if (!this.menu[meal]) {

            let product = {}

            neededProducts.forEach(curentProduct => {
                let [productName, productQuantity] = curentProduct.split(" ");
                product[productName] = Number(productQuantity);
            })
            this.menu[meal] = {
                products: product,
                price: Number(price)
            }

            let meals = Object.keys(this.menu).length;

            if (meals === 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }
            else if (meals === 0 || meals >= 2) {
                return `Great idea! Now with the ${meal} we have ${meals} meals in the menu, other ideas?`;
            }
        } else {
            return `The ${meal} is already in the our menu, try something different.`;

        }
    }
    showTheMenu() {

        let meals = Object.keys(this.menu).length;

        if (meals === 0) {

            return "Our menu is not ready yet, please come later...";

        }
        else if (meals >= 1) {

            let menuArr = Object.entries(this.menu);
            let result = '';

            menuArr.forEach((meal, index) => {

                result += `${meal[0]} - $ ${meal[1].price}`;

                if (!index == menuArr.length - 1) {
                    result += "\n"
                }
            });

            return result;
        }
    }
    makeTheOrder(meal) {

        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let productCheck = this.menu[meal].products;

        let productEnable = true;

        for (const item in productCheck) {

            if (!productCheck.hasOwnProperty(item)) {
                productEnable = false;
                break;
            }
           

        }

       
        if (!productEnable) {
            for (const item in this.menu[meal].products) {
                this.stockProducts[item] -= this.menu[meal].products[item]
            }
            //this.budgetMoney += price;
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;


        } else {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }

    }
}

// let kitchen = new Restaurant(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// let kitchen = new Restaurant(1000);
// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

// let kitchen = new Restaurant(1000);
// console.log(kitchen.showTheMenu());



// let kitchen = new Restaurant(1000);
// kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
// kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
// console.log(kitchen.makeTheOrder('frozenYogurt'));
