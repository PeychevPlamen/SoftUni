function attachEvents() {

    let ulPhonebook = document.getElementById('phonebook');

    let inputPerson = document.getElementById('person');
    let inputPhone = document.getElementById('phone');

    let loadBtn = document.getElementById('btnLoad');
    let createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', loadContacts);
    createBtn.addEventListener('click', createContact);

    let urlContacts = 'http://localhost:3030/jsonstore/phonebook';

    async function loadContacts() {
        try {

            let allContactsRequest = await fetch(urlContacts);
            let allContacts = await allContactsRequest.json();

            // console.log(allContacts);

            while (ulPhonebook.firstChild) {
                ulPhonebook.removeChild(ulPhonebook.lastChild);
            }

            Object.values(allContacts).map(createLis);

            function createLis({ person, phone, _id }) {

                let li = document.createElement('li');
                li.textContent = `${person}: ${phone}`;
                li.id = _id;
                let deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                deleteBtn.addEventListener('click', deleteContact)
                ulPhonebook.appendChild(li);
                li.appendChild(deleteBtn);
            }

            async function deleteContact(e) {
                let id = e.target.parentNode.id;
                let liToDelete = e.target.parentNode;

                let response = await fetch(`http://localhost:3030/jsonstore/phonebook/` + id, {
                    method: 'delete',
                });

                //let deleteContact = await response.json();
                liToDelete.remove();

                //console.log(deleteContact);

            }

        } catch (error) {
            console.error(error);
        }
    }

    async function createContact() {
        try {
            if (inputPerson.value === '' && inputPhone.value === '') {
                throw new Error('Empty input fields');
            }

            let contactToAdd = {
                person: inputPerson.value,
                phone: inputPhone.value
            };

            await fetch(urlContacts, {
                method: 'Post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(contactToAdd)
            });

            inputPerson.value = '';
            inputPhone.value = '';

            await loadContacts();


        } catch (error) {
            console.error(error);
        }
    }

}

attachEvents();