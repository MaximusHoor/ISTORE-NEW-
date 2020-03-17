
$(document).ready(function () {
    var pathname = window.location.pathname;
    var urlParam = pathname.split('/');
    if (urlParam[2] == null) {
        $("#BreadCrumbs").append("<li class= 'trail-item trail-end'> " + urlParam[1] + "</li>");
    }
    else {
        $.each(urlParam, function (i) {
            if(i !=0)$("#BreadCrumbs").append("<li class= 'trail-item trail-end'>" + urlParam[i] + "</li>");
        });
    }
})

