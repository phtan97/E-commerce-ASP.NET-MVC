var iconadd = {
    init: function () {
        iconadd.regevents();
    },
    regevents: function () {
        $('#iconAdd').off('click').on('click', '.prevent', function (e) {
            e.preventdefault();
            var Quantity = $('.jsonqty').val();
            var id = $(this).data('id');
            var productlist = [];
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
                        window.location.href
                    }
                }

            })
            console.log(productlist)

        });
    }
}
iconadd.init();