$(document).ready(function () {
	$('.popup-cover').click(function () {
		$('.nice-popup').addClass('hide');
	});

	$('.log-in').click(function () {
		$('.nice-popup').removeClass('hide');
	});

	$('.switcher-login-btn').click(function () {
		$('.switcher-login-btn').removeClass('non-selected-reg-login');
		$('.switcher-login-btn').removeClass('non-selected-login');
		$('.switcher-reg-btn').addClass('non-selected-reg-login');
		$('.switcher-reg-btn').addClass('non-selected-reg');
		$('.for-reg').addClass('hide');
		$('.for-login').removeClass('hide');
		//$('.phoneNumber').addClass('hide');
		//$('.login').removeClass('hide');
		/*$('.reg').addClass('hide');*/
		$('.login-block').addClass('login-block-login');
		$('.login-block').removeClass('login-block-reg');
	});

	$('.switcher-reg-btn').click(function () {
		$('.switcher-reg-btn').removeClass('non-selected-reg-login');
		$('.switcher-reg-btn').removeClass('non-selected-reg');
		$('.switcher-login-btn').addClass('non-selected-reg-login');
		$('.switcher-login-btn').addClass('non-selected-login');
		$('.for-reg').removeClass('hide');
		$('.for-login').addClass('hide');
		//$('.phoneNumber').removeClass('hide');
		//$('.login').addClass('hide');
		//$('.reg').removeClass('hide');
		$('.login-block').addClass('login-block-reg');
		$('.login-block').removeClass('login-block-login');
	});
});