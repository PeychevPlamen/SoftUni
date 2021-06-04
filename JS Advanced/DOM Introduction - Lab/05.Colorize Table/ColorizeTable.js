function colorize() {
    let tableRows = document.querySelectorAll('table tr');

    for (let i = 1; i < tableRows.length; i+=2) {
        tableRows[i].style.backgroundColor = 'Teal';
    }

    // [...document.querySelectorAll('table tr:nth-child(even)')].forEach(e => e.style.backgroundColor = 'teal');
}