$(document).ready(function () {

    

    //$('body').on('input', '.input-number', function () {
    //    this.value = this.value.replace(/[^0-9]/g, '');
    //});

    

    $('.popup-cover').click(function () {
        $('.nice-popup').addClass('hide');
    });

    $('.log-in').click(function () {
        $('.nice-popup').removeClass('hide');
    });

    $('.confirmation-reg-popup-cover').click(function () {
        $('.confirmation-reg-popup-cover').addClass('hide');
        $('.confirmation-reg').addClass('hide');
    });

    $('.switcher-login-btn').click(function () {
        $('.switcher-login-btn').removeClass('non-selected-reg-login');
        $('.switcher-login-btn').removeClass('non-selected-login');
        $('.switcher-reg-btn').addClass('non-selected-reg-login');
        $('.switcher-reg-btn').addClass('non-selected-reg');
        $('.for-reg').addClass('hide');
        $('.for-login').removeClass('hide');
        $('.login-block').addClass('login-block-login');
        $('.login-block').removeClass('login-block-reg');
        $('.registration-btn').addClass('hide');
    });

    $('.switcher-reg-btn').click(function () {
        $('.switcher-reg-btn').removeClass('non-selected-reg-login');
        $('.switcher-reg-btn').removeClass('non-selected-reg');
        $('.switcher-reg-btn').removeClass('non-selected-login');
        $('.switcher-login-btn').addClass('non-selected-reg-login');
        $('.switcher-login-btn').addClass('non-selected-login');
        $('.for-reg').removeClass('hide');
        $('.for-login').addClass('hide');
        $('.login-block').addClass('login-block-reg');
        $('.login-block').removeClass('login-block-login');
        $('.registration-btn').removeClass('hide');
    });
});