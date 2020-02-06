function solve() {
  let tbody = document.getElementsByTagName('tbody')[0];

  let buttons = document.getElementsByTagName('button');
  let textareas = document.getElementsByTagName('textarea');

  let generateBtn = buttons[0];
  let generateBtnInput = textareas[0];

  let buyBtn = buttons[1];
  let buyBtnInput = textareas[1];

  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);

  function generate() {
    let arrayOfFurnitures = generateBtnInput.value;
    let parsedInput = JSON.parse(arrayOfFurnitures);

    parsedInput.forEach(furniture => {
      let tableRow = document.createElement('tr');

      let td1 = document.createElement("td");
      let img = document.createElement("img");
      img.src = furniture.img;
      td1.appendChild(img);

      let td2 = document.createElement("td");
      td2.textContent = furniture.name;

      let td3 = document.createElement("td");
      td3.textContent = furniture.price;

      let td4 = document.createElement("td");
      td4.textContent = furniture.decFactor;

      let td5 = document.createElement("td");
      let input = document.createElement("input");
      input.type = "checkbox";
      td5.appendChild(input);

      tableRow.appendChild(td1);
      tableRow.appendChild(td2);
      tableRow.appendChild(td3);
      tableRow.appendChild(td4);
      tableRow.appendChild(td5);

      tbody.appendChild(tableRow);
    });
  };

  function buy() {
    let checkboxes = document.getElementsByTagName('input');

    let bought = [];
    for (let i = 1; i < checkboxes.length; i++) {
      if (checkboxes[i].checked === true) {
        bought.push(tbody.children[i]);
      }
    }

    let names = [];
    let totalPrice = 0;
    let decFactors = 0;

    for (const item of bought) {
      names.push(item.children[1].textContent);
      totalPrice += Number(item.children[2].textContent);
      decFactors += Number(item.children[3].textContent);
    }

    buyBtnInput.value += `Bought furniture: ${names.join(", ")}\n`;
    buyBtnInput.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    buyBtnInput.value += `Average decoration factor: ${decFactors / bought.length}\n`;
  }
}