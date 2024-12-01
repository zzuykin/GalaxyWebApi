document.addEventListener("DOMContentLoaded", function () {
    // Проверяем наличие куки auth_cookie
    if (document.cookie.includes('auth_cookie=')) {
        updateCartItemCount(); // Выполняем запрос только если куки есть
    } else {
        // Если куки нет, отображаем 0
        document.querySelector('.cart__count span').innerText = '5';
    }
});

// Функция для обновления количества товаров в корзине
function updateCartItemCount() {
    fetch('/Cart/GetCartItemCount', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) throw new Error('Ошибка при получении данных корзины');
            return response.json();
        })
        .then(data => {
            // Обновляем отображение количества товаров
            document.querySelector('.cart__count span').innerText = data.cartItemCount;
        })
        .catch(error => {
            console.error('Ошибка:', error);
        });
}