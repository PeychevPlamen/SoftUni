function getInfo() {

    let stopIdInput = document.getElementById('stopId').value;
    let stopNameDiv = document.getElementById('stopName');
    let busesUl = document.getElementById('buses');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopIdInput}`)
        .then(body => body.json())
        .then(stopInfo => {
            stopNameDiv.textContent = stopInfo.name;

            Object.keys(stopInfo.buses).forEach(key => {
                let busesLi = document.createElement('li');
                busesLi.textContent = `Bus ${key} arrives in ${stopInfo.buses[key]}`;
                busesUl.appendChild(busesLi);
            })

        })
        .catch(err => {
            stopNameDiv.textContent = 'Error';
        })

    while (busesUl.firstChild) {
        busesUl.removeChild(busesUl.lastChild);
    }

}