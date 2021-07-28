$(document).ready(function () {
    $('.template-aptechka').click(function () {
        $('.aptechka-temp-popup').removeClass('hide');
    })

    $('.aptechka-temp-popup-cover').click(function () {
        $('.aptechka-temp-popup').addClass('hide');
    })
})