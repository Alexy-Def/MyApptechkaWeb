$(document).ready(function () {
	var arr = ['.test1', '.test2', '.test3', '.test4'];
	//var t = arr[0];
	//var tt = `${arr[0]}`;
	$('.test999').click(function () {
		$('.test1').focus();
		for (var i = 0; i < 3; i++) {
			$(`${arr[i]}`).keyup(function () {
				$(this).next().focus();
			})
		}
		//console.log(t);
		//console.log(tt);

		//$('.test1').keyup(function () {
		//	$(this).next('.test2').focus();
		//})
		//$('.test2').keyup(function () {
		//	$(this).next('.test3').focus();
		//})
		//$('.test3').keyup(function () {
		//	$(this).next('.test4').focus();
		//})
    })
	//for (var i = 0; i < 4; i++) {
	//	$(`\'${arr[i]}\'`).keyup(function () {
	//		$(this).next(`\'${arr[i + 1]}\'`).focus();
 //       })
 //   }

	//$('.test1').keyup(function () {
	//	$(this).next('.test2').focus();
 //   })

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