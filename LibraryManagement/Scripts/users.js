﻿$(document).ready(function () {
    $('input[type=submit]').click(function (e) {
        var name = $('#Name').val();
        var surname = $('#Surname').val();
        var email = $('#Email').val();

        if (name == "" || name == undefined
            || surname == "" || surname == undefined
            || email == "" || email == undefined
        ) {
            alert("Informazioni mancanti, si prega di verificare!");
            e.preventDefault();
        }
    });
});