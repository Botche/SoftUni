function solve() {
   let result = document.getElementById('result').children;

   let firstPlayerResult = result[0];
   let secondPlayerResult = result[2];

   let firstPlayer = document.getElementById('player1Div');
   let secondPlayer = document.getElementById('player2Div');
   let history = document.getElementById('history');

   let firstPlayerCard = '';
   let secondPlayerCard = '';

   [firstPlayer, secondPlayer].map(player => player.addEventListener('click', (c) => {
      if (c.target.name === undefined || c.target.src.includes('images/whiteCard.jpg')) {
         return '';
      }

      if (firstPlayerResult.textContent !== '' && secondPlayerResult.textContent !== '') {
         defaultValues();
      }

      if ((player === firstPlayer && firstPlayerCard !== '') || (player === secondPlayer && secondPlayerCard !== '')) {
         return;
      }

      player === firstPlayer ?
         firstPlayerCard = showCard(firstPlayerCard, firstPlayerResult, c) :
         secondPlayerCard = showCard(secondPlayerCard, secondPlayerResult, c);

      if (firstPlayerResult.textContent !== '' && secondPlayerResult.textContent !== '') {
         Number(firstPlayerCard.name) > Number(secondPlayerCard.name) ?
            createBorder(firstPlayerCard, secondPlayerCard) :
            createBorder(secondPlayerCard, firstPlayerCard);

         saveHistory();
      }
   }));

   function defaultValues() {
      firstPlayerResult.textContent = '';
      secondPlayerResult.textContent = '';
      firstPlayerCard = '';
      secondPlayerCard = '';
   }

   function saveHistory() {
      history.textContent += `[${firstPlayerCard.name} vs ${secondPlayerCard.name}] `;
   }

   function createBorder(firstPlayerCard, secondPlayerCard) {
      firstPlayerCard.style.border = '2px solid green';
      secondPlayerCard.style.border = '2px solid red';
   }

   function showCard(playerCard, playerResult, c) {
      c.target.src = 'images/whiteCard.jpg';
      playerResult.textContent = c.target.name;
      playerCard = c.target;

      return playerCard;
   }
}