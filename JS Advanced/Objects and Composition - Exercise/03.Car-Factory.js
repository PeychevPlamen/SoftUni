function carFactory(car) {

    const parts = {

        engine: {
            'Small engine': { power: 90, volume: 1800 },
            'Normal engine': { power: 120, volume: 2400 },
            'Monster engine': { power: 200, volume: 3500 }
        },
        carriage: {
            Hatchback: { type: 'hatchback', color: '' },
            Coupe: { type: 'coupe', color: '' }

        }
    }

    let engine = {};

    if (car.power <= 90) {
        engine = parts.engine['Small engine'];
    } else if (car.power <= 120) {
        engine = parts.engine['Normal engine']
    } else {
        engine = parts.engine['Monster engine'];
    }

    let carriage = {};

    if (car.carriage === 'hatchback') {
        carriage = parts.carriage.Hatchback;
    } else if (car.carriage === 'coupe') {
        carriage = parts.carriage.Coupe;
    }

    carriage.color = car.color;

    let wheel = 0;

    if (car.wheelsize % 2 === 0) {
        wheel = car.wheelsize - 1;
    } else {
        wheel = car.wheelsize;
    }

    const result = {
        model: car.model,
        engine,
        carriage,
        wheels: [wheel, wheel, wheel, wheel]
    }

    return result;
}
console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));
console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));