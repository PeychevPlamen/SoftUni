function solve() {

    let spanInfo = document.querySelector('#info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');
    let stopId = 'depot';
    let stopName = '';

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${stopId}`)
            .then(res => res.json())
            .then(data => {
                stopId = data.next;
                stopName = data.name;
                spanInfo.textContent = `Next stop ${stopName}`;
            })
            .catch(() => {
                departBtn.disabled = true;
                arriveBtn.disabled = true;
                spanInfo.textContent = 'Error';
            })
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {
        departBtn.disabled = false;
        arriveBtn.disabled = true;
        spanInfo.textContent = `Arriving at ${stopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();