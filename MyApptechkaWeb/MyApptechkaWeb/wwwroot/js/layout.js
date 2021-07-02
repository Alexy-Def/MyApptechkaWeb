$(document).ready(function () {

    $('.switcher-reg-btn').click(function () {
        var inputsWithInfo = ['.login-for-reg', '.password-for-reg', '.confirm-password-for-reg', '.phone-for-reg'];

        $('.for-reg').keyup(function () {
            if (IsFilledInputWithRegInfo() == true) {
                $('.test888').attr("disabled", false);
            }
            else {
                $('.test888').attr("disabled", true);
            }
        })

        function IsFilledInputWithRegInfo() {
            var counter = 0;
            for (var k = 0; k < 4; k++) {
                if ($(`${inputsWithInfo[k]}`).val().length != 0) {
                    counter++;
                }
            }

            return counter == 4 ?? false;
        }
    })

    $('.test888').click(function () {
        var arr = ['.test1', '.test2', '.test3', '.test4'];
        $('.confirmation-reg-popup-cover').removeClass('hide');
        $('.confirmation-reg').removeClass('hide');
        $('.test1').focus();
        for (var i = 0; i < 4; i++) {
            $(`${arr[i]}`).keyup(function () {
                $(this).next().focus();
                if (IsFilledInputWithCodeFromSms() == true) {
                    $('.confirmation-code-btn').attr("disabled", false);
                }
                else {
                    $('.confirmation-code-btn').attr("disabled", true);
                }
            })
        }

        function IsFilledInputWithCodeFromSms() {
            var counter = 0;
            for (var k = 0; k < 4; k++) {
                if ($(`${arr[k]}`).val().length == 1) {
                    counter++;
                }
            }

            return counter == 4 ?? false;
        }
    })

    $('.confirmation-code-btn').click(function () {
        $('.reg-btn').trigger('click');
    })

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
    });
});