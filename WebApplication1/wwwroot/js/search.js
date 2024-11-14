function searchText() {
    removeHighlights(); // Удаляем предыдущие выделения

    const searchQuery = document.getElementById("searchInput").value.trim();
    if (!searchQuery) return;

    const elementsToSearch = document.querySelectorAll("p, h1, h2, h3, h4, h5, h6, a, li, div");
    elementsToSearch.forEach((element) => {
        highlightText(element, searchQuery);
    });

    document.getElementById("clearButton").style.display = "inline"; // Показываем кнопку очистки
}

function highlightText(element, text) {
    const innerHTML = element.innerHTML;
    const regex = new RegExp(`(${text})`, "gi");
    const highlightedText = innerHTML.replace(regex, '<span class="highlight">$1</span>');
    element.innerHTML = highlightedText;
}

function removeHighlights() {
    const highlights = document.querySelectorAll(".highlight");
    highlights.forEach((highlight) => {
        const parent = highlight.parentNode;
        parent.replaceChild(document.createTextNode(highlight.textContent), highlight);
        parent.normalize(); // Упрощает структуру после замены
    });
}

function clearSearch() {
    removeHighlights(); // Удаляем выделения
    document.getElementById("searchInput").value = ""; // Очищаем поле поиска
    document.getElementById("clearButton").style.display = "none"; // Скрываем кнопку очистки
}