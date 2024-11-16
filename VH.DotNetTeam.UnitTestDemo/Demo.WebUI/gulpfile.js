/// <binding BeforeBuild='compile-less' />
const gulp = require('gulp');
const less = require('gulp-less');
const path = require('path');

// Task to compile Less files to CSS
gulp.task('compile-less', () => {
    return gulp.src('wwwroot/less/styles.less') // Replace with your Less file path
        .pipe(less({
            paths: [path.join(__dirname, 'less', 'includes')]
        }))
        .pipe(gulp.dest('wwwroot/css/')); // Output CSS to the same directory
});

// Watch LESS files for changes
gulp.task('watch-less', function () {
    gulp.watch('wwwroot/less/**/*.less', gulp.series('compile-less'));
});
