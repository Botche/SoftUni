function attachEvents() {
    const personNameValidation = /^[A-Za-z]+( [A-Za-z]+)?$/;
    const phoneNumberValidation = /^\+?([\d]{3})[-. ]{1}([\d]{3})[-. ]{1}([\d]{4})$/;

    let loadBtn = document.getElementById('btnLoad');
    let createBtn = document.getElementById('btnCreate');

    let phonebook = document.getElementById('phonebook');


    loadBtn.addEventListener('click', load);

    createBtn.addEventListener('click', create);

    async function load() {
        disableButtons();
        phonebook.innerHTML = '';

        await fetch('https://phonebook-nakov.firebaseio.com/phonebook.json')
            .then(response => response.json())
            .then(json => {
                for (const key in json) {
                    let phoneListItem = document.createElement('li');
                    let deleteBtn = document.createElement('button');

                    let personInfo = `${json[key]['person']}: ${json[key]['phone']} `;

                    phoneListItem.innerText = personInfo;

                    deleteBtn.innerText = 'Delete';

                    deleteBtn.addEventListener('click', async function(){
                        await fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`, {
                            method: 'DELETE'
                        }).then(response => response.json());
                
                        loadBtn.click();
                    })
                    
                    phoneListItem.appendChild(deleteBtn);

                    phonebook.appendChild(phoneListItem);
                }
            });

        enableButtons();
    }

    

    async function create() {
        let person = document.getElementById('person');
        let phone = document.getElementById('phone');

        if (!person.value || !phone.value) {
            alert('Fill the inputs!!!');
            return;
        }

        if (!phoneNumberValidation.test(phone.value) || !personNameValidation.test(person.value)) {
            alert('Phone number is not right!!!');
            return;
        }

        disableButtons();

        let data = {
            person: person.value,
            phone: phone.value,
        };

        await fetch('https://phonebook-nakov.firebaseio.com/phonebook.json', {
            method: 'POST',
            body: JSON.stringify(data)
        });

        person.value = '';
        phone.value = '';
        enableButtons();

        loadBtn.click();
    }

    function disableButtons() {
        loadBtn.disabled = true;
        createBtn.disabled = true;
    }

    function enableButtons() {
        loadBtn.disabled = false;
        createBtn.disabled = false;
    }
}

attachEvents();