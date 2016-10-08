import $ from 'jquery';

import Autocomplete from './modules/autocomplete';

function init() {

    let autocompleteContext = $('[data-behavior~="autocomplete"]');
    if (autocompleteContext.length > 0) {
        for (var autocomplete of autocompleteContext) {
            new Autocomplete(autocomplete);
        }
    }
}

init();
