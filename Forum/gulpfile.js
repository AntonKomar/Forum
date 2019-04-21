let path = require('path');
let gulp = require('gulp');
let plumber = require('gulp-plumber');
let msbuild = require("gulp-msbuild");
let iisexpress = require('gulp-serve-iis-express');
let browserSync = require('browser-sync').create();
var sass = require('gulp-sass');

let PORT = '62896';
let sources = [
    'Controllers/*.cs',
    'Helpers/*.cs',
    'ViewModels/**/*.cs'
];
let views = [
    'Views/**/*.cshtml',
];
let source_sass = [
    'Content/scss/*.scss',
];

gulp.task('default', ['server', 'build','sass'], function () {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['build']);
    gulp.watch(source_sass, ['sass']);
    return gulp.watch(views, ['reload']);
});

gulp.task('sass', function () {
    gulp.src(source_sass)
        .pipe(sass())
        .pipe(gulp.dest('./Content'))
        .pipe(browserSync.stream());
});

gulp.task('reload', function () {
    browserSync.reload();
});

gulp.task('build', function () {
    return gulp.src("../Forum.sln")
        .pipe(plumber())
        .pipe(msbuild({
            toolsVersion: 'auto',
            logCommand: true
        }))
        .pipe(browserSync.stream());
});

gulp.task('server', function () {
    let configPath = path.join(__dirname, '..\\.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['Forum'],
        configFile: configPath,
        port: PORT
    });
});

