function townsToJSON(input) {

    let result = [];

    for (let i = 1; i < input.length; i++) {

        let [town, latitude, longitude] = input[i].split('|').filter(x => x != '').map(x=> x.trim());

        //town = town.trim();
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        let currObj = {
            Town: town,
            Latitude: Number(latitude),
            Longitude: Number(longitude)
        };

        result.push(currObj);
    }

    return JSON.stringify(result);
}
console.log(townsToJSON
    (['| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |']
    ));