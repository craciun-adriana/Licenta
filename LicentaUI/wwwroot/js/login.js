function tryLogin() {
    return;
    var loginDetails = {
        'UserName': $('#userName').val(),
        'Password': $('#password').val(),
        'RememberMe': $('#rememberMe').is(':checked')
    };
    var settings = {
        processData: false,
        cache: false,
        async: true,
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(loginDetails),
        crossDomain: true,
        headers: {
            'accept': "application/json",
            'Access-Control-Allow-Origin': "https://localhost:5001",
            'Access-Control-Allow-Credentials': 'true'
        },
        success: (output, status, xhr) => {
            debugger
            console.log(xhr.getResponseHeader('.AspNetCore.Identity.Application'));
        }
    };

    $.ajax(`https://localhost:5001/licenta/auth/login`, settings);
}