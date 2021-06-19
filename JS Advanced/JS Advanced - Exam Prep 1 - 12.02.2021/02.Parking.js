class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];

    }

    addCar(carModel, carNumber) {
        if (this.capacity > 0) {

            let car = {
                carModel,
                carNumber,
                payed: false
            };

            this.vehicles.push(car);
            this.capacity--;

            return `The ${carModel}, with a registration number ${carNumber}, parked.`;

        } else {
            throw new Error('Not enough parking space.');
        }
    }

    removeCar(carNumber) {

        let index = this.vehicles.findIndex((car) => car.carNumber == carNumber);

        if (index < 0) {
            throw new Error("The car, you're looking for, is not found.");
        }
        else if (this.vehicles[index].payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles.splice(index, 1);
        this.capacity++;
        return `${carNumber} left the parking lot.`;


    }

    pay(carNumber) {

        let index = this.vehicles.findIndex((car) => car.carNumber == carNumber);

        if (index < 0) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        } else if (this.vehicles[index].payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        this.vehicles[index].payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;

    }

    getStatistics(carNumber) {

        if (carNumber) {

            let index = this.vehicles.findIndex((car) => car.carNumber == carNumber);
            
            return `${this.vehicles[index].carModel} == ${carNumber} - ${this.vehicles[index].payed == false ? 'Not payed' : 'Has payed'}`;
        }

        return [
            `The Parking Lot has ${this.capacity} empty spots left.`,
            this.vehicles
                .sort((a, b) => a.carModel.localeCompare(b.carModel))
                .map((car) => `${car.carModel} == ${car.carNumber} - ${car.payed == false ? 'Not payed' : 'Has payed'}`)
                .join('\n')
        ].join('\n');

    }

}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());
console.log(parking.removeCar("TX3691CA"));
console.log(parking.pay("TX3691CA"));
