function search() {

   let towns = document.querySelectorAll('#towns li');
   let searchInput = document.getElementById('searchText').value;
   let result = document.getElementById('result');

   let sum = 0;

   for (const town of towns) {

      if (town.textContent.includes(searchInput)) {

         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         sum++;
      }else{
         town.style.fontWeight = '';
         town.style.textDecoration = '';
      }

   }
   document.getElementById('searchText').value = '';
   result.textContent = `${sum} matches found`;

}
