function solve(input = []) {

    let arr = [];
    let counter = 1;

    for (let i = 0; i < input.length; i++) {

        if (input[i] === 'add') {
            arr.push(counter);
        } else {
            arr.pop();
        }

        counter++;
    }
    
    if (arr.length > 0) {
        return arr.join('\n');
    } else {
        return 'Empty';
    }

}
console.log
    (solve(['add',
        'add',
        'add',
        'add']
    ));

console.log
    (solve(['add',
        'add',
        'remove',
        'add',
        'add']
    ));

console.log
    (solve(['remove',
        'remove',
        'remove']
    ));