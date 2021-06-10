function addItem() {
    
    let newItemText = document.getElementById('newItemText').value;
    let items = document.getElementById('items');
    
    let newElement = el('li', newItemText);
    let deleteButon = el('a', '[Delete]');

    deleteButon.setAttribute('href', '#');
    newElement.appendChild(deleteButon);
    items.appendChild(newElement);
    newItemText.value = '';

    items.addEventListener('click', (e) => {
        if (e.target.nodeName == 'A') {
            e.target.parentElement.remove()
        }
    });

    function el(type, content) {
        let element = document.createElement(type);

        if (typeof content === 'string') {
            element.textContent = content;
        } else {
            element.appendChild(content);
        }
        return element;
    }
}