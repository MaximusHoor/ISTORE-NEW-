var cookieList = function (cookieName) {
    var cookie = $.cookie(cookieName);
    var items = cookie ? cookie.split(/,/) : new Array();

    return {
        "add": function (val) {
            items.push(val);
            document.cookie = cookieName + '=' + items.join(',');
        },
        "remove": function (val) {
            indx = items.indexOf(val);
            if (indx != -1) items.splice(indx, 1);
            $.cookie(cookieName, items.join(','));
        },
        "clear": function () {
            items = null;
            $.cookie(cookieName, null);
        },
        "items": function () {
            return items;
        }
    }
}