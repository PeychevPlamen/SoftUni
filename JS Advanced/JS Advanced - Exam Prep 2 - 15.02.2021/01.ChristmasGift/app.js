function solution() {

    let giftName = document.querySelector('input');
    let ul = document.querySelectorAll('ul');

    document.querySelector('button').addEventListener('click', addGift);

    function addGift(e) {

        e.preventDefault();

        let li = document.createElement('li');

        let addBtn = document.createElement('button');
        addBtn.textContent = 'Send';
        addBtn.classList.add('sendButton');

        addBtn.addEventListener('click', send);

        let discardBtn = document.createElement('button');
        discardBtn.textContent = 'Discard';
        discardBtn.classList.add('discardButton');

        discardBtn.addEventListener('click', discard);

        li.classList.add('gift');
        li.textContent = giftName.value;
        li.appendChild(addBtn);
        li.appendChild(discardBtn);
        ul[0].appendChild(li);
        giftName.value = '';

        
        sortGift();
    }

    function sortGift() {

        Array.from(ul[0].children).sort((a, b) => a.textContent.localeCompare(b.textContent)).forEach((gift) => { ul[0].appendChild(gift) });

    }

    function send(e) {

        const li = e.target.parentNode;
        li.removeChild(li.childNodes[1]);
        li.removeChild(li.childNodes[1]);
        ul[1].appendChild(li);

    }

    function discard(e) {

        const li = e.target.parentNode;
        li.removeChild(li.childNodes[1]);
        li.removeChild(li.childNodes[1]);
        ul[2].appendChild(li);

    }
}