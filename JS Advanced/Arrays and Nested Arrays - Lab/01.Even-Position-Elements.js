function solve(input) {

    let arr = input;
    let outputArr = [];

    for (let i = 0; i < arr.length; i += 2) {

        outputArr.push(arr[i]);
    }

    return outputArr.join(' ');
}

console.log(solve(['20', '30', '40', '50', '60']));
console.log(solve(['5', '10']));