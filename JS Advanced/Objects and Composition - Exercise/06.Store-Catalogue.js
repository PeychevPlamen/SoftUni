function storeCatalogue(input) {

    let result = [];

    for (const item of input) {
        let [product, price] = item.split(' : ');
        price = Number(price);

        let currProduct = { product, price };
        result.push(currProduct);
    }

    result.sort((a, b) => a.product.localeCompare(b.product));

    let output = '';
    let firstChar = '';

    for (const item of result) {
        if (item.product[0] != firstChar) {
            firstChar = item.product[0];
            output += firstChar + '\n';
        }
        output += `  ${item.product}: ${item.price}\n`;
    }

    return output;
}
console.log(storeCatalogue
    (['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
    ));