window.addEventListener('load', solution);

function solution() {

  const fullName = document.getElementById('fname');
  const email = document.getElementById('email');
  const phone = document.getElementById('phone');
  const address = document.getElementById('address');
  const postalCode = document.getElementById('code');

  let fullNameValue = '';
  let emailValue = '';
  let phoneValue = '';
  let addressValue = '';
  let postalCodeValue = '';

  const submitBtn = document.getElementById('submitBTN');
  const continueBtn = document.getElementById('continueBTN');
  const editBtn = document.getElementById('editBTN');

  submitBtn.addEventListener('click', submit);

  function submit(e) {

    e.preventDefault();

    const ul = document.getElementById('infoPreview');

    const nameLi = document.createElement('li');

    nameLi.textContent = `Full Name: ${fullName.value}`;

    const emailLi = document.createElement('li');
    emailLi.textContent = `Email: ${email.value}`;

    const phoneLi = document.createElement('li');
    phoneLi.textContent = `Phone Number: ${phone.value}`;

    const addressLi = document.createElement('li');
    addressLi.textContent = `Address: ${address.value}`;

    const postalCodeLi = document.createElement('li');
    postalCodeLi.textContent = `Postal Code: ${postalCode.value}`;

    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (email.value == '' || fullName.value == '' || phone.value == '' || address.value == '' || postalCode.value == '' || !emailPattern.test(email.value)) {
      return;
    }
    ul.appendChild(nameLi);
    ul.appendChild(emailLi);
    ul.appendChild(phoneLi);
    ul.appendChild(addressLi);
    ul.appendChild(postalCodeLi);

    fullNameValue = fullName.value;
    emailValue = email.value;
    phoneValue = phone.value;
    addressValue = address.value;
    postalCodeValue = postalCode.value;

    fullName.value = '';
    email.value = '';
    phone.value = '';
    address.value = '';
    postalCode.value = '';

    submitBtn.disabled = true;

    continueBtn.disabled = false;

    editBtn.disabled = false;

    editBtn.addEventListener('click', edit);

    continueBtn.addEventListener('click', continueFunc);
  }



  function edit(e) {
    e.preventDefault();

    const ulTemp = document.getElementById('infoPreview');
    // const allLisToRemove = Array.from(document.querySelectorAll('li'));

    while (ulTemp.firstElementChild) {
      ulTemp.removeChild(ulTemp.firstElementChild);

    }


    fullName.value = fullNameValue;
    email.value = emailValue;
    phone.value = phoneValue;
    address.value = addressValue;
    postalCode.value = postalCodeValue;


    // for (const li of allLisToRemove) {
    //   li.remove();
    // }

    editBtn.disabled = true;
    continueBtn.disabled = true;
    submitBtn.disabled = false;
  }


  function continueFunc(e) {

    e.preventDefault();

    const h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';

    const block = document.getElementById('block');

    while (block.firstElementChild) {
      block.removeChild(block.firstElementChild);

    }

    block.appendChild(h3);


  }

}
