function solve() {

  let textInput = Array.from(document.getElementById('text').value.split(' ')).map(x => x.toLowerCase());

  let convention = document.getElementById('naming-convention').value;

  let result = document.getElementById('result');

  if (convention === 'Camel Case') {

    result.textContent = textInput[0];

    for (let i = 1; i < textInput.length; i++) {

      let tempWord = textInput[i];

      for (let j = 0; j < tempWord.length; j++) {

        if (j === 0) {
          result.textContent += tempWord[0].toUpperCase();
        } else {

          result.textContent += tempWord[j].toLowerCase();
        }
      }
    }

  }
  else if (convention === 'Pascal Case') {
    
    for (let i = 0; i < textInput.length; i++) {

      let tempWord = textInput[i];

      for (let j = 0; j < tempWord.length; j++) {

        if (j === 0) {
          result.textContent += tempWord[0].toUpperCase();
        } else {

          result.textContent += tempWord[j].toLowerCase();
        }
      }
    }

  } else {
    result.textContent = 'Error!';
  }

}
// function solve() {

//   let text = [...document.getElementById('text').value.split(' ')].map(w => w.toLowerCase());
//   let currCase = document.getElementById('naming-convention').value;
//   let res;

//   if (currCase !== 'Camel Case' && currCase != 'Pascal Case') {
//       document.getElementById('result').textContent = 'Error!';
//   } else {

//       res = text.map(w => w.charAt(0).toUpperCase() + w.slice(1)).join('');

//       if (currCase === 'Camel Case') {
//           res = res.charAt(0).toLowerCase() + res.slice(1);
//       }


//       document.getElementById('result').textContent = res;

//   }
// }
