$(function () {

    var products = [];

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
                $(this).find(".productPreview").attr("src", products[count].previewImage).show();
                $(this).find(".productTitle").text(products[count].title);
                $(this).find(".productModel").text(products[count].model);

                salePrice = (products[count].retailPrice * 1.15).toFixed(0);
                $(this).find(".price del").text(salePrice);

                //price = (products[count].retailPrice).replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, '$1');
                $(this).find(".price ins").text(products[count].retailPrice);
                
                count++;
            });


            
        }
    });
});