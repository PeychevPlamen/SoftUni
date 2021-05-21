function solve(n, m) {
    let numOne = Number(n);
    let numTwo = Number(m);
    let result = 0;

    for (let i = numOne; i <= numTwo; i++) {
        result += i;
    }
    console.log(result);
}
// solve('1', '5');
// solve('-8', '20');