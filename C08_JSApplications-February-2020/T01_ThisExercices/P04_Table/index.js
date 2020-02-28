function solve(){
   let tableBodyListItems = document.querySelectorAll('.minimalistBlack tbody tr');
   let color = '#413f5e';

   Array.from(tableBodyListItems).forEach(item => item.addEventListener('click', (e) => {
      if(item.style.backgroundColor !== ''){
         item.style.backgroundColor = '';
      } else{
         Array.from(tableBodyListItems).forEach(item => item.style.backgroundColor = '');
         
         item.style.backgroundColor = color;
      }

   }));
}
