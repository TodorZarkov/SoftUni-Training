function search() {
   let towns = document.getElementById('towns').children;

   towns = Array.from(towns);

   let searchText = document.getElementById("searchText").value;
   matches = 0;
   for (let town of towns) {
      let text = town.textContent;

      if (text.includes(searchText) && searchText !== '') {
         town.style.textDecoration = "underline";
         town.style.fontWeight = "bold";
         matches++;
      } else {
         town.style.textDecoration = "none";
         town.style.fontWeight = "normal";
      }
   }
   if (searchText !== '') {
      document.getElementById('result').textContent = `${matches} matches found`;
   } else {
      document.getElementById('result').textContent ='';
   }
}
