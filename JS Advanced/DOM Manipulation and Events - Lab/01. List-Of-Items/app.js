function addItem() {

    let inputField = document.getElementById('newItemText').value;
    
    let list = document.getElementById('items');

    let newEl = document.createElement('li');
    newEl.textContent = inputField;

    list.appendChild(newEl);

    document.getElementById('newItemText').value = '';

}