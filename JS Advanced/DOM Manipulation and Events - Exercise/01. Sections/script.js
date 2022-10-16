function create(words = []) {
   let content = document.getElementById('content');
   words.forEach(word=>{
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.textContent = word;
      p.style.display = 'none';
      div.appendChild(p);
      content.appendChild(div);
      
   })
   content.addEventListener('click',onClick);
   
   function onClick(event){
      event.target.children[0].style.display= 'block'
   }
}
