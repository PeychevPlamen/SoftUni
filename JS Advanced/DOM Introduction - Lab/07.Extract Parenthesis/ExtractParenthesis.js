function extract(content) {

    let text = document.getElementById('content').textContent;

    const regex = /\((.+?)\)/gm;
    let outputText = regex.exec(text);
    let result = [];

    while (outputText != null) {

        result.push(outputText[1]);
        
        outputText = regex.exec(text);
    }

  return result.join('; ');

}