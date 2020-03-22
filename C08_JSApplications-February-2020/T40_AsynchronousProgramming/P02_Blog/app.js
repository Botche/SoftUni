const baseUrl = `https://blog-apps-c12bf.firebaseio.com/posts`;
const postsData = document.getElementById("posts");

function attachEvents() {
    async function loadPosts() {
        await fetch(`${baseUrl}.json`)
            .then(parseData())
            .then(data => {
                for (const key in data) {
                    for (const secondKey in data[key]) {
                        let [_, id, title] = Object.values(data[key][secondKey]);
                        const option = document.createElement("option");
                        option.id = id;
                        option.innerHTML = title;
                        postsData.appendChild(option);
                    }
                }
            })
            .catch(printError())
    }

    // Cannot be completed because of wrong url...
    async function viewPost() {
        const postId = postsData.value;

        let postTilteElement = document.getElementById('post-title');
        let postBodyElement = document.getElementById('post-body');
        let postCommentsList = document.getElementById('post-comments');

        await fetch(`${baseUrl}.json`)
            .then(parseData())
            .then(data => {
                for (const key in data) {
                    if(key === postId){
                        let [postBody, postId, title] = Object.values(data[key]);
                        for (const secondKey in data[key]) {
                            let [body, id, title] = Object.values(data[key][secondKey]);
                            const option = document.createElement("option");
                            option.value = key;
                            option.id = key;
                            option.innerHTML = title;
                            postsData.appendChild(option);
                        }
                    }
                }
            })
            .catch(printError());
    }

    function parseData() {
        return resources => {
            if (!resources.ok) {
                throw new Error(JSON.stringify({
                    status: resources.status,
                    statusText: resources.statusText
                }));
            }
            return resources.json();
        };
    }

    function printError() {
        return (errorData) => {
            console.log(errorData.message);
        };
    }

    return {
        loadPosts,
        viewPost
    };
}

const result = attachEvents();

let loadBtn = document.getElementById('btnLoadPosts');
let viewBtn = document.getElementById('btnViewPost');

loadBtn.addEventListener('click', result.loadPosts);
viewBtn.addEventListener('click', result.viewPost);