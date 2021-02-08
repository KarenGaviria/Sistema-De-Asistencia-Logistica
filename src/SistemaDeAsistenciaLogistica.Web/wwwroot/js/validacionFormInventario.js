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
    $('#createInventarioForm')
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
                "FechaIngreso": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'La fecha de ingrso es obligatoria.'
                        },
                    }
                },
                "Cantidad": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'La cantidad del insumo es obligatoria.'
                        },
                        stringLength: {
                            min: 1,
                            max: 10,
                        },
                    }
                },
                "ValorUnidadValorMetro": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El valor por unidad/metro es oblicatorio.'
                        },
                    }
                },
                "ValorTotal": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El valor total es oblicatorio.'
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