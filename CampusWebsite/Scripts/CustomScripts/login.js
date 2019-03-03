/// <reference path="../jquery-3.3.1.min.js" />

$(document).ready(function () {
    $("#loginForm").submit(function (e) {
        e.preventDefault();
        var userName;
        var password;
        userName = $('#inputUserName').val();
        password = $('#inputPassword').val();
       
        var credential = { 'userName': userName, 'password': password };
        credential = JSON.stringify({ 'credential': credential });
        $.ajax({
            url: '/Login/Login',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: credential,
            async: true,
            success: function (data) {

                console.log("post done=" + data);
                window.location.href = data;
            }
        });
        
    });
})