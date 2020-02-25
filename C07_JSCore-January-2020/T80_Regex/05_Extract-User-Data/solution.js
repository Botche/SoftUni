function solve() {
  let array = document.getElementById('arr').value.split(', ');
  array = JSON.parse(array);
 
  let resultSpan = document.getElementById('result');
  for(let item of array){
    item = item.split(' ');
    let isValid = false;
    let firstName = item[0].trim();    
    let secondName = item[1].trim();
    let phone = item[2].trim();
    let email = item[3].trim();    
 
    let firstNameRegex = /[A-Z][a-zA-Z]*/gm;
    let secondNameRegex = /[A-Z][a-z]+/gm;
    let emailRegex = /[a-z0-9]+[@][a-z]+[.][a-z]{2,3}/gm;
    let phoneRegex = /\+359( |-)[0-9]\1[0-9]{3}\1[0-9]{3}/gm;
    if (firstNameRegex.test(firstName)) {
      if(secondNameRegex.test(secondName)){          
        if(emailRegex.test(email)){                    
          if(phoneRegex.test(phone)){
              isValid = true;
          }              
        }
      }      
    }
    if(isValid){
        let nameP = document.createElement('p');
        nameP.textContent = `Name: ${firstName} ${secondName}`;
        resultSpan.appendChild(nameP);        
        let phoneP = document.createElement('p');
        phoneP.textContent = `Phone Number: ${phone}`;
        resultSpan.appendChild(phoneP);
        let emailP = document.createElement('p');
        emailP.textContent = `Email: ${email}`;
        resultSpan.appendChild(emailP);        
    }else{
      let invalidDataP = document.createElement('p');
      invalidDataP.textContent = `Invalid data`;
        resultSpan.appendChild(invalidDataP);        
    }
    let endP = document.createElement('p');
        endP.textContent = `- - -`;
        resultSpan.appendChild(endP);
  }
}