/*
 *  Document   : readyChat.js
 *  Author     : pixelcave
 *  Description: Custom javascript code used in Chat page
 */

var ReadyChat = function() {
    var chatHeight          = 600; // Default chat container height in large screens
    var chatHeightSmall     = 300; // Default chat components (talk & people) height in small screens

    /* Cache some often used variables */
    var chatCon             = $('.chatui-container');
    var chatTalk            = $('.chatui-talk');
    var chatTalkScroll      = $('.chatui-talk-scroll');

    var chatPeople          = $('.chatui-people');
    var chatPeopleScroll    = $('.chatui-people-scroll');

    var chatInput           = $('.chatui-input');
    var chatMsg             = '';

    /* Updates chat UI components height */
    var updateChatHeight = function(){
        var windowW = window.innerWidth
                        || document.documentElement.clientWidth
                        || document.body.clientWidth;

        if (windowW < 768) { // On small screens
            chatCon
                .css('height', (chatHeightSmall * 2) + chatInput.outerHeight())
            .css('width', '100%');

            chatTalk
                .add(chatTalkScroll)
                .add(chatTalkScroll.parent())
                .css('height', chatHeightSmall);
        }
        else if (windowW > 767) { // On large screens
            chatCon
                .css('height', chatHeight)
            .css('width', '100%');
            chatTalk
                .add(chatTalkScroll)
                .add(chatTalkScroll.parent())
                .css('height', chatHeight - chatInput.outerHeight())
            .css('width', '100%');

            chatPeople
                .css('height', chatHeight);
        }
    };

    return {
        init: function () {

           

            $(document).ready(function () {//tüm forumların submitlerini devre dışı bırakıyor

                $('ul').on('click', '.itemDelete', function () {
                   var mesaj= $(this).attr("data-text");

                    $.ajax({
                        type: "POST",
                        url: "/Odev/MessageRemoveByContent",
                        data: { 'mesaj': mesaj }
                    });


                    $(this).parent().remove();//javascript ile ekleneni kaldırmak için
                });


                $.remove = function(event){
                    var id = $('#id').val();
                    $.ajax({
                        type: "POST",
                        url: "/Odev/MessageRemove",
                        data: { 'id': id, 'msgId': event }
                    });
                    $("#"+event).closest("li").remove();
                     
                }

              
  
                    
            });

            $(document).ready(function (event) {//tüm forumların submitlerini devre dışı bırakıyor


                $('form').submit(function (event) {
                    event.preventDefault();
                    //add stuff here
                });
            });
            // Initialize default chat height
            updateChatHeight();

            // Update chat UI components height on window resize
            $(window).resize(function(){ updateChatHeight(); });

            // Initialize scrolling on chat talk + people
            chatTalkScroll
                .slimScroll({
                    height: chatTalk.outerHeight(),
                    color: '#000',
                    size: '3px',
                    position: 'right',
                    touchScrollStep: 100
                });

            //chatPeopleScroll
            //    .slimScroll({
            //        height: chatPeople.outerHeight(),
            //        color: '#fff',
            //        size: '3px',
            //        position: 'right',
            //        touchScrollStep: 100
            //    });
             
            //Sil formu bul görselden remove veritabanından sil

        

          
            // When the chat message form is submitted
            chatInput
                .find('form')
                .submit(function(e){
                    // Get text from message input
                    chatMsg = chatInput.find('#mesaj').val();

                    // If the user typed a message
                    if (chatMsg) {
                        // Add it to the message list

                        var typeChatCss = $('#UserType').val();
                        chatTalk
                            .find('ul')
                            .append('<li class=\''+typeChatCss+'\'>'
                                    + '<img src="/content/img/placeholders/avatars/avatar2.jpg" alt="Kullanıcı" class="itemDelete img-circle chatui-talk-msg-avatar" data-text="' + chatMsg + '" >'
                                    + $('<div />').text(chatMsg).html()
                                    + '</li>');

                        // Scroll the message list to the bottom
                        chatTalkScroll
                            .animate({ scrollTop: chatTalkScroll[0].scrollHeight },150);

                        

                        var id = $('#id').val();
                     
                        var msg = $('#mesaj').val();
 

                        $.ajax({
                            type: "POST",
                            url: "/Odev/Message",
                            data: { 'id': id, 'msj': msg }
                        });

                        // Reset the message input
                        chatInput
                            .find('#mesaj')
                            .val('');

                    }

                    // Don't submit the message form
                    e.preventDefault();
                });
        }
    };
}();
