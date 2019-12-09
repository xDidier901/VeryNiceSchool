    // Methods.
    function showAlert(message) {
        $('#snackbar').addClass('show');
        $('#snackbar').find('p').text(message);
        setTimeout(() => $('#snackbar').removeClass('show'), 3000);
    }
