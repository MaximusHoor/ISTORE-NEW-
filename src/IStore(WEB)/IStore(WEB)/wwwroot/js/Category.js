$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Category/GetCategoryJson",
        dataType: 'json',
        success: function (data) {
            $.each(data, function (i) {
                if (data[i].subcategories == 0) {
                    $("#category").append("<li class='menu-item'> <a href='index.html#' class='tanajil-menu-item-title' title=" + data[i].title + ">" + data[i].title + "</a></li>");
                }
                else {
                    $("#category").append("<li class='menu-item menu-item-has-children'><a  href='index.html#' class='tanajil-menu-item-title' title=" + data[i].subcategories[i].title + ">" + data[i].subcategories[j].title + "</a><span class='toggle-submenu'></span><ul id='category-submenu' role='menu' class='submenu'></ul></li>");
                    $.each(data[i].subcategories, function (j) {
                        $("#category-submenu").append("<li class='menu-item'><a href='index.html#' class='tanajil-item-title' title=" + data[i].subcategories[j].title + ">" + data[i].subcategories[j].title + "</a></li>");
                    })
                }
            });
        },
        //error: function () {
        //    alert("AjaxError");
        //}
    });
});