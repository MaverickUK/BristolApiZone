'use strict';

var browserSync = require('browser-sync');
var bundler     = require('../utilities/browserify');
var config      = require('../config');
var gulp = require('gulp');
var path = require('path');
var join        = require('path').join;

module.exports = function() {

    // This task should exit if we are in production
    if (config.production) {
        return;
    }

    // Create browserSync server
    browserSync(config.browserSync);

    // Watch .scss files
    gulp.watch(join(config.styles.src, '**', '*.scss'), ['styles']);

    // Watch .svg files
    gulp.watch(path.join('src/svg/svg-icons/', '**', '*.svg'), ['svgiconsprites']);
    gulp.watch(path.join('src/svg/svg-images/', '**', '*.svg'), ['svgimagesprites']);

    // Watch .js files
    bundler.on('update', function() {
        // Build the bundle
        gulp.start('scripts');
    });

};
