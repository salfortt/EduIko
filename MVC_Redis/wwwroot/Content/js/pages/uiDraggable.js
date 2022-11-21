///*
// *  Document   : uiDraggable.js
// *  Author     : pixelcave
// *  Description: Custom javascript code used in Draggable Blocks page
// */

//var UiDraggable = function() {

//    return {
//        init: function() {
//            /* Initialize draggable and sortable blocks, check out more examples at https://jqueryui.com/sortable/ */
//            $('.dro').sortable({
//                connectWith: '.li',
//                items: '.li',
//                opacity: 0.75,
//                handle: '.dro',
//                placeholder: 'draggable-placeholder',
//                tolerance: 'pointer',
//                start: function(e, ui){
//                    ui.placeholder.css('height', ui.item.outerHeight());
//                }
//            });
//        }
//    };
//}();


/*
 *  Document   : uiDraggable.js
 *  Author     : pixelcave
 *  Description: Custom javascript code used in Draggable Blocks page
 */

var UiDraggable = function () {

    return {
        init: function () {
            /* Initialize draggable and sortable blocks, check out more examples at https://jqueryui.com/sortable/ */
            //$('.draggable-blocks').sortable({
            //    connectWith: '.block',
            //    items: '.block',
            //    opacity: 0.75,
            //    handle: '.block-title',
            //    placeholder: 'draggable-placeholder',
            //    revert: true,
            //    tolerance: 'pointer',
            //    start: function(e, ui){
            //        ui.placeholder.css('height', ui.item.outerHeight());
            //    }
            //});
            //$(".gurkan").draggable({
            //    connectToSortable: ".draggable-blocks",
            //    helper: "clone",
            //    revert: "invalid"
            //});



            $(".sortable").sortable({
                revert: true,
                items: '.dro',
                opacity: 0.75,
                handle: '.urun',
                placeholder: 'draggable-placeholder',
                revert: true,
                tolerance: 'pointer',
                start: function (e, ui) {
                    ui.placeholder.css('height', ui.item.outerHeight());
                }
            }).bind('sortupdate', function (event) {
                //   $('li').on( alert( $(this).text())) ;
                //$(this).on('click', 'li', function (event) {
                //    console.log(this); // logs the list item that was clicked
                //});

                //Triggered when the user stopped sorting and the DOM position has changed.
                $('li').on('dblclick' // or 'click'
                    , function (event) {
                        // console.log('clicked', $(this).text());
                        $(this).remove();
                    });
            });

            $("ul, li").disableSelection();




            $(".dro").draggable({
                connectToSortable: ".sortable",
                helper: "clone",
                revert: "invalid"
            });
            $("ul, li").disableSelection();




        }
    };
}();