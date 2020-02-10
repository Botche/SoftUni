function encodeAndDecodeMessages() {
    let textAreaElements = document.getElementsByTagName('textarea');
    let btnElements = document.getElementsByTagName('button');

    let encodeBtn = btnElements[0];

    let decodeBtn = btnElements[1];

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    function encode(){
        let textToEncode = textAreaElements[0].value;
        let encodedText = '';
        
        for (let i = 0; i < textToEncode.length; i++) {
            const element = textToEncode[i];
            encodedText += String.fromCharCode(element.charCodeAt(0) + 1);
        }

        textAreaElements[1].value = encodedText;
        textAreaElements[0].value = '';
    }

    function decode(){
        let textToDecode = textAreaElements[1].value;
        let decodedText = '';
        
        for (let i = 0; i < textToDecode.length; i++) {
            const element = textToDecode[i];
            decodedText += String.fromCharCode(element.charCodeAt(0) - 1);
        }

        textAreaElements[1].value = decodedText;
    }
}