/**
 * Build system.
 * @module gulpfile
 */
'use strict';

// Module dependencies.
var child=require('child_process');
var del=require('del');
var fs=require('fs');
var gulp=require('gulp');
var path=require('path');
var plugins=require('gulp-load-plugins')();
var pkg=require('./package.json');
var util=require('util');

/**
 * Provides tasks for [Gulp.js](http://gulpjs.com) build system.
 * @class cli.Gulpfile
 * @static
 */
process.chdir(__dirname);

/**
 * Runs the default tasks.
 * @method default
 */
gulp.task('default', function(callback) {
  console.log('Please specify a target. Available targets:');

  for(var task in gulp.tasks) {
    if(task!='default' && task.indexOf(':')<0) console.log('  '+task);
  }

  callback();
});

/**
 * Checks the package dependencies.
 * @method check
 */
gulp.task('check', function(callback) {
  child.exec('david', function(err, stdout) {
    console.log(stdout.trim());
    callback();
  });
});

/**
 * Deletes all generated files and reset any saved state.
 * @method clean
 */
gulp.task('clean', function(callback) {
  var items=[
    'src/**/obj',
    'var/debug',
    'var/release',
    util.format('var/%s-%s.exe', pkg.yuidoc.name.toLowerCase(), pkg.version)
  ];
  
  del(items, callback);
});

/**
 * Creates a distribution file for this program.
 * @method dist
 */
gulp.task('dist', [ 'dist:setup' ]);

gulp.task('dist:program', function(callback) {
  var builder='MSBuild/12.0/Bin/MSBuild.exe';
  var executable=path.join(process.env.ProgramFiles, builder);
  fs.exists(executable, function(exists) {
    if(!exists && ('ProgramFiles(x86)' in process.env)) executable=path.join(process.env['ProgramFiles(x86)'], builder);
    child.exec(util.format('"%s" /nologo /property:Configuration=Release /verbosity:minimal', executable), callback);
  });
});

gulp.task('dist:setup', [ 'dist:program' ], function(callback) {
  var builder='Inno Setup/ISCC.exe';
  var executable=path.join(process.env.ProgramFiles, builder);
  fs.exists(executable, function(exists) {
    if(!exists && ('ProgramFiles(x86)' in process.env)) executable=path.join(process.env['ProgramFiles(x86)'], builder);
    child.exec(util.format('"%s" /qp setup.iss', executable), callback);
  });
});

/**
 * Builds the documentation.
 * @method doc
 */
gulp.task('doc', [ 'doc:assets' ], function(callback) {
  child.exec('docgen', function(err, stdout) {
    console.log(stdout.trim());
    callback();
  });
});

gulp.task('doc:assets', function() {
  return gulp.src([ 'www/apple-touch-icon.png', 'www/favicon.ico' ])
    .pipe(gulp.dest('doc/api/assets'));
});

/**
 * Performs static analysis of source code.
 * @method lint
 */
gulp.task('lint', [ 'lint:doc', 'lint:js' ]);

gulp.task('lint:doc', function(callback) {
  child.exec('docgen --lint', function(err, stdout) {
    console.log(stdout.trim());
    callback();
  });
});

gulp.task('lint:js', function() {
  return gulp.src('*.js')
    .pipe(plugins.jshint(pkg.jshintConfig))
    .pipe(plugins.jshint.reporter('default', { verbose: true }));
});
