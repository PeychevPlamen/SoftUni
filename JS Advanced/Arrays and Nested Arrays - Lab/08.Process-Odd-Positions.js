function solve(input = []) {
    let arr = [];
    for (let i = 1; i < input.length; i+=2) {
        let doubledNum = input[i] * 2;
        arr.push(doubledNum);
        
    }
    return arr.reverse().join(' ');
}
console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));