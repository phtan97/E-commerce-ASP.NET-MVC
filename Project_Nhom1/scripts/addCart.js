var addcart = {
    init: function () {
        addcart.registerEvents();
    },
    registerEvents: function () {
        $('#btnAddCart').off('click').on('click', function (e) {
            
            var Quantity = $('.jsonqty').val();
            var id = $(this).data('id');
            var products = $('.jsonqty');
            var productlist = [];
            //$.each(products, function (i, item) {
            //    productlist.push({
            //        Quantity: $(item).val(),
            //        Product: {
            //            IDProduct: $(item).data('id')
            //        }
            //    });
            //});
            productlist.push({
                Quantity: {
                    Quantity
                },
                Product: {
                    IDProduct: id
                }
            })
            $.ajax({
                data: { id: id },
                url: '/Cart/AddCart' + '?' + 'productID=' + id + '&' + 'quantity=' + Quantity,
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    if (res.status == true) {
                        window.location.reload()
                    }
                }

            })
            console.log(productlist)
           
        });
    }
}
addcart.init();