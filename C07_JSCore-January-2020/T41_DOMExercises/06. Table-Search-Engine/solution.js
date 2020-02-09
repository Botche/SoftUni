function solve() {
   let searchBtn = document.getElementById('searchBtn');
   let searchInput = document.getElementById('searchField')

   searchBtn.addEventListener('click', ()=>{
      let selectedRows = document.getElementsByClassName('select');
      for (let row = 0; row < selectedRows.length; row++) {
         selectedRows[row].removeAttribute('class');
      }

      let rows = document.getElementsByTagName('tbody')[0].rows;

      for (let row = 0; row < rows.length; row++) {
         const cells = rows[row].cells;
         
         for (let cell = 0; cell < cells.length; cell++) {
            const element = cells[cell].textContent;

            if (element.includes(searchInput.value)) {
               rows[row].setAttribute('class', 'select');
               break;
            }

         }
      }

      searchInput.value = '';

   });
}