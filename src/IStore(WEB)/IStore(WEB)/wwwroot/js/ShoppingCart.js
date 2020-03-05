$(function () {
    //var prod = new cookieList("IStoreProduct").items;
    $(".shop_table tbody").load("/Cart/ShoppingCartProductsPartial", JSON.stringify(new localList("IStoreProduct").items));
    $(".qty").each(function () {
        subtotal(this);
    });
    totalprice();
});
function subtotal(obj) {
    var q = $(obj).val();
    var p = $(obj).parents(".cart_item");
    var price = $(p).find(".price").text();
    $(p).find(".sub").text(q * price);
};
function totalprice() {
    var s = 0;
    $(".sub").each(function () {
        s += parseFloat($(this).text());
    })
    $(".total-price").text(s);
};
function updateorder() {
    var products = new Array();
    $(".cart_item").each(function () {
        var product = new Object();
        product.Id = parseInt($(this).find(".detailsId").text());
        product.OrderId = parseInt($(this).find(".orderId").text());
        product.ProductId = parseInt($(this).find(".productId").text());
        product.Count = parseInt($(this).find(".qty").val());
        products.push(product);
    });
    new localList("IStoreProduct").replaceItems(products);
};
function deleteproduct(obj) {
    $(obj).parents(".cart_item").remove();
    updateorder();
    totalprice();
};