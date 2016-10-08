'use strict';

var config  = require('./config');
var gulp    = require('gulp');
var util    = require('gulp-util');

// What mode?
util.log('Running in', (config.production ? util.colors.red.bold('production') : util.colors.green.bold('development')), 'mode');

// Load tasks
var clean       = require('./tasks/clean');
var eslint      = require('./tasks/eslint');
var modernizr   = require('./tasks/modernizr');
var scripts     = require('./tasks/scripts');
var styles      = require('./tasks/styles');
var svgiconsprites = require('./tasks/svgiconsprites');
var svgimagesprites = require('./tasks/svgimagesprites');
var watch       = require('./tasks/watch');

// Define tasks and dependencies
gulp.task('clean:scripts', clean.scripts);
gulp.task('clean:styles', clean.styles);
gulp.task('default', (config.production ? ['modernizr', 'scripts', 'styles', 'svgiconsprites', 'svgimagesprites'] : ['modernizr', 'scripts', 'styles', 'svgiconsprites', 'svgimagesprites', 'watch']));
gulp.task('eslint', eslint);
gulp.task('svgiconsprites', svgiconsprites);
gulp.task('svgimagesprites', svgimagesprites);
gulp.task('modernizr', ['scripts', 'styles'], modernizr);
gulp.task('scripts', ['clean:scripts', 'eslint'], scripts);
gulp.task('styles', ['clean:styles'], styles);
gulp.task('watch', ['modernizr', 'scripts', 'styles'], watch);
