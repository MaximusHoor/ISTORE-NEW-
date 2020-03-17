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
    $('.quick-wiew-button').on('click', function () {
        var parameters = products.find(x => x.id == parseInt($(this).parents('.product-thumb').find('.mainProductId').val()));
        $.ajax({
            type: 'POST',
            url: '/Home/GetProductDetails',
            data: { parameters: JSON.stringify(parameters) },
            success: function (responce) {
                $.magnificPopup({
                    items: {
                        src: responce,
                        type: 'inline'
                    }
                });
                slick_quickview_popup();
            }
        });
        });
            //$(this).magnificPopup({
            //    items: {
            //        type: 'ajax',
            //        src: "/Home/GetProductDetails/",
            //        data: {
            //            parameters: parameters
            //        }  
            //    },
            //    callbacks: {
            //        updateStatus: function (data) {
            //            if (data.status === 'ready') {
            //                slick_quickview_popup();
            //            }
            //        }
            //    }
            //});


                //ajax: {
                //    settings: {
                //        url: "/Home/GetProductDetails/",
                //        data: {
                //        parameters: parameters
                //    }
                //    }
                //    //method: "POST",
                //    //data: {
                //    //    parameters: parameters
                //    //}
                //},
                
        //$(this).magnificPopup({
        //    type: 'ajax',
        //    preloader: false,
        //    ajax: {
        //        method: "POST",
        //        data: {
        //            parameters: parameters
        //        }
        //    },
        //    callbacks: {
        //                updateStatus: function (data) {
        //                if (data.status === 'ready') {
        //                    slick_quickview_popup();
        //                }
        //            }
        //            }
        //});
                //$.magnificPopup.open({
                //    items: {
                //        type: 'ajax',
                //        src: "/Home/GetProductDetails",
                        
                //    },
                //    callbacks: {
                //        updateStatus: function (data) {
                //        if (data.status === 'ready') {
                //            slick_quickview_popup();
                //        }
                //    }
                //    }
                //});
            //    return false;
            //});
    //$('.quick-wiew-button').magnificPopup({
            //    src: "/Home/GetProductDetails/" + parseInt($(this).parents('.product-thumb').find('.product-id').text()),
            //    type: 'ajax',
            //    callbacks: {
            //        updateStatus: function (data) {
            //            if (data.status === 'ready') {
            //                slick_quickview_popup();
            //            }
            //        }
            //    }
                
            //});
});