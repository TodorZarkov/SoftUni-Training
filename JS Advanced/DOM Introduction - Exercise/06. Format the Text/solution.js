function solve() {
  let inputText = document.getElementById('input').value;
  let sentences = inputText.split('.').filter((text => text));
  let resultText = '';
  let temp = '';
  for (let i = 1; i <= sentences.length; i++) {
    temp += sentences[i-1]+'.';
    if ((i % 3 === 0) || i === sentences.length) {
      resultText += `<p>${temp}</p>`;
      temp = '';
    }
  }

  document.getElementById('output').innerHTML=resultText;

}