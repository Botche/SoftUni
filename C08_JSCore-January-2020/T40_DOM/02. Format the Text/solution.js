function solve() {
  let textToFormat = document.getElementById('input').textContent;
  let output = document.getElementById('output');

  let parsedText = textToFormat.split('.').filter(x => x != '');

  let paragraph = document.createElement('p');
  for (let index = 0; index < parsedText.length; index++) {
    const element = parsedText[index];
    paragraph.textContent += element + '.';

    if ((index + 1) % 3 === 0) {
      output.appendChild(paragraph);
      paragraph = document.createElement('p');
    }
  }
  if (paragraph.textContent != '') {
    output.appendChild(paragraph);
    paragraph = document.createElement('p');
  }
}