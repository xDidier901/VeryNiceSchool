$(() => {
    // Variables.
    const loginButton = $('#loginButton');
    const inputUsername = $('#inputUsername');
    const inputPassword = $('#inputPassword');
    const snackbar = $('#snackbar');

    // Init.
    (function init() {
        setListeners();
    })();

    // Methods.
    function setListeners() {

        $('input').keypress(e => {
            const key = e.which || e.keyCode;
            if (key === 13) {
                loginButton.click();
            }
        });

        loginButton.click(login);
    }

    function login() {

        const username = inputUsername.val().trim();
        const password = inputPassword.val().trim();

        if (invalidFields(username, password)) {
            showAlert('Invalid fields.');
            return;
        }

        $.blockUI({ message: 'Just a moment...' });
        $.post('/Login/LoginUser', { username, password })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    window.location.href = response.url;
                } else {
                    showAlert(response.message);
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function invalidFields(username, password) {
        return (username == "" || username.length < 4) || (password == "" || password.length < 4);
    }

    function showAlert(message) {
        snackbar.addClass('show');
        snackbar.find('p').text(message);
        setTimeout(() => snackbar.removeClass('show'), 3000);
    }

});