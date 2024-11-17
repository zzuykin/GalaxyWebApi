document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");
    const searchResults = document.getElementById("searchResults");
    const resultsList = document.getElementById("resultsList");
    const clearButton = document.getElementById("clearButton");

    // Показать окно результатов поиска
    searchInput.addEventListener("input", function () {
        const query = searchInput.value.trim();

        if (query.length > 0) {
            fetch(`/Search/GetResults?query=${encodeURIComponent(query)}`)
                .then(response => response.json())
                .then(data => {
                    resultsList.innerHTML = ""; // Очистить предыдущие результаты
                    if (data.length > 0) {
                        data.forEach(item => {
                            const li = document.createElement("li");
                            const link = document.createElement("a");
                            link.href = item.route; // Используем маршрут из модели
                            link.textContent = item.pageName; // Имя страницы
                            li.appendChild(link);
                            resultsList.appendChild(li);
                        });
                    } else {
                        resultsList.innerHTML = "<li>Результатов не найдено</li>";
                    }
                    searchResults.style.display = "block"; // Показать окно
                });
        } else {
            searchResults.style.display = "none"; // Скрыть окно, если нет текста
        }
    });

    // Закрыть окно результатов при клике вне области
    document.addEventListener("click", function (e) {
        if (!searchResults.contains(e.target) && e.target !== searchInput) {
            searchResults.style.display = "none";
        }
    });

    // Кнопка очистки поиска
    clearButton.addEventListener("click", function () {
        searchInput.value = "";
        resultsList.innerHTML = "";
        searchResults.style.display = "none";
    });
});

// Функция скрытия результатов
function hideSearchResults() {
    const searchResults = document.getElementById("searchResults");
    searchResults.style.display = "none";
}
