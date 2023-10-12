//document.addEventListener('DOMContentLoaded', function () {
//    // Отримайте необхідні DOM-елементи
//    const addPostButton = document.getElementById('add-post-button');
//    const postModal = document.getElementById('post-modal');
//    const closeButton = document.getElementById('close-button');

//    // Функція для відкриття модальної форми
//    function openModal() {
//        postModal.style.display = 'block';
//    }

//    // Функція для закриття модальної форми
//    function closeModal() {
//        postModal.style.display = 'none';
//    }

//    // Обробник події на кнопку "Додати пост"
//    addPostButton.addEventListener('click', openModal);

//    // Обробник події на хрестик для закриття форми
//    closeButton.addEventListener('click', closeModal);

//    // Обробник події на кнопку "Розмістити", який виконує логіку збереження поста
//    const submitButton = document.getElementById('submit-button');
//    const postTitle = document.getElementById('post-title');
//    const postDescription = document.getElementById('post-description');

//    submitButton.addEventListener('click', () => {
//        // Отримайте значення полів
//        const title = postTitle.value;
//        const description = postDescription.value;

//        // Надішліть дані на сервер за допомогою AJAX-запиту
//        fetch('/Forum/Create', {
//            method: 'POST',
//            headers: {
//                'Content-Type': 'application/json',
//            },
//            body: JSON.stringify({
//                Title: title,
//                Description: description,
//            }),
//        })
//            .then(response => {
//                if (response.ok) {
//                    // Успішно додано пост, можна додати логіку для оновлення інтерфейсу, якщо потрібно
//                    closeModal();
//                    postTitle.value = '';
//                    postDescription.value = '';
//                } else {
//                    // Обробити помилку, якщо щось пішло не так
//                    console.error('Add post failed.');
//                }
//            })
//            .catch(error => {
//                console.error('Add post failed:', error);
//            });
//    });
//});
