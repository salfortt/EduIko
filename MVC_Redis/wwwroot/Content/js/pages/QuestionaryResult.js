/*
 *  Document   : formsWizard.js
 *  Author     : pixelcave
 *  Description: Custom javascript code used in Forms Wizard page
 */

var FormsWizard = function() {

    return {
        init: function() {
            /*
             *  Jquery Wizard, Check out more examples and documentation at http://www.thecodemine.org
             *  Jquery Validation, Check out more examples and documentation at https://github.com/jzaefferer/jquery-validation
             */

            /* Initialize Progress Wizard */
            $('#progress-wizard').formwizard({focusFirstInput: true, disableUIStyles: true, inDuration: 0, outDuration: 0});

            // Get the progress bar and change its width when a step is shown
            var progressBar = $('#progress-bar-wizard');
            var value = progressBar.attr('aria-valuenow');
           
            progressBar
                .css('width', '\''+parseInt(value)+ '%')
                 .attr('aria-valuenow', '\''+parseInt(value)+'%');

            /* Initialize Basic Wizard */
  

            clickableWizard.formwizard({disableUIStyles: true, inDuration: 0, outDuration: 0});

            $('.clickable-steps a').on('click', function(){
                var gotostep = $(this).data('gotostep');

                clickableWizard.formwizard('show', gotostep);
            });
        }
    };
}();