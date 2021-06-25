function solution() {

    let btn = document.querySelector('.card button');
    const inputField = document.querySelector('.card input');
    const sections = document.querySelectorAll('.card');
    const ul = document.querySelectorAll('ul');

    btn.addEventListener('click', addGift);

    function addGift(e) {
        e.preventDefault();

        const lis = document.createElement('li');
        lis.classList.add('gift');
        lis.textContent = inputField.value;
        const addBtn = document.createElement('button');
        addBtn.id = 'sendButton';
        // same as  addBtn.setAttribute('id', 'sendButton');
        addBtn.textContent = 'Send';
        const discardBtn = document.createElement('button');
        discardBtn.id = 'discardButton';
        discardBtn.textContent = 'Discard';

        lis.appendChild(addBtn);
        lis.appendChild(discardBtn);

        ul[0].appendChild(lis);
        inputField.value = '';

        addBtn.addEventListener('click', sentGifts);
        discardBtn.addEventListener('click', discardGifts);

        sortFunk();


    }

    function sortFunk() {

        Array.from(ul[0].children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach((gifts) => ul[0].appendChild(gifts));
    }

    function sentGifts(e) {

        const li = e.target.parentNode;

        li.removeChild(li.childNodes[1]);
        li.removeChild(li.childNodes[1]);

        ul[1].appendChild(li);



    }

    function discardGifts(e) {

        const li = e.target.parentNode;

        li.removeChild(li.childNodes[1]);
        li.removeChild(li.childNodes[1]);

        ul[2].appendChild(li);

    }

}