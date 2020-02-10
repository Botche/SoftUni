function lockedProfile() {
    let showMoreBtns = document.getElementsByTagName('button');

    for (let i = 0; i < showMoreBtns.length; i++) {
        const btn = showMoreBtns[i];
        btn.addEventListener('click', showMore);
    }

    function showMore() {
        let checkElements = this.parentNode.getElementsByTagName('input');
        let hiddenElement = this.parentNode.getElementsByTagName('div')[0];

        if (!checkElements[1].checked) {
            return;
        }

        if (this.textContent === 'Show more') {
            this.textContent = 'Hide it';

            hiddenElement.style.display = 'block';

        } else {
            this.textContent = 'Show more';

            hiddenElement.style.display = 'none';
        }
    }
}