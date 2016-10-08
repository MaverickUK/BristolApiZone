

/**
 * Helper to get a given querystring key's value on a link element.
 * Hat-tip: http://www.jquerybyexample.net/2012/05/how-to-get-querystring-value-using.html
 * @param  { jquery element } linkElement - link element
 * @param  { String } key - querystring key
 * @returns { String } - querystring value
 */
var updateQuerystring = function(linkElement, key) {
    var url = linkElement.attr('href').split('?')[1];
    var keyValuePairs = url.split('&');
    for (var i = 0; i < keyValuePairs.length; i++) {
        var keyValueParts = keyValuePairs[i].split('=');
        if (keyValueParts[0] === key) {
            return keyValueParts[1];
        }
    }
};

export default updateQuerystring;
