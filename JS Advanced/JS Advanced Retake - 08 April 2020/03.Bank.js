class Bank {
    constructor(bankName) {

        this._bankName = bankName;
        this.allCustomers = [];

    }

    newCustomer(customer) {
        this.allCustomers.find((x) => {
            if (x.personalId == customer.personalId) {
                throw new Error(
                    `${customer.firstName} ${customer.lastName} is already our customer!`
                );
            }
        })
        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {

        
        let person = this.allCustomers.find((x) => x.personalId == personalId);
        let indexOfPerson = this.allCustomers.indexOf(person);

        if (indexOfPerson < 0) {

            throw new Error('We have no customer with this ID!');
        }

        if (this.allCustomers[indexOfPerson].hasOwnProperty('totalMoney')) {

            this.allCustomers[indexOfPerson].totalMoney += amount;

        } else {

            this.allCustomers[indexOfPerson].totalMoney = amount;
            this.allCustomers[indexOfPerson].transactionInfo = [];

        }

        let infoTrans = `${this.allCustomers[indexOfPerson].transactionInfo.length + 1}. ${this.allCustomers[indexOfPerson].firstName} ${this.allCustomers[indexOfPerson].lastName} made deposit of ${amount}$!`;

        this.allCustomers[indexOfPerson].transactionInfo.push(infoTrans);

        return `${this.allCustomers[indexOfPerson].totalMoney}$`;

    }

    withdrawMoney(personalId, amount) {

        let person = this.allCustomers.find((x) => x.personalId == personalId);
        let indexOfPerson = this.allCustomers.indexOf(person);

        if (indexOfPerson < 0) {

            throw new Error('We have no customer with this ID!');
        }

        if (this.allCustomers[indexOfPerson].totalMoney < amount) {

            throw new Error(`${this.allCustomers[indexOfPerson].firstName} ${this.allCustomers[indexOfPerson].lastName} does not have enough money to withdraw that amount!`);

        } else {

            this.allCustomers[indexOfPerson].totalMoney -= amount;

            let infoTrans = `${this.allCustomers[indexOfPerson].transactionInfo.length + 1}. ${this.allCustomers[indexOfPerson].firstName} ${this.allCustomers[indexOfPerson].lastName} withdrew ${amount}$!`;

            this.allCustomers[indexOfPerson].transactionInfo.push(infoTrans);

            return `${this.allCustomers[indexOfPerson].totalMoney}$`;

        }
    }

    customerInfo(personalId) {

        let person = this.allCustomers.find((x) => x.personalId == personalId);
        let indexOfPerson = this.allCustomers.indexOf(person);

        if (indexOfPerson < 0) {

            throw new Error('We have no customer with this ID!');
        }

        this.allCustomers[indexOfPerson].transactionInfo.reverse();

        let result = [];

        result.push(`Bank name: ${this._bankName}\nCustomer name: ${this.allCustomers[indexOfPerson].firstName} ${this.allCustomers[indexOfPerson].lastName}\nCustomer ID: ${personalId}\nTotal Money: ${this.allCustomers[indexOfPerson].totalMoney}$\nTransactions:\n${this.allCustomers[indexOfPerson].transactionInfo.join('\n')}`);

        return result.join().trimEnd();
    }

}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

