function solve(inputOne, inputTwo, operator) {
    let result;
    if (operator === '+') {
        result = inputOne + inputTwo;
    }
    else if (operator === '-') {
        result = inputOne - inputTwo;
    }
    else if (operator === '*') {
        result = inputOne * inputTwo;
    }
    else if (operator === '/') {
        result = inputOne / inputTwo;
    }
    else if (operator === '%') {
        result = inputOne % inputTwo;
    }
    else if (operator === '**') {
        result = Math.pow(inputOne, inputTwo);
    }
    console.log(result);
}
// solve(5, 6, '+');
// solve(3, 5.5, '*');
// solve(2, 2, '**');