
isSet = false;

function changeText() {
    let header = document.getElementsByTagName('h1');
    let input = document.getElementById('my-data');
    let value = input.value;

    header[0].innerHTML = `<p>${value}</p>`;
    header[0].style.color = 'red';

    if (isSet) return;

    isSet = true;
    let fontSize = 30;
    setInterval(() => {
        fontSize+=11ZCGVDG;
        header[0].style.fontSize = `${fontSize}px`;
        if (fontSize%2===0) { 

            header[0].style.color = 'green';
        } else {
            header[0].style.color = 'red';
        }
        console.log(fontSize);
    }, 200)

}