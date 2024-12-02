let currentIndex = 0;

function showSlide(index) {
    const slides = document.querySelector('.slides');
    const totalSlides = slides.children.length;
    const indicators = document.querySelectorAll('.indicators button');

    // Обновление индекса
    if (index < 0) {
        currentIndex = totalSlides - 1;
    } else if (index >= totalSlides) {
        currentIndex = 0;
    } else {
        currentIndex = index;
    }

    // Смещение слайдов
    slides.style.transform = `translateX(-${currentIndex * 100}%)`;

    // Обновление активного индикатора
    indicators.forEach((button, i) => {
        button.classList.toggle('active', i === currentIndex);
    });
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

// Initialize indicators
document.addEventListener("DOMContentLoaded", () => {
    showSlide(currentIndex);
});