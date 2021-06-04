function solve(matrix = [[]]) {

    let result = [];
    let sum;

    for (let i = 0; i < matrix.length; i++) {
        sum = 0;
        sum = matrix[i].reduce((acc, index) => acc + index, 0);
        result.push(sum);
    }

    for (let col = 0; col < matrix.length; col++) {
        sum = 0;
        for (let row = 0; row < matrix.length; row++) {

            sum += matrix[row][col];

        }
        result.push(sum);

    }

    return result.every((value, index, arr) => value === arr[0]);

}
console.log
    (solve([
        [4, 5, 6],
        [6, 5, 4],
        [5, 5, 5]]
    ));

console.log
    (solve([
        [11, 32, 45],
        [21, 0, 1],
        [21, 1, 1]]
    ));

console.log
    (solve([
        [1, 0, 0],
        [0, 0, 1],
        [0, 1, 0]]
    ));