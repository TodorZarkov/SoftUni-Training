function validate() {
    let companyCheckEl = document.getElementById('company');
    let submitBtn = document.getElementById('submit');
    let companyInfoEl = document.getElementById('companyInfo');
    let globalEvent = document.getElementById('wrapper');
    let inputs = Array.from(document.querySelectorAll('input'));
    let companyNumberEl= document.getElementById('companyNumber');
    let pass = document.getElementById('password');
    let confirmPass = document.getElementById('confirm-password');

    let userNameRegex = /^[A-Za-z0-9]{3,20}$/;
    let emailRegex = /^.*\@.*\..*$/;  //   /^[^@]*\@[^@]*\.[^@]*$/;
    let passwordRegex = /^[A-Za-z0-9_]{5,15}$/;
    let companyRegex = /^[1-9][0-9]{3}$/;
    let confirmPassRegex = /^[A-Za-z0-9_]{5,15}$/;

    let invalidElements = [];

    setInvalidElementsOnLoad();



    companyCheckEl.addEventListener('change', (event) => {
        if (event.target.checked) {
            companyInfoEl.style.display = 'block';
            manipulateInvalidElements(companyNumberEl, companyRegex);
        }
        else {
            companyInfoEl.style.display = 'none';
            companyNumberEl.value = '';
            companyNumberEl.style.borderColor = '';
            if(invalidElements.includes(companyNumberEl)){
                invalidElements.splice(invalidElements.indexOf(companyNumberEl),1);

            }
        }

    });


    globalEvent.addEventListener('focusout', fetchInvalidEvent);


    function fetchInvalidEvent(event) {
        fetchInvalidTarget(event.target)
    }



    function fetchInvalidTarget(target) {
        if (target.id === 'username') {
            manipulateInvalidElements(target, userNameRegex);
        }
        else if (target.id === 'email') {
            manipulateInvalidElements(target, emailRegex);
        }
        else if (target.id === 'password') {
            manipulateInvalidElements(target, passwordRegex);
            
            //+SOMETHING ELSE
        }
        else if (target.id === 'confirm-password') {
            manipulateInvalidElements(target, confirmPassRegex);
            //SOMETHING ELSE
        }
        else if (target.id === 'companyNumber') {
            manipulateInvalidElements(target, companyRegex);
        }
    }


    submitBtn.addEventListener('click', submit);
    function submit(event) {
        event.preventDefault();
        let validEl = document.getElementById('valid');
        for (let input of inputs) {

            if (invalidElements.includes(input)) {
                input.style.setProperty('border-color','red');
            }
            else {
                input.style.borderColor = '';
            }
        }
        if (pass.value !== confirmPass.value) {
            pass.style.setProperty('border-color','red');
            confirmPass.style.setProperty('border-color','red');
        }
        if (invalidElements.length === 0 && pass.value === confirmPass.value) {
            validEl.style.display = 'block';
        } else {
            validEl.style.display = 'none';
        }

    }


    function manipulateInvalidElements(target, regex) {
        if (target.id === 'company') return;
        if (target.value.match(regex) === null) {
            if (!invalidElements.includes(target)) {
                invalidElements.push(target);
            }
        } else {
            let index = invalidElements.indexOf(target);
            if (index !== -1) {
                invalidElements.splice(index, 1);
            }
        }
    }

    function setInvalidElementsOnLoad() {
        for (let input of inputs) {
            if (input.id === 'companyNumber') continue;
            fetchInvalidTarget(input);
        }
    }
}
