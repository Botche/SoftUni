function attachEvents() {
    let url = 'https://rest-messanger.firebaseio.com/messanger.json';

    let submitBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');
    let messages = document.getElementById('messages');

    let author = document.getElementById('author');
    let content = document.getElementById('content');
    submitBtn.addEventListener('click', submit);
    refreshBtn.addEventListener('click', refresh);

    async function refresh() {
        messages.innerText = '';
        disableButtons();

        await fetch(url)
            .then(response => response.json())
            .then(json => {
                for (const key in json) {
                    let messageToAppend = `${json[key]['author']}: ${json[key]['content']}\n`;

                    messages.innerHTML += messageToAppend;
                }
            })

        enableButtons();
    }

    async function submit() {
        disableButtons();

        let data = {
            author: author.value,
            content: content.value,
        }

        await fetch(url, {
            method: 'POST',
            body: JSON.stringify(data),
        })

        author.value = '';
        content.value = '';

        enableButtons();
        refreshBtn.click();
    }

    function disableButtons() {
        submitBtn.disabled = true;
        refreshBtn.disabled = true;
    }

    function enableButtons() {
        submitBtn.disabled = false;
        refreshBtn.disabled = false;
    }
}

attachEvents();