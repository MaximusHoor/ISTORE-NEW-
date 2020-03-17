$(function () {
    $.ajax({
        type: 'POST',
        url: '/Cart/ShoppingCartProductsPartial',
        data: { parameters: JSON.stringify(new localList("IStoreProduct").items()) },
        success: function (responce) {
            $(".shop_table tbody").html(responce);
            $(".qty").each(function () {
                subtotal($(this));
            });
            totalpricecart();
        }
    });
});
function subtotal(obj) {
    var q = $(obj).val();
    var p = $(obj).parents(".cart_item");
    var price = $(p).find(".price").text();
    $(p).find(".sub").text(q * price);
};
function totalpricecart() {
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
        product.Count = parseInt($(this).find(".qty").val());
        products.push(product);
    });
    new localList("IStoreProduct").replaceItems(products);
};
function deleteproduct(obj) {
    $(obj).parents(".cart_item").remove();
    updateorder();
    totalpricecart();
    MinicartCount();
};