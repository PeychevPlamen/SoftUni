function solve(nums, arg) {

    const sort = {

        asc: (a, b) => (a - b),
        desc: (a, b) => (b - a),
    };

    return nums.sort(sort[arg]);

}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc')); 