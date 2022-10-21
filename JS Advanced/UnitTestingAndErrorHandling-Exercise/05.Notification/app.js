function notify(message) {
  let theDiv = document.getElementById('notification');
  
  theDiv.textContent = message;
  theDiv.style.display = 'block';

  theDiv.addEventListener('click',onClickOverTheDiv);

  function onClickOverTheDiv(event){
    theDiv.style.display = 'none';
  }
}