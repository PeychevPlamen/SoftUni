function solve(input) {

    const regex = /\w+/gm;

    let text = input.toUpperCase().match(regex);

    return text.join(', ');
}
// console.log(solve('Hi, how are you?'));
// console.log(solve('hello'));