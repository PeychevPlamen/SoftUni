function focused() {

    let currDiv = Array.from(document.querySelectorAll('input')).forEach(x => {
        x.addEventListener('focus', onFocus);
        x.addEventListener('blur', onBlur);
    });

    // let currDiv = document.querySelectorAll('input');

    // for (const div of currDiv) {
    //     div.addEventListener('focus', onFocus);
    //     div.addEventListener('blur', onBlur);
    // }

    function onFocus(event) {
        event.target.parentNode.className = 'focused';
    }

    function onBlur(event) {
        event.target.parentNode.className = '';
    }
}