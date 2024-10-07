// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#Password").on("keypress", function () {
    $(".confirm-password").removeClass("d-none");
});

$("#Password").on("focusout", function () {
    if (!$("#Password").val()) {
        $("#ConfirmPassword").val("");
        $(".confirm-password").addClass("d-none");
    }
});
