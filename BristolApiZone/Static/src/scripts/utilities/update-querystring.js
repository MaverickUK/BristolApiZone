/**
 * Helper to update a given querystring key's value on a link element.
 * @param  { jquery element } linkElement - link element
 * @param  { String } key - querystring key
 * @param  { String } value - querystring value
 */

var getQuerystringValue = function(linkElement, key, value) {
    var urlParts = linkElement.attr('href').split('?');

    var baseUrl = urlParts[0];
    var existingQuerystring = urlParts[1];
    var keyValuePairs = existingQuerystring.split('&');
    var newQuerystring = '';
    for (var i = 0; i < keyValuePairs.length; i++) {
        if (newQuerystring !== '') {
            newQuerystring += '&';
        }

        var keyValueParts = keyValuePairs[i].split('=');
        newQuerystring += keyValueParts[0] + '=';
        if (keyValueParts[0] === key) {
            newQuerystring += value;
        } else {
            newQuerystring += keyValueParts[1];
        }
    }

    linkElement.attr('href', baseUrl + '?' + newQuerystring);
};

export default getQuerystringValue;
