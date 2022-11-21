var Quiz = function() {
   

  
    return {
        init: function () {

            var msg = $('#mesaj').val();
          

            $(document).ready(function () {//tüm forumların submitlerini devre dışı bırakıyor


                
                $("input[type=radio]").on('click', function () {
                    console.log("00");
                    console.log($(this).data('qid') + ' ' + $(this).val() + ' ' + $(this).data('exam'));
                    $.ajax({
                        type: "POST",
                        url: "/Quiz/SetQuestionaryAnswer",
                        data: { 'id': $(this).data('qid'), 'reply': $(this).val() , 'examId': $(this).data('exam') }
                    });

                })
              
                $.LookedUP = {
                    soruCozum: function (answer,exam,id) {
                       // var id = $('#id').val();
                        //  var reply = event.data("reply");
    //                    $(".action").click(
    //function () {
    //    if ($(this).hasClass("red")) {
    //        $(this).removeClass("red");
    //        $(this).addClass("yellow");
    //    } else {
    //        $(this).removeClass("yellow");
    //        $(this).addClass("red");
    //    }
    //});
                        var secimIptal=false;
                         
                        var choosen = ["A", "B", "C", "D"];
                        var index = choosen.indexOf(answer);
                        if (index > -1) {
                            choosen.splice(index, 1);
                        }
                        
                        if (answer != null) {
                            var elem = $('#' + answer);
                          //  console.log(elem);
                           // alert(elem);
                            if (!elem.hasClass('btn-alt')) {//Seçim iptal alanı
                                /*Seçim İptal*/
                                secimIptal = true;
                                elem.addClass("btn-alt");//"btn  btn-success" seçili durum   //////" btn  btn-success btn-alt" seçili olmayan durum"
                                $(elem).css("background-color", "#fff");
                                $(elem).css("color", "#f39c12");//butonun seçili olmama durumu
                                $('#' + id).removeClass("btn-success");
                             
                                console.log("Seçim iptal alanı");

                            } else {//Seçim var 
                                elem.removeClass("btn-alt");
                                $(elem).css("background-color", "#7db831");
                                $(elem).css("color", "#fff");
                                $('#' + id).addClass("btn-success");
                                $('#' + id).attr("data-secim", answer);
                                console.log(answer);
                               

                            }
                            
                            choosen.forEach(function (item) {
                                //alert(item);
                                $('#' + item).addClass('btn-alt');//burada diğerlerinden seçim kaldırılıyor
                                $('#' + item).css("background-color", "#fff");
                                $('#' + item).css("color", "#7db831");
                               
                            });
                        }



                 
                        $.ajax({
                            type: "POST",
                            url: "/Quiz/soruCozum",
                            data: { 'id': id, 'reply': answer, 'examId': exam, 'secimIptal': secimIptal }
                        });
                    },
 
                    ExamRemove: function (id) {
                        $.ajax({
                            type: "POST",
                            url: "/Quiz/ExamRemove",
                            data: { 'id': id },
                            success: function () {
                                location.reload();
                            }
                        });
                    }
 
                }
 
            
                    
            });
 
        }
    };
}();
