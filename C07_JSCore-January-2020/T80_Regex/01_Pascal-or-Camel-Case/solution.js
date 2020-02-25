function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');

  let words = text.toLowerCase().split(' ').filter(x => x != '');
  let output = '';
  if (namingConvention === 'Pascal Case') {
    output += applyConvention(words[0]);
  } else if (namingConvention === 'Camel Case') {
    output += words[0];
  } else {
    result.textContent = 'Error!';
    return;
  }

  for (let wordIndex = 1; wordIndex < words.length; wordIndex++) {
    const word = words[wordIndex];
    output += applyConvention(word);
  }

  result.textContent = output;

  function applyConvention(word) {
    return word.replace(word[0], word[0].toUpperCase());
  }
}