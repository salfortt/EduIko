/*
 *  Document   : tablesDatatables.js
 *  Author     : pixelcave
 *  Description: Custom javascript code used in Tables Datatables page
 */

var TablesDatatables = function() {

    return {
        init: function () {


            //$('#droppable').sortable({
            //    connectWith: '.block',
            //    items: '.block',
            //    opacity: 0.75,
            //    handle: '.block-title',
            //    placeholder: 'draggable-placeholder',
            //    tolerance: 'pointer',
            //    start: function (e, ui) {
            //        ui.placeholder.css('height', ui.item.outerHeight());
            //    }
            //});



            //$(".draggable").draggable({ });
            //$("#droppable").droppable({ });
         


            /* Initialize Bootstrap Datatables Integration */
            App.datatables();

            /* Initialize Datatables */
            $('#example-datatable').dataTable({
                columnDefs: [{ orderable: true, targets: [ 1, 3 ] } ],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
            $('#example-datatableToplam').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 5] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });

            $('#example-datatableDersler').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 6] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });

      
            $('#tableRehberlik').dataTable({
                order: [[4, 'asc']],
                columnDefs: [{ orderable: false, targets: [1, 6] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
           
            //order: [[1, 'desc']],
            //    columns: [
            //        { orderable: false, width: "8%" },
            //        null,
            //        null,
            //        null,
            //        { orderable: false, width: "8%" },
            //        { orderable: false, width: "8%" }
            //    ]
            $('#odevTable').dataTable({
                columnDefs: [{ orderable: false, targets: [1, 7] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
            $('#QuestionaryResultTable').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 3] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
            $('#YoklamaTable').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 5] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
            $('#OdevReport').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 5] }],//kolon sayısını istiyor
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
            $('#myTable').dataTable({
                columnDefs: [{ orderable: true, targets: [1, 7] }],//kolon sayısını istiyor
                pageLength: 30,
                lengthMenu: [[30, 40, 50 - 1], [30, 40, 50, 'Hepsi']]
            });  
        


       

            $('#datatableQuestionList').dataTable({
                columnDefs: [{ orderable: false, targets: [1, 7] }],//kolon sayısını istiyor
                ordering: false,
                pageLength: 10,
                lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'Hepsi']]
            });
          
        
            
               
            /* Add placeholder attribute to the search input */
            $('.dataTables_filter input').attr('placeholder', 'Ara ...');
        }
    };
}();