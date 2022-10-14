function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;
  let words = text.split(/\s+/gm);

  let result = '';
  if (convention === 'Camel Case') {
    result = words[0].toLowerCase();
    for (let i = 1; i < words.length; i++) {
      let temp = words[i].toLowerCase();
      let temp2 = temp[0].toUpperCase();
      temp = temp.slice(1);
      result += (temp2 + temp);
    }
  }
  else if (convention === 'Pascal Case') {
    for (let word of words) {
      let temp = word.toLowerCase();
      let temp2 = temp[0].toUpperCase();
      temp = temp.slice(1);
      result += (temp2 + temp);
    }
  }
  else {
    result = 'Error!'
  }

  document.getElementById('result').textContent = result;


}