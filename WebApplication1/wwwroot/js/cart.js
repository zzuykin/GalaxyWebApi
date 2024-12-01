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
    // Пример загрузки содержимого корзины (можно заменить на реальный AJAX-запрос)
    const cartItemsContainer = document.getElementById("cartItems");
    cartItemsContainer.innerHTML = `
        <ul>
            <li>Товар 1 - 2 шт.</li>
            <li>Товар 2 - 1 шт.</li>
        </ul>
    `;
}

function addToCart(productId) {
    fetch('/Cart/AddToCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value // Если используете валидацию
        },
        body: JSON.stringify(productId) // Передаём число напрямую
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