document.addEventListener('DOMContentLoaded', (event) => {
    const cards = document.querySelectorAll('.clickable-card');
    cards.forEach(card => {
        card.addEventListener('click', () => {
            const url = card.getAttribute('data-url');
            window.location.href = url;
        });
    });
});