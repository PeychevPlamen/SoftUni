function solve() {

  const textArea = document.getElementById('input').value.split('.').filter(e => e.length >= 1);
  //const button = document.getElementById('formatItBtn');
  const output = document.getElementById('output');

  let result = [];

  while (textArea.length > 0) {

    result.push(textArea.splice(0, 3).join('.') + '.');

  }

  result.forEach(p => (output.innerHTML += `<p>${p}</p>`));
}