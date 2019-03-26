document.getElementById('tableOfContents').addEventListener('click', function(e) {

    personalScroll(e.toElement.id)
});

$('#glower').click(function() { $.scrollTo('body', 700); });

$(window).on('scroll', function() {


    if ($(this).scrollTop() > 300) {
        $('.topNavBar').fadeOut();
        $('#glower').fadeIn();
        $('.navbar-toggler').fadeIn();
    } else {
        $('.navbar-toggler').fadeOut();
        $('.topNavBar').fadeIn();
        $('#glower').fadeOut();
    }




});

$('.navbar-toggler').click(function() {
    $('.topNavBar').show();
});


function personalScroll(id) {

    var chapterNum = String(id).charAt(10);

    $('body').scrollTo(`#chapter_${chapterNum}`, 500);
}