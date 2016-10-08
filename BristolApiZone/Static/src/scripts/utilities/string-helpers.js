var stringHelpers = function() {

    /// "camelCase" to "Sentence case"
    /// http://stackoverflow.com/a/13720440
    String.prototype.toSentenceCase = function() {
        return this.replace(/^[a-z]|[A-Z]/g, function(v, i) {
            return i === 0 ? v.toUpperCase() : ' ' + v.toLowerCase();
        });
    };

    /// "titleCase" to "Title Case"
    /// http://stackoverflow.com/a/196991
    String.prototype.toTitleCase = function() {
        return this.replace(/\w\S*/g, function(txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        });
    };
};

export default stringHelpers;
