'use strict';

var config    = require('../config');
var gulp = require('gulp');
var path = require('path');
var svgmin = require('gulp-svgmin');
var svgstore = require('gulp-svgstore');
var cheerio = require('gulp-cheerio');
var join = require('path').join;

module.exports = function() {
    return gulp
          .src('src/svg/svg-icons/*.svg')
          .pipe(svgmin(function (file) {
              var prefix = path.basename(file.relative, path.extname(file.relative));
              return {
                  plugins: [{
                      cleanupIDs: {
                          prefix: prefix + '-',
                          minify: true
                      }
                  }]
              }
          }))
          .pipe(cheerio({
              run: function ($) {
                  $('[fill]').removeAttr('fill');
              },
              parserOptions: { xmlMode: true }
          }))
          .pipe(svgstore())
          .pipe(gulp.dest('images'));
};