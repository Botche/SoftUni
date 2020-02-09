function solve() {
  const rightAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let displayedAnswers = document.getElementsByClassName('answer-text');
  
  let sections = document.getElementsByTagName('section');
  let mainContainer = document.getElementById('quizzie');

  let counter = 0;
  let countOfCorrectAnswers = 0;

  mainContainer.addEventListener('click', (e) => {
    let target = e.target;

    if (Array.from(displayedAnswers).includes(target)) {
      sections[counter].style.display = 'none';

      if (target.textContent === rightAnswers[counter]) {
        countOfCorrectAnswers++;
      }

      counter++;
      if (counter < sections.length) {
        sections[counter].style.display = 'block';
      } else{
        let result = document.getElementById('results');
        let resultElement = document.getElementsByTagName('h1')[1];

        resultElement.textContent = countOfCorrectAnswers === sections.length ?
          'You are recognized as top JavaScript fan!' :
          `You have ${countOfCorrectAnswers} right answers`;

          result.style.display = 'block';
      }
    }
  });
}
