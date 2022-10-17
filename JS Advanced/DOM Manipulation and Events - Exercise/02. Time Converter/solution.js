function attachEventsListeners() {

    let main = document.querySelector('main');
    main.addEventListener('click', (event)=>{
        let daysField = document.getElementById('days');
        let hoursField = document.getElementById('hours');
        let minutesField = document.getElementById('minutes');
        let secondsField = document.getElementById('seconds');

        let clicked = event.target;

        let seconds = 0;
        if (clicked.id === 'daysBtn') {
            let days = Number(daysField.value);
            seconds = 86400 * days;
        } else if (clicked.id === 'hoursBtn') {
            let hours = Number(hoursField.value);
            seconds = 3600 * hours;
        } else if (clicked.id === 'minutesBtn') {
            let minutes = Number(minutesField.value);
            seconds = 60 * minutes
        } else if (clicked.id === 'secondsBtn') {
            seconds = Number(secondsField.value);
        }

        daysField.value = seconds / 86400;
        hoursField.value = seconds / 3600;
        minutesField.value = seconds / 60;
        secondsField.value = seconds;
    });
}


