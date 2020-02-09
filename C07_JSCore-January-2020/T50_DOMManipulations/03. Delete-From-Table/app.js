function deleteByEmail() {
    let input = document.getElementsByTagName('input')[0];
    let resultElement = document.getElementById('result');

    let inputValue = input.value;

    let allEmails = document.querySelectorAll('td:nth-child(even)')
    let isFound = false;

    for (const email of allEmails) {
        if (email.innerHTML.includes(inputValue)) {
            email.parentNode.parentNode.removeChild(email.parentNode);
            isFound = true;
        }
    }


    if (isFound) {
        resultElement.textContent = 'Deleted';
    } else {
        resultElement.textContent = 'Not found.';
    }

    input.value = '';
}