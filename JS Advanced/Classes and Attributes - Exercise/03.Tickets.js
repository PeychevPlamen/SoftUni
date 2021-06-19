function tickets(arr = [], sortingCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];
    let currTicket = [];

    arr.map(x => {
        let [destination, price, status] = x.split('|');
        currTicket = new Ticket(destination, price, status);
        tickets.push(currTicket);
    })

    tickets.sort((a, b) => {
        if (typeof a[sortingCriteria] === 'number') {
            return a[sortingCriteria] - b[sortingCriteria];
        } else {
            return a[sortingCriteria].localeCompare(b[sortingCriteria]);
        }
    })


    return tickets;

}
console.log(tickets
    (['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
        'destination'
    ));