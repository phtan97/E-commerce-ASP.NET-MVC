var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function(){
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.ajaxqty');
            var cartList = [];
            $.each(listProduct,function(i,item){
            cartList.push({
                Quantity: $(item).val(),
                Product: {
                    IDProduct: $(item).data('id')
                }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });
        $('.close').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });
       
    }
}
cart.init();