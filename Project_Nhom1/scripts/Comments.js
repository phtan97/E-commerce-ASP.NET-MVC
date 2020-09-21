//var Comments = {
//    init: function () {
//        Comments.registerEvents();
//    },
//    registerEvents: function () {
//        $('#SubmitComment').off('click').on('click', function () {
//            var products = $('.jsonqty').data('id')
//            var Comments = []
//            Comments.push({
//                Name: $('#Name').val(),
//                Body: $('#Body').val(),
//                ProductID: products
//            })
            
//            $.ajax({
//                data: { id: products },
//                url: '/Product/Comments/' + products,
//                type: 'POST',
//                dataType: 'JSON',
//                success: function (res) {
//                    if (res.status == true) {
//                        window.location.href="Product/Index"
//                    }
//                }

//            })

//        });
//    }
//}
//Comments.init();