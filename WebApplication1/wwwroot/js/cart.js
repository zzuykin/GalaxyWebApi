function showCartModal() {
    const cartModal = document.getElementById("cartModal");
    cartModal.style.display = "block";
    loadCartItems(); // Загрузить содержимое корзины
}

function hideCartModal() {
    const cartModal = document.getElementById("cartModal");
    cartModal.style.display = "none";
}

function loadCartItems() {
    fetch('/Cart/GetCartItems', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Ошибка HTTP: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            const cartItemsContainer = document.getElementById("cartItems");

            if (!data.items || !Array.isArray(data.items)) {
                throw new Error('Items не является массивом');
            }

            if (data.IsEmpty || data.items.length === 0) {
                cartItemsContainer.innerHTML = `<div class="cartItemsEmpty">Ваша корзина пуста.</div>`;
                return;
            }

            // Очищаем контейнер перед добавлением элементов
            cartItemsContainer.innerHTML = '';

            // Используем цикл for для обработки данных
            for (let i = 0; i < data.items.length; i++) {
                const item = data.items[i];

                const itemHtml = `
                    <div class="cart-item">
                        <span class="product-name">${item.productName}</span>
                        <span class="product-quantity"> ${item.quantity} шт.</span>
                        <span class="product-total-price">Итого: ${item.totalPrice} ₽</span>
                        <button class="remove-item" onclick="removeCartItem(${item.productId})">-</button>
                    </div>
                `;

                // Добавляем элемент в контейнер
                cartItemsContainer.innerHTML += itemHtml;
            }
        })
        .catch(error => {
            console.error('Ошибка загрузки корзины:', error);
        });
}


function removeCartItem(productId) {
    fetch('/Cart/RemoveCartItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId) // Передаем только ID товара
    })
        .then(response => {
            if (!response.ok) throw new Error('Ошибка при удалении товара');
            updateCartItemCount();
            loadCartItems(); // Перезагружаем содержимое корзины
        })
        .catch(error => {
            console.error('Ошибка:', error);
        });
}
function addToCart(productId) {
    fetch('/Cart/AddToCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value 
        },
        body: JSON.stringify(productId) 
    })
        .then(response => {
            if (!response.ok) throw new Error('Ошибка при добавлении товара в корзину');
            return response.json();
        })
        .then(data => {
            alert('Товар успешно добавлен в корзину');
            // Опционально обновить иконку корзины
            document.querySelector('.cart__count span').innerText = data.cartItemCount;
        })
        .catch(error => {
            console.error('Ошибка:', error);
            alert('Не удалось добавить товар в корзину');
        });
}

