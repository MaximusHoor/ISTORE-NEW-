$(function () {
    $(".block-minicart .count").val(new localList("IStoreProduct").items().length);
    $(".cartpartial").on("click", function () {
        $("#cartpartialview").load("/Cart/ShoppingCartPartial");
    })
});