function addItem() {

    let input = document.getElementById('newItemText').value;
    let liElement = createEl('li', input);

    const deleteBtn = createEl('a', '[Delete]');
    deleteBtn.href = '#';
    deleteBtn.addEventListener('click', (ev) => {
        ev.target.parentNode.remove();
    })
    liElement.appendChild(deleteBtn);

    document.getElementById('items').appendChild(liElement);
    document.getElementById('newItemText').value = '';


    function createEl(type, content) {

        const element = document.createElement(type);
        element.textContent = content;
        return element;
    }

}
