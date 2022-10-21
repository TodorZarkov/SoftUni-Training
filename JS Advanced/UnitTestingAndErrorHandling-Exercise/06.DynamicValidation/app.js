function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', validate);
    let validInputRegex = /^[a-z]+\@[a-z]+\.[a-z]+$/;

    function validate(event) {
        let tryEmail = input.value;
        if (tryEmail.match(validInputRegex) !== null) {
            try{
            input.classList.remove('error');
            }catch(err){
                console.log(err.message)
            }
        } 
        else {
            //apply class error in case of error!
            input.classList.add('error');
        }

    }
}