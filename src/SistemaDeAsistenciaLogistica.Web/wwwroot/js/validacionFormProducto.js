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
    $('#createProductoForm')
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
                "Nombre": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El nombre del producto es obligatorio.'
                        },
                        stringLength: {
                            max: 30,
                            message: 'El nombre de producto debe tener un máximo de 30 caracteres.'
                        },
                    }
                },
                "PrecioUnidad": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El precio por unidad es requerido.'
                        },
                        stringLength: {
                            max: 10,
                            message: 'El precio de producto debe tener un máximo de 10 caracteres.'
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