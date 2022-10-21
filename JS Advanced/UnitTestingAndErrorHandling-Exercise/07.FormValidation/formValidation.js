function validate() {
    let companyCheckEl = document.getElementById('company');
    let submitBtn = document.getElementById('submit');
    let companyInfoEl = document.getElementById('companyInfo');
    let inputs = Array.from(document.querySelectorAll('input'));
    let pass = document.getElementById('password');
    let confirmPass = document.getElementById('confirm-password');
    let validEl = document.getElementById('valid');


    let userNameRegex = /^[A-Za-z0-9]{3,20}$/;
    let emailRegex = /^.*\@.*\..*$/;  //   /^[^@]*\@[^@]*\.[^@]*$/;
    let passwordRegex = /^[A-Za-z0-9_]{5,15}$/;
    let companyRegex = /^[1-9][0-9]{3}$/;
    let confirmPassRegex = /^[A-Za-z0-9_]{5,15}$/;

    companyCheckEl.addEventListener('change',(event)=>{
        if(companyCheckEl.checked){
            companyInfoEl.style.display = 'block';
        }
        else{
            companyInfoEl.style.display = 'none';
        }
    })

    submitBtn.addEventListener('click',(event)=>{
        event.preventDefault();
        let passed = false;
        for(let input of inputs){
            if(input.id === 'conmpany') continue;
            if(input.id === 'companyNumber'){
                if(!companyCheckEl.checked || companyInfoEl.style.display === 'none') continue;
                if(input.value.match(companyRegex) !== null){
                    input.style.borderColor = ''
                    passed = true;
                }
                else{
                    input.style.borderColor = 'red'
                    passed = false;
                }
            }

            if(input.id === 'password'){
                if(input.value.match(passwordRegex) !== null && pass.value === confirmPass.value){
                    input.style.borderColor = ''
                    passed = true;
                }
                else{
                    input.style.borderColor = 'red'
                    passed = false;
                }
            }

            if(input.id === 'confirm-password'){
                if(input.value.match(confirmPassRegex) !== null && pass.value === confirmPass.value){
                    input.style.borderColor = ''
                    passed = true;
                }
                else{
                    input.style.borderColor = 'red'
                    passed = false;
                }
            }

            if(input.id === 'username'){
                if(input.value.match(userNameRegex) !== null){
                    input.style.borderColor = ''
                    passed = true;
                }
                else{
                    input.style.borderColor = 'red'
                    passed = false;
                }
            }

            if(input.id === 'email'){
                if(input.value.match(emailRegex) !== null){
                    input.style.borderColor = ''
                    passed = true;
                }
                else{
                    input.style.borderColor = 'red'
                    passed = false;
                }
            }

            if(passed===true){
                validEl.style.display = 'block';
            }
            else{
                validEl.style.display = 'none';
            }
        }
    })
}
