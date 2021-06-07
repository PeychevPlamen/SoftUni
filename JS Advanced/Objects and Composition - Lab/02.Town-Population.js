function townPopulation(input = []) {

    const towns = {};

    for (const town of input) {

        let arr = town.split(' <-> ');
        let townName = arr[0];
        let population = Number(arr[1]);

        if (towns[townName] == undefined) {
            towns[townName] = population;
        } else {
            towns[townName] += population;
        }
    }

    for (const town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }
}
townPopulation
    (['Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000']
    );
townPopulation
    (['Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000']
    );