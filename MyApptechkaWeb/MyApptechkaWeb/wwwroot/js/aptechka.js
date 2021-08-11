$(document).ready(function () {
    $('.template-aptechka').click(function () {
        $('.aptechka-temp-popup').removeClass('hide');
    })

    $('.aptechka-temp-popup-cover').click(function () {
        $('.aptechka-temp-popup').addClass('hide');
    })

    $('.btn-popup-edit-aptechka.special-for-popup').click(function () {
        $('.aptechka-edit-info-popup').removeClass('hide');
    })

    $('.aptechka-edit-info-popup-cover').click(function () {
        $('.aptechka-edit-info-popup').addClass('hide');
    })
})