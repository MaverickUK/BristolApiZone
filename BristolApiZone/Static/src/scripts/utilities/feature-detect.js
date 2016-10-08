const UA                     = navigator.userAgent;
const ANDROID_TWO            = 'Android 2.';
const ANDROID_FOUR           = 'Android 4.0';
const ANDROID_FOUR_POINT_ONE = 'Android 4.1';
const MOBILE_SAFARI          = 'Mobile Safari';
const CHROME                 = 'Chrome';
const WINDOWS_PHONE          = 'Windows Phone';

// test if css property is supported in the browser
function isSupported(property) {
    return (property in document.documentElement.style);
}

// Search user agent string for agent
let userAgentIs = agent => UA.indexOf(agent) !== -1;

let hasAppearance = (function () {
    return ( (isSupported('appearance')) || (isSupported('WebkitAppearance')) );
}());

// Flexbox detext, only detects 'display: flex' support
let hasFlexbox = (function() {
    return ((isSupported('flex')) || (isSupported('WebkitFlex')) || (isSupported('msFlex')));
}());

// History API
let hasHistory = (function() {
    // this is taken from modernizr to test for history API support, we have added a separate condition for android 4.1 as this also seems to be lacking support
    let modernizrCondition = (userAgentIs(ANDROID_TWO) || userAgentIs(ANDROID_FOUR)) && userAgentIs(MOBILE_SAFARI) && !userAgentIs(CHROME) && !userAgentIs(WINDOWS_PHONE);

    if (modernizrCondition || userAgentIs(ANDROID_FOUR_POINT_ONE)) {
        return false;
    }

    return (window.history && 'pushState' in window.history);
}());

// sessionStorage
let hasSessionStorage = (function() {
    if (typeof sessionStorage !== 'object') {
        return false;
    }

    try {
        sessionStorage.setItem('sessionStorage', 1);
        sessionStorage.removeItem('sessionStorage');
        return true;
    } catch (e) {
        return false;
    }
}());

// Touch event detection
let hasTouch = (function() {
    let DocumentTouch = window.DocumentTouch;
    return !!(('ontouchstart' in window) || window.DocumentTouch && document instanceof DocumentTouch);
}());

// Is Any version of Internet Explorer
let isIE = (function() {
    var msie = UA.indexOf('MSIE ');
    if (msie > 0 || !!UA.match(/Trident.*rv\:11\./)) {
        return true;
    } else {
        return false;
    }
}());

// Is specifically Internet Explorer 10
let isIE10 = (function() {
    return !!Function('/*@cc_on return document.documentMode===10@*/')();
}());

let isHTTPS = (function() {
    if (window.location.protocol === 'https:') {
        return true;
    } else {
        return false;
    }
}());

// Hardware Acceleration detection
let isHardwareAccelerated = (function() {
    if (!window.getComputedStyle) {
        return false;
    }
    var el = document.createElement('p');
    var has3d;
    var transforms = {
        'transform':'transform'
    };
    document.body.insertBefore(el, null);
    for (var t in transforms) {
        if (el.style[t] !== undefined) {
            el.style[t] = 'translate3d(1px,1px,1px)';
            has3d = window.getComputedStyle(el).getPropertyValue(transforms[t]);
        }
    }
    document.body.removeChild(el);
    return (has3d !== undefined && has3d.length > 0 && has3d !== 'none');
}());

let isFrame = (function() {
    try {
        return window.self !== window.top;
    } catch (e) {
        return true;
    }
}());

let requestAnimationFrame = (function() {
    if (typeof window.requestAnimationFrame === 'function') {
        return true;
    } else {
        return false;
    }
}());

export {
    hasAppearance,
    hasFlexbox,
    hasHistory,
    hasSessionStorage,
    hasTouch,
    isIE,
    isIE10,
    isSupported,
    isHTTPS,
    isHardwareAccelerated,
    isFrame,
    requestAnimationFrame
};
