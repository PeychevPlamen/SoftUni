function solve(inputArr) {
    let operands = [];
    for (const item of inputArr) {
        if (typeof item === 'number') {
            operands.push(item);
        } else {
            if (operands.length < 2) {
                return 'Error: not enough operands!';
            }
            let operand2 = operands.pop();
            let operand1 = operands.pop();
            let result = applyArithmeticOperation(operand1, operand2, item);
            operands.push(result);
        }
    }

    return `${operands.length > 1 ? 'Error: too many operands!' : operands[0]}`;

    function applyArithmeticOperation(operand1, operand2, operator) {
        const getOperation = {
            '*': () => operand1 * operand2,
            '/': () => operand1 / operand2,
            '+': () => operand1 + operand2,
            '-': () => operand1 - operand2,
        };

        return getOperation[operator]();
    }
}
console.log(solve
    ([3,
        4,
        '+']
    ));

console.log(solve
    ([5,
        3,
        4,
        '*',
        '-']
    ));