function lockedProfile() {
    
    let btns = Array.from(document.getElementsByTagName('button'));

    for (const btn of btns) {

        btn.addEventListener('click', onCLick);
    }


    function onCLick(event) {

        let button = event.target;

        let lock = event.target.parentNode.getElementsByTagName('input')[0];

        if (!lock.checked) {

            if (button.textContent === 'Show more') {

                button.textContent = 'Hide it';
                button.previousElementSibling.style.display = 'block';

            } else if (button.textContent = 'Hide it') {

                button.textContent = 'Show more';
                button.previousElementSibling.style.display = 'none';
            }
        }


    }
}