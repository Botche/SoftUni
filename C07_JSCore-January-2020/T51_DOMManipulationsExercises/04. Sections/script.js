function create(words) {
   let containerElement = document.getElementById('content');

   words.forEach(word => {
      let divElement = document.createElement('div');

      let paragraphElement = document.createElement('p');
      paragraphElement.style.display = 'none';
      paragraphElement.textContent = word;

      divElement.appendChild(paragraphElement);

      divElement.addEventListener('click', () => {
         paragraphElement.style.display = 'block';
      });

      containerElement.appendChild(divElement);
   });
}