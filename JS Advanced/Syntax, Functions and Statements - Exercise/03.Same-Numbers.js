function solve(num) {

    let inputNum = num.toString();
    let sum = 0;
    let isEqual = true;

    for (let i = 0; i < inputNum.length - 1; i++) {

        if (inputNum[i] !== inputNum[i + 1]) {
            isEqual = false;
        }

        sum += Number(inputNum[i]);

    }
    sum += Number(inputNum[inputNum.length - 1]);

    console.log(isEqual);
    console.log(sum);

}
// solve(2222222);
// solve(1234);