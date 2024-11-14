document.addEventListener("DOMContentLoaded", function () {
    const loginModal = document.getElementById("loginModal");
    const registerModal = document.getElementById("registerModal");
    const loginBtn = document.getElementById("loginButton");
    const registerBtn = document.getElementById("registerButton");
    const closeButtons = document.querySelectorAll(".close");

    // Показать модальное окно входа
    loginBtn.addEventListener("click", function () {
        loginModal.style.display = "block";
    });

    // Показать модальное окно регистрации
    registerBtn.addEventListener("click", function () {
        registerModal.style.display = "block";
    });

    // Закрытие модальных окон при нажатии на "X"
    closeButtons.forEach(btn => {
        btn.addEventListener("click", function () {
            loginModal.style.display = "none";
            registerModal.style.display = "none";
        });
    });

    // Закрытие модальных окон при клике вне области модального окна
    window.addEventListener("click", function (event) {
        if (event.target === loginModal) {
            loginModal.style.display = "none";
        } else if (event.target === registerModal) {
            registerModal.style.display = "none";
        }
    });
});

