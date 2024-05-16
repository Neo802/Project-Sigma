// scripts.js
document.addEventListener('DOMContentLoaded', function () {
    var faqQuestions = document.querySelectorAll('.faq-question');

    faqQuestions.forEach(function (question) {
        question.addEventListener('click', function () {
            var answer = this.nextElementSibling;
            var isOpen = answer.classList.contains('open');

            // Close all answers
            document.querySelectorAll('.faq-answer').forEach(function (answer) {
                answer.classList.remove('open');
            });

            // Toggle the clicked answer
            if (!isOpen) {
                answer.classList.add('open');
            }
        });
    });
});
