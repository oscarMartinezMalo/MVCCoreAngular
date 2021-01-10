/// <binding AfterBuild='default' />
var gulp = require("gulp");
var uglify = require("gulp-uglify");
var concat = require("gulp-concat");
var gnf = require("gulp-npm-files");

gulp.task('minify', function () {
    return gulp.src('wwwroot/js/**/*.js')
        .pipe(uglify())
        .pipe(concat('mvccoreangular.min.js'))
        .pipe(gulp.dest('wwwroot/dist'));
});

//gulp.task('copynpm', function (done) {
//    gulp.src(gnf(), { base: "./" }).pipe(gulp.dest("wwwroot"));
//    done();
//});


gulp.task('default', gulp.series('minify'));