function solve(inputArr = []) {

    inputArr.sort((a, b) => a.localeCompare(b));

    let result = [];

    for (let i = 0; i < inputArr.length; i++) {

        let temp = `${i + 1}.${inputArr[i]}`;
        result.push(temp);

    }

    return result.join('\n');

    // function solve(arr = []) {
    //     return arr
    //         .sort((a, b) => a.localeCompare(b))
    //         .map((value, index) => value = `${index + 1}.${value}`)
    //         .join('\n');
    
    // }
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));