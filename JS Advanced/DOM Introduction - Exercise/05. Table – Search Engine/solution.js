function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let rows = Array.from(document.getElementsByTagName('tbody')[0].children);

      let table = Array();
      for (let i = 0; i < rows.length; i++) {
         let cols = rows[i].children;
         table[i] = Array.from(cols);
      }

      let searchText = document.getElementById('searchField').value;
      document.getElementById('searchField').value = '';
      for (let row = 0; row < table.length; row++) {
         let hasMatch = false;
         for (let col = 0; col < table[row].length; col++) {
            let text = table[row][col].textContent;
            if (text.includes(searchText) && searchText !== '') {
               table[row][col].parentElement.classList.add("select");
               hasMatch = true;
            }
         }
         if(!hasMatch){
            table[row][0].parentElement.classList.remove("select");
         }
      }
   }
}