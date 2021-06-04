function extractText() {
    const elements = [...document.getElementsByTagName('li')];
    const elementText = [...elements].map(x => x.textContent)
    const inputArea = document.getElementById('result');
    inputArea.value = elementText.join('\n');
}