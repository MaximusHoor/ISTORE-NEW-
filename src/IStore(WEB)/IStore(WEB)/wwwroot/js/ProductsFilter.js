var filterTimer;
function CollectFilters() {
    var filter = new Object();
    filter.PriceFrom = parseInt($(".price-slider-amount .from").text().replace('$', ''));
    filter.PriceTo = parseInt($(".price-slider-amount .to").text().replace('$', ''));
    filter.Color = $(".widget-color .list-color a[class*='active']").css("background");
    filter.CategoriesTitle = ActiveCategoriesFilter();
    filter.BrandsTitle = ActiveBrandsFilter();
    clearTimeout(filterTimer);
    filterTimer = setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: '/Product/GetProductsFromFilter',
            data: { filter: filter },
            success: function (responce) {

            }
        });
    }, 2000);
}
function ActiveCategoriesFilter() {
    var categories = new Array();
    $(".list-categories input").each(function () {
        if ($(this).prop("checked")) {
            categories.push($(this).siblings("label").text());
        }
    })
    return categories;
}
function ActiveBrandsFilter() {
    var brands = new Array();
    $(".list-brand input").each(function () {
        if ($(this).prop("checked")) {
            brands.push($(this).siblings("label").text());
        }
    })
    return brands;
}