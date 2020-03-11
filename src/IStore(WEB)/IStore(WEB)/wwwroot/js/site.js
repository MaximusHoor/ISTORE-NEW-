$(function () {
    MinicartCount();
    $(".cartpartial").on("click", function () {
        $.ajax({
            type: 'POST',
            url: '/Cart/ShoppingCartPartial',
            data: { parameters: JSON.stringify(new localList("IStoreProduct").items())},
            success: function (responce) {
                $("#cartpartialview").html(responce);
                totalprice();
            }
        });
    });
});
function MinicartCount() {
    $(".block-minicart .count").text(new localList("IStoreProduct").items().length);
}
function updateorderpartial() {
    var products = new Array();
    $(".mini_cart_item").each(function () {
        var product = new Object();
        product.Id = parseInt($(this).find('.partial-id').text());
        product.Description = $(this).find('.partial-description').text();
        product.Model = $(this).find('.partial-model').text();
        product.PreviewImage = $(this).find('.partial-previewimage').text();
        product.Rating = parseInt($(this).find('.partial-rating').text());
        product.RetailPrice = parseFloat($(this).find('.partial-retailprice').text());
        product.Series = $(this).find('.partial-series').text();
        product.Title = $(this).find('.partial-title').text();
        product.Type = $(this).find('.partial-type').text();
        product.VendorCode = $(this).find('.partial-vendorcode').text();
        product.WarrantyMonth = parseInt($(this).find('.partial-warrantymonth').text());
        product.Count = parseInt($(this).find('.product-quantity .quantity').text());
        products.push(product);
    });
    new localList("IStoreProduct").replaceItems(products);
};
function deleteproductpartial(obj) {
    $(obj).parents(".mini_cart_item").remove();
    updateorderpartial();
    totalprice();
    MinicartCount();
};
function totalprice() {
    var s = 0;
    $(".mini_cart_item").each(function () {
        s += (parseFloat($(this).find(".price").text()) * parseFloat($(this).find(".quantity").text()));
    })
    $(".Price-amount").text("₴" + s);
};