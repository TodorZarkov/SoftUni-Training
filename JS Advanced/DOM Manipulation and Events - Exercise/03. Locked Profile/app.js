function lockedProfile() {
    let main = document.getElementById('main');
    main.addEventListener('click', onClick);

    function onClick(event) {
        let clickElement = event.target;
        if (clickElement.tagName !== 'BUTTON') {
            return;
        }

        console.log(clickElement.parentElement.querySelector('input[type="radio"][value="lock"]'));
        //let lockBtn = clickElement.parentElement.querySelector('input[type="radio"][value="lock"]');
        let unlockBtn = clickElement.parentElement.querySelector('input[type="radio"][value="unlock"]');
        if (unlockBtn.checked) {
            if (clickElement.textContent === 'Show more') {
                clickElement.textContent = 'Hide it';
                clickElement.parentElement.querySelector('div[id]').style.display = 'block';
            } else if (clickElement.textContent === 'Hide it') {
                clickElement.textContent = 'Show more';
                clickElement.parentElement.querySelector('div[id]').style.display = 'none';
            }
        }

    }
}