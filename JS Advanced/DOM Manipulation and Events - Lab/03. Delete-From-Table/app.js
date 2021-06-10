function deleteByEmail() {

    let email = document.querySelector('input[name="email"]').value;

    let allEmails = Array.from(document.querySelectorAll('tbody tr'));

    let isTrue = false;

    for (const row of allEmails) {

        if (row.children[1].textContent == email) {

            row.parentNode.removeChild(row);
            document.getElementById('result').textContent = 'Deleted.';
            
            isTrue = true;

        }
    }
    if (isTrue === false) {
        document.getElementById('result').textContent = 'Not found.';
    }
    document.querySelector('input[name="email"]').value = '';
}