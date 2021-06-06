function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let tableRows = document.querySelectorAll('tbody tr');
      let inputField = document.getElementById('searchField').value;
      //let button = document.querySelector('#searchBtn');
      
      for (const row of tableRows) {

         if (row.textContent.includes(inputField)) {

            row.classList.add('select');
            
         } else {
            row.removeAttribute('class');
         }
      }
      document.getElementById('searchField').value = '';
   }
}