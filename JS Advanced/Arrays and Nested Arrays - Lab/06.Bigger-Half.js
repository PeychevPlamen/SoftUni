function solve(input) {

    input.sort((a, b) => a - b);
    let startIndex = Math.floor(input.length / 2);
    let result = input.slice(startIndex);

    return result;
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));