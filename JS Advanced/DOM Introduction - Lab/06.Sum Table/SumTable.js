function sumTable() {

    let colCost = document.querySelectorAll('tbody td');

    let output = 0;
    let sum = document.getElementById('sum');

    for (let i = 1; i < colCost.length - 1; i += 2) {
        output += Number(colCost[i].textContent);
    }

    sum.textContent = output.toFixed(2);
}