﻿$(function () {
    totalprice();
});
function totalprice() {
    var s = 0;
    $(".mini_cart_item").each(function () {
        s += (parseFloat($(this).find(".price").text()) * parseFloat($(this).find(".quantity").text()));
    })
    $(".Price-amount").text("₴" + s);
};
function updateorderpartial() {
    var products = [];
    $(".mini_cart_item").each(function () {
        var product = new Object();
        product.Id = parseInt($(this).find(".detailsIdpartial").text());
        product.OrderId = parseInt($(this).find(".orderIdpartial").text());
        product.ProductId = parseInt($(this).find(".productIdpartial").text());
        product.Count = parseInt($(this).find(".product-quantity").text());
        products.push(product);
    });
    $.ajax({
        type: "POST",
        url: "/cart/UpdateProducts",
        data: { parameters: JSON.stringify(products) },
        dataType: "JSON"
    });
};
function deleteproductpartial(obj) {
    $(obj).parents(".product-cart mini_cart_item").remove();
    updateorderpartial();
};