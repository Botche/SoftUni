async function loadCommits() {
    let loadBtn = document.getElementsByTagName('button')[0];
    loadBtn.disabled = true;

    const BASE_URL = 'https://api.github.com/repos/<username>/<repository>/commits';

    let commitsList = document.getElementById('commits');
    let usernameInput = document.getElementById('username');
    let repoInput = document.getElementById('repo');

    commitsList.innerHTML = '';

    const url = BASE_URL
        .replace('<username>', usernameInput.value)
        .replace('<repository>', repoInput.value);

    await fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error(JSON.stringify({
                    status: response.status,
                    statusText: response.statusText
                }));
            }

            return response.json();
        })
        .then(json => {
            Array.from(json).forEach(element => {
                const username = element['commit']['author']['name'];
                const message = element['commit']['message'];

                let commitListItem = document.createElement('li');
                const commitMessageWithAuthor = `${username}: ${message}`;

                commitListItem.innerText = commitMessageWithAuthor;

                commitsList.appendChild(commitListItem);
            });
        }).catch(errorStringified => {
            let error = JSON.parse(errorStringified.message);
            let errorListItem = document.createElement('li');
            const errorMessage = `Error: ${error.status} (${error.statusText})`;

            errorListItem.innerText = errorMessage;

            commitsList.appendChild(errorListItem);
        })

    usernameInput.value = '';
    repoInput.value = '';

    loadBtn.disabled = false;
}