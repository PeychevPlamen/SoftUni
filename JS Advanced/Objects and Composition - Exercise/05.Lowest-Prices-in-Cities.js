function lowestPrice(input = []) {

    let result = {};
    //let splittedArr = input.map(x => x.split(', '));

    for (const line of input) {

        let [town, product, price] = line.split(' | ');
        price = Number(price);

        result[product] ? result[product][town] = price : result[product] = { [town]: price };

    }

    for (const product in result) {

        let sorted = Object.entries(result[product]).sort((a, b) => a[1] - b[1]);
        console.log(`${product} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }
}
lowestPrice
    (['Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10']
    );