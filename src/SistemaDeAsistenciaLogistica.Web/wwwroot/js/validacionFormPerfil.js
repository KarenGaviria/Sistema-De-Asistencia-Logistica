// ====================================================================
$(document).ready(function () {

    // =================================================================
    // FORM VALIDATION FEEDBACK ICONS
    // =================================================================
    var faIcon = {
        valid: 'fas fa-check-circle fa-lg text-success',
        invalid: 'fas fa-times-circle fa-lg text-danger',
        validating: 'fas fa-redo'
    }
    // =================================================================

    // =================================================================
    // Validación de Creación de Objetivo
    // =================================================================
    $('#createPerfilForm')
        .on('init.field.bv', function (e, data) {
            // $(e.target)  --> The field element
            // data.bv      --> The BootstrapValidator instance
            // data.field   --> The field name
            // data.element --> The field element
            var $parent = data.element.parents('.form-group'),
                $icon = $parent.find('.form-control-feedback[data-bv-icon-for="' + data.field + '"]'),
                $label = $parent.find('label');

            // Place the icon right after the label
            $icon.insertAfter($label);
        })
        .bootstrapValidator({
            //message: 'Este valor no es válido.',
            feedbackIcons: faIcon,
            fields: {
                "PrimerNombre": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El nombre es obligatorio.'
                        },
                        stringLength: {
                            max: 15,
                            message: 'El nombre debe tener un máximo de 15 caracteres.'
                        },
                    }
                },
                "PrimerApellido": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El Apellido es obligatorio.'
                        },
                        stringLength: {
                            max: 15,
                            message: 'El nombre debe tener un máximo de 15 caracteres.'
                        },
                    }
                },
                "Direccion": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'La dirección es obligatoria.'
                        },
                        stringLength: {
                            max: 25,
                            message: 'La dirección debe tener un máximo de 25 caracteres.'
                        },
                    }
                },
            }
        })
        .on('error.validator.bv', function (e, data) {
            // $(e.target)    --> The field element
            // data.bv        --> The BootstrapValidator instance
            // data.field     --> The field name
            // data.element   --> The field element
            // data.validator --> The current validator name

            data.element
                .data('bv.messages')
                // Hide all the messages
                .find('.help-block[data-bv-for="' + data.field + '"]').hide()
                // Show only message associated with current validator
                .filter('[data-bv-validator="' + data.validator + '"]').show();
        });


});