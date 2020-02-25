function solve() {
  let text = document.getElementById('text').value;
  let result = document.getElementById('result');

  let words = text.split(' ').filter(x => x != '');

  let asciiCodes = '';
  
  words.forEach(word => {
    if(Number(word)){
      asciiCodes+=(String.fromCharCode(word));
    } else{
      let ascii = [];
      
      for (let i = 0; i < word.length; i++) {
        ascii.push(word[i].charCodeAt(0));
      }

      let p = document.createElement('p');
      p.textContent = ascii.join(' ');
      result.appendChild(p);
    }
  });

  let p = document.createElement('p');
  p.textContent = asciiCodes;
  result.appendChild(p);
}