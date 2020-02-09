function validate() {
    let input = document.getElementById('email');
    let pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

    input.addEventListener('change', () => {
        let email = input.value;

        if (pattern.test(email)) {
            input.classList.remove('error');
        } else {
            input.classList.add('error');
        }
    });
}