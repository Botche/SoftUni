function solve() {
    let dropdownBtn = document.getElementById('dropdown');
    let dropdown = document.getElementById('dropdown-ul');
    let box = document.getElementById('box');

    dropdownBtn.addEventListener('click', () => {

        if(dropdown.style.display === 'block'){
            dropdown.style.display = 'none';

            box.style.backgroundColor = 'black';
            box.style.color = 'white';
        } else{
            dropdown.style.display = 'block';
        }
    })

    let listItems = dropdown.getElementsByTagName('li');
    
    Array.from(listItems).forEach(el => el.addEventListener('click', (e) => {
        box.style.backgroundColor = e.target.textContent;
        box.style.color = 'black';
    }))
}