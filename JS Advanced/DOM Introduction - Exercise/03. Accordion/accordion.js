function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let extra = document.getElementById('extra');

    console.log(extra.style.display);
    console.log(button.textContent);
    if (button.textContent === 'More') {// &&  extra.style.display === 'none'
        extra.style.display = 'block';
        button.textContent = 'Less';
    } else if (button.textContent === 'Less') {// &&   extra.style.display === 'block'
        extra.style.display = 'none';
        button.textContent = 'More';
    }
}