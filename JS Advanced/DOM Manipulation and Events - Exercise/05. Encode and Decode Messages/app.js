function encodeAndDecodeMessages() {
    let encodeBtn;
    let decodeBtn;
    let btns = document.querySelectorAll('button');
    if (btns[0].textContent === 'Encode and send it') {
        encodeBtn = btns[0];
        decodeBtn = btns[1];
    }else if (btns[1].textContent === 'Encode and send it') {
        encodeBtn = btns[1];
        decodeBtn = btns[0];
    }
    encodeBtn.addEventListener('click',encode);
    decodeBtn.addEventListener('click', decode);
    let toEncode = encodeBtn.parentElement.querySelector('textarea');
    let toDecode = decodeBtn.parentElement.querySelector('textarea');

    function encode(){
        let text = toEncode.value;
        let encoded ='';
        for(let i = 0;i<text.length;i++){
            encoded += String.fromCharCode(text.charCodeAt(i) + 1);
        }
        toDecode.value = encoded;
        toEncode.value = '';
    }

    function decode(){
        let textToDecode=toDecode.value;
        let decoded = '';
        for(let i = 0;i<textToDecode.length;i++){
            decoded += String.fromCharCode(textToDecode.charCodeAt(i) - 1);
        }
        toDecode.value = decoded;
    }
}