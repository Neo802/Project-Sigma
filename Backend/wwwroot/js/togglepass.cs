namespace ProjectRunAway.wwwroot.js
{
    public class togglepass
    {
        function togglePasswordVisibility()
        {
            var passwordInputs = document.querySelectorAll('input[type="password"]');
            passwordInputs.forEach(input => {
                input.type = input.type === 'password' ? 'text' : 'password';
            });
        }

        function checkPasswordsMatch()
        {
            var password = document.querySelector('input[name="Password"]').value;
            var confirmPassword = document.querySelector('input[name="ConfirmPassword"]').value;
            if (password !== confirmPassword)
            {
                alert("Passwords do not match!");
            }
        }

    }
}
