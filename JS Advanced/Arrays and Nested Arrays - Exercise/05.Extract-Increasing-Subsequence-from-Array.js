function solve(inputArr = []) {

    // let result = [];

    // for (let i = 0; i < inputArr.length; i++) {

    //     let tempNum = inputArr[i];

    //     if (tempNum >= result[result.length - 1] || result.length === 0) {
    //         result.push(tempNum);
    //     }

    // }

    // return result;

    return inputArr.reduce(function (result, currentValue) {
        if (currentValue >= result[result.length - 1] || result.length === 0) {
            result.push(currentValue);
        }
        return result;
    }, [])
}
console.log
    (solve(
        [1,
            3,
            8,
            4,
            10,
            12,
            3,
            2,
            24]
    ));

console.log
    (solve
        ([1,
            2,
            3,
            4]
        ));
console.log
    (solve(
        [20,
            3,
            2,
            15,
            6,
            1]
    ));