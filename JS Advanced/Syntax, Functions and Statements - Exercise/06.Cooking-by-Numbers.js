function solve(num, opOne, opTwo, opThree, opFour, opFive) {

    let currNum = Number(num);
    let operations = [opOne, opTwo, opThree, opFour, opFive];
    let result = [];

    for (let i = 0; i < operations.length; i++) {

        let currOp = operations[i];

        if (currOp === 'chop') {

            result.push(currNum /= 2);
        }
        else if (currOp === 'dice') {

            result.push(currNum = Math.sqrt(currNum))
        }
        else if (currOp === 'spice') {

            result.push(currNum += 1);
        }
        else if (currOp === 'bake') {

            result.push(currNum *= 3);
        }
        else if (currOp === 'fillet') {

            result.push((currNum *= 0.8).toFixed(1));
        }
    }

    return result.join('\n');

}

// console.log(solve('32', 'chop', 'chop', 'chop', 'chop', 'chop'))
// console.log(solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet'))