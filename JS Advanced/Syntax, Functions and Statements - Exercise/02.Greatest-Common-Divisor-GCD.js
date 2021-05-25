function solve(numFirst, numSecond) {
    let num1 = numFirst;
    let num2 = numSecond;
    let divisor = 0;

    if (num1 >= num2) {
        for (let i = 1; i <= num2; i++) {
            if (num1 % i === 0 && num2 % i === 0) {
                let tempNum = i;
                if (tempNum > divisor) {
                    divisor = tempNum;
                }
            }

        }
    }
    if (num1 <= num2) {
        for (let i = 1; i <= num1; i++) {
            if (num1 % i === 0 && num2 % i === 0) {
                let tempNum = i;
                if (tempNum > divisor) {
                    divisor = tempNum;
                }
            }

        }
    }
    console.log(divisor);
}
// solve(15, 5);
// solve(2154, 458);