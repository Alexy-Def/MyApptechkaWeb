$(document).ready(function () {
	$('.popup-cover').click(function () {
		$('.nice-popup').addClass('hide');
	});

	$('.log-in').click(function () {
		$('.nice-popup').removeClass('hide');
	});

	$('.switcher-login-btn').click(function () {
		$('.switcher-login-btn').removeClass('selected-reg-login');
		$('.switcher-login-btn').removeClass('selected-login');
		$('.switcher-reg-btn').addClass('selected-reg-login');
		$('.switcher-reg-btn').addClass('selected-reg');
		$('.confirmPassword').addClass('hide');
		$('.phoneNumber').addClass('hide');
		$('.login').removeClass('hide');
		$('.reg').addClass('hide');
		$('.login-block').addClass('login-block-login');
		$('.login-block').removeClass('login-block-reg');
	});

	$('.switcher-reg-btn').click(function () {
		$('.switcher-reg-btn').removeClass('selected-reg-login');
		$('.switcher-reg-btn').removeClass('selected-reg');
		$('.switcher-login-btn').addClass('selected-reg-login');
		$('.switcher-login-btn').addClass('selected-login');
		$('.confirmPassword').removeClass('hide');
		$('.phoneNumber').removeClass('hide');
		$('.login').addClass('hide');
		$('.reg').removeClass('hide');
		$('.login-block').addClass('login-block-reg');
		$('.login-block').removeClass('login-block-login');
	});
});