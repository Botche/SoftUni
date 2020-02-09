function solve() {
   let button = document.getElementById('send');
   let message = document.getElementById('chat_input');
   let chat = document.getElementById('chat_messages');

   button.addEventListener('click', () => {
      let messageContainer = document.createElement('div');
      messageContainer.setAttribute('class', 'message my-message');
      messageContainer.textContent = message.value;

      chat.appendChild(messageContainer);

      message.value = '';
   });
}