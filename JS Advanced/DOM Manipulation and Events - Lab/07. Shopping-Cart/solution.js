function solve() {

   let textArea = document.querySelector('textarea');

   let cart = [];

   document.querySelector('.shopping-cart').addEventListener('click', (ev) => {

      if (ev.target.tagName === 'BUTTON' && ev.target.className === 'add-product') {

         const product = ev.target.parentNode.parentNode;
         const name = product.querySelector('.product-title').textContent;
         const price = Number(product.querySelector('.product-line-price').textContent);

         cart.push({ name, price });

         textArea.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;

      }
   });

   document.querySelector('.checkout').addEventListener('click', () => {

      const result = cart.reduce((acc, p) => {

         if (!acc.items.includes(p.name)) {

            acc.items.push(p.name);
         };

         acc.totalPrice += p.price;

         return acc;

      }, { items: [], totalPrice: 0 });

      textArea.value += `You bought ${result.items.join(', ')} for ${result.totalPrice.toFixed(2)}.`;

      disableAllBtn();
   });

   function disableAllBtn() {
      Array.from(document.getElementsByTagName('button')).forEach(b => b.disabled = true);
   }
}