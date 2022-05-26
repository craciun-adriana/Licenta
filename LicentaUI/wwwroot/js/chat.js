/**
 *
 * @param {string} id
 */
var settings = {
    cache: false,
    dataType: "json",
    async: true,
    xhrFields: { withCredentials: true },
    method: "GET",
    crossDomain: true,
    headers: {
        'accept': 'application/json',
        'Access-Control-Allow-Origin': 'https://localhost:5001',
        'Access-Control-Allow-Credentials': 'true'
    }
};

function GetMessages(id) {
    $.ajax(`https://localhost:5001/licenta/message/conversation/user/${id}`, settings).done(response => {
        console.log(response);
    });
}