function solve() {
   let textarea = document.getElementsByTagName('textarea')[0];
   let checkoutBtn = document.getElementsByClassName('checkout')[0];
   let addBtn = document.getElementsByClassName('add-product');

   const products = {
      Bread: {name: 'Bread', price: 0.80, quantity: 0},
      Milk: {name: 'Milk', price: 1.09, quantity: 0},
      Tomatoes: {name: 'Tomatoes', price: 0.99, quantity: 0}
   }


   for (let btnIndex = 0; btnIndex < addBtn.length; btnIndex++) {
      const btn = addBtn[btnIndex];
      
      btn.addEventListener('click', () => {
         let productName = document.getElementsByClassName('product-title')[btnIndex].textContent;
         let productPrice = document.getElementsByClassName('product-line-price')[btnIndex].textContent;

         products[productName].quantity++;

         let orderInfo = `Added ${productName} for ${productPrice} to the cart.\n`;
         textarea.textContent += orderInfo;
      });
   }

   checkoutBtn.addEventListener('click', ()=>{
      let listOfBoughtProducts = [];
      let price = 0;
      
      for (const productName in products) {
         if (products[productName].quantity != 0) {
            listOfBoughtProducts.push(productName);

            price+= products[productName].price * products[productName].quantity;
         }
      }
      
      let fullOrderInfo = `You bought ${listOfBoughtProducts.join(', ')} for ${price.toFixed(2)}.`;
      textarea.textContent+=fullOrderInfo;

      for (let btnIndex = 0; btnIndex < addBtn.length; btnIndex++) {
         const btn = addBtn[btnIndex];
         btn.disabled = true;
         checkoutBtn.disabled = true;
      }
   });
}