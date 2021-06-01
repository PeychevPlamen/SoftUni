function solve(inputArr = [], numRotation) {

    let temp;

    for (let i = 0; i < numRotation; i++) {

        temp = inputArr.pop(inputArr[0]);
        inputArr.unshift(temp);

    }

    return inputArr.join(' ');
}
console.log
    (solve(['1',
        '2',
        '3',
        '4'],
        2
    ));

console.log
    (solve(['Banana',
        'Orange',
        'Coconut',
        'Apple'],
        15
    ));