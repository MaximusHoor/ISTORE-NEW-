$(function () {

    var products = new Array();

    $.ajax({



        type: "POST",   //запрос
        url: "Home/GetProducts",
        dataType: "Json",
        success: function (data) {            
            products = data;
           
            count = 0;
            $(".product-item").each(function () {     
               
                $(this).find(".mainProductId").val(products[count].id);
                $(this).find(".product-top").show();
                $(this).find(".stars-rating").show();
                $(this).find(".productPreview").attr("src", products[count].previewImage).show().parent().attr("href", "/Product/Product/" + products[count].id);
                $(this).find(".productTitle").text(products[count].title);
                $(this).find(".productModel").text(products[count].model);

                salePrice = (products[count].retailPrice * 1.15).toFixed(0);
                $(this).find(".price del").text(salePrice);

                //price = (products[count].retailPrice).replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, '$1');
                $(this).find(".price ins").text(products[count].retailPrice);
                $(this).find(".equal-element").attr("style", "height: 320px"); //окончательный размер окошка с продуктом
                count++;
            });


            
        }
    });
    $('.quick-wiew-button').on('click', function () {
        var parameters = products.find(x => x.id == parseInt($(this).parents('.product-thumb').find('.mainProductId').val()));
        $.ajax({
            type: 'POST',
            url: '/Home/GetProductDetails',
            data: { parameters: JSON.stringify(parameters) },
            success: function (responce) {
                $.magnificPopup.open({
                    items: {
                        src: responce,
                        type: 'inline'
                    }
                });
                slick_quickview_popup();
            }
        });
    });
});