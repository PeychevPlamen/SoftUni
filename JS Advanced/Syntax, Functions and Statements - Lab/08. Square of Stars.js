function solve(input = 5) {
    let result= new Array();
    for (let i = 0; i < input; i++) {
        result[i] = ('*' + ' ').repeat(input).trimEnd();
    }
 
    console.log(result.join('\n'));
}

// solve(1);
// solve(2);
// solve(5);
// solve();