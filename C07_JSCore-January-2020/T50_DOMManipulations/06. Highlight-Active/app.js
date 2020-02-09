function focus() {
    let elements = document.querySelectorAll('div > div > input');

    for (let i = 0; i < elements.length; i++) {
        elements[i].addEventListener('focus', focus);
        elements[i].addEventListener('blur', outfocus);
    }

    function focus(e){
        let currentElement = e.currentTarget.parentNode;
        
        currentElement.setAttribute('class', 'focused');
    }

    function outfocus(e){
        let currentElement = e.currentTarget.parentNode;
        
        currentElement.removeAttribute('class');
    }
}