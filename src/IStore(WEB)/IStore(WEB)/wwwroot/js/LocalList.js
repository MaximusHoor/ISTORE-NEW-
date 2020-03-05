var localList = function (localName) {
    var local = localStorage.getItem(localName);
    var items = local ? JSON.parse(local) : new Array();

    return {
        "add": function (val) {
            items.push(val);
            localStorage.setItem(localName, JSON.stringify(items));
        },
        "remove": function (val) {
            indx = items.indexOf(val);
            if (indx != -1) items.splice(indx, 1);
            localStorage.setItem(localName, JSON.stringify(items));
        },
        "clear": function () {
            items = null;
            localStorage.setItem(localName, null);
        },
        "items": function () {
            return items;
        },
        "replaceItems": function (val) {
            items = val;
            localStorage.setItem(localName, JSON.stringify(items));
        }
    }
}