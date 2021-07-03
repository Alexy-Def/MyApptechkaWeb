$(document).ready(function () {
    $('.login-for-reg').keyup(function () {
        var name = $(this).val();

        if (name != '') {
            var url = '/User/IsUserExist?name=' + name;
        }


        //showIcon('spinner');
        $.get(url).done(function (answer) {
            if (name == '') {
                answer = false;
            }

            //����� ����� �����
            console.log("answer = " + answer);
            if (answer) {
                //showIcon('close');
                $('#for-json-result').text("User existed!");
            } else {
                //showIcon('ok');
                $('#for-json-result').text(" ");
            }
        });

        //function showIcon(iconName) {
        //	$('#registration-block .icon').addClass('hide');
        //	$(`#registration-block .icon.${iconName}`).removeClass('hide');
        //}
    });

    $('.switcher-reg-btn').click(function () {
        var inputsWithInfo = [
            '.login-for-reg',
            '.password-for-reg',
            '.confirm-password-for-reg',
            '.phone-for-reg'];

        $('.for-reg').keyup(function () {
            if ((IsFilledInputWithRegInfo() == true)/* && ($('#for-json-result').html() == '')*/) {
                $('.registration-btn').attr("disabled", false);
                $('.registration-btn').addClass('registration-btn-open');
            }
            else {
                $('.registration-btn').attr("disabled", true);
                $('.registration-btn').removeClass('registration-btn-open');
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

    $('.registration-btn').click(function () {
        var login = $('.login-for-reg').val();
        var phone = $('.phone-for-reg').val();
        var generatedCode = '';

        var url = '/User/SendingSmsCode?login=' + login + '&phone=' + phone;
        $.get(url).done(function (generatedCodeAnswer) {
            console.log(generatedCodeAnswer);
            generatedCode = generatedCodeAnswer;
        });

        var arr = ['.test1', '.test2', '.test3', '.test4'];
        $('.confirmation-reg-popup-cover').removeClass('hide');
        $('.confirmation-reg').removeClass('hide');
        $('.test1').focus();
        for (var i = 0; i < 4; i++) {
            $(`${arr[i]}`).keyup(function () {
                this.value = this.value.replace(/[^0-9]/g, '');
                $(this).next().focus();
                if (IsFilledInputWithCodeFromSms(generatedCode) == true) {
                    $('.confirmation-code-btn').attr("disabled", false);
                    //$('.confirmation-code-btn').addClass('registration-btn-open');
                    $('.confirmation-code-btn').removeClass('hide');
                }
                else {
                    $('.confirmation-code-btn').attr("disabled", true);
                    //$('.confirmation-code-btn').removeClass('registration-btn-open');
                    $('.confirmation-code-btn').addClass('hide');
                }
            })
        }

        function IsFilledInputWithCodeFromSms(generatedCode) {
            var counter = 0;
            var code = '';
            for (var k = 0; k < 4; k++) {
                if ($(`${arr[k]}`).val().length == 1) {
                    counter++;
                    code = code + $(`${arr[k]}`).val();
                }
            }

            return (counter == 4 && generatedCode == code) ?? false;
        }
    })

    $('.confirmation-code-btn').click(function () {
        $('.reg-btn').trigger('click');
    })

    //$('.popup-cover').click(function () {
    //	$('.nice-popup').addClass('hide');
    //});

    //$('.log-in').click(function () {
    //	$('.nice-popup').removeClass('hide');
    //});

    //$('.switcher-login-btn').click(function () {
    //	$('.switcher-login-btn').removeClass('non-selected-reg-login');
    //	$('.switcher-login-btn').removeClass('non-selected-login');
    //	$('.switcher-reg-btn').addClass('non-selected-reg-login');
    //	$('.switcher-reg-btn').addClass('non-selected-reg');
    //	$('.for-reg').addClass('hide');
    //	$('.for-login').removeClass('hide');
    //	//$('.phoneNumber').addClass('hide');
    //	//$('.login').removeClass('hide');
    //	/*$('.reg').addClass('hide');*/
    //	$('.login-block').addClass('login-block-login');
    //	$('.login-block').removeClass('login-block-reg');
    //});

    //$('.switcher-reg-btn').click(function () {
    //	$('.switcher-reg-btn').removeClass('non-selected-reg-login');
    //	$('.switcher-reg-btn').removeClass('non-selected-reg');
    //	$('.switcher-login-btn').addClass('non-selected-reg-login');
    //	$('.switcher-login-btn').addClass('non-selected-login');
    //	$('.for-reg').removeClass('hide');
    //	$('.for-login').addClass('hide');
    //	//$('.phoneNumber').removeClass('hide');
    //	//$('.login').addClass('hide');
    //	//$('.reg').removeClass('hide');
    //	$('.login-block').addClass('login-block-reg');
    //	$('.login-block').removeClass('login-block-login');
    //});
});