import $ from 'jquery';

import Map from './modules/map';

function init() {

    let mapContext = $('[data-behavior~="map"]');
    if (mapContext.length > 0) {
        for (var map of mapContext) {
            new Map(map);
        }
    }
}

init();
