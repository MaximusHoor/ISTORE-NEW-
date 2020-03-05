$(function () {
    $(".block-minicart .count").val(new cookieList("IStoreProduct").items().length);
    $(".cartpartial").on("click", function () {
        $("#cartpartialview").load("/Cart/ShoppingCartPartial");
    })
});