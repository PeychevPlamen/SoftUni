function solve(n, k) {

    let result = [1];
    let steps = Number(-k);
    
    for (let i = 1; i < n; i++) {

        let slicedArr = result.slice(steps);
        let sum = 0;

        for (let j = 0; j < slicedArr.length; j++) {

            sum += slicedArr[j];
        }

        result.push(sum);
    }

    return result;

}
console.log(solve(6, 3));
console.log(solve(8, 2));


// function solve(n, k) {

//     let resultArr = [1];

//     for (let index = 1; index < n; index++) {

//         let startIndex = Math.max(0, index - k);
//         let innerSequence = resultArr.slice(startIndex, index);
//         let sum = 0;

//         for (let j = 0; j < innerSequence.length; j++) {

//             sum += innerSequence[j];
//         }

//         resultArr.push(sum);
//     }

//     return (resultArr);
// }

// console.log(solve(6, 3));
// console.log(solve(8, 2));
