#!/usr/bin/env node
/* global cd, config, cp, echo, env, exec, rm, target, test */

/**
 * Build system.
 * @module bin.make
 */
'use strict';

// Module dependencies.
require('shelljs/make');
var archiver=require('archiver');
var fs=require('fs');
var path=require('path');
var pkg=require('../package.json');
var util=require('util');

/**
 * Provides tasks for [ShellJS](http://shelljs.org) make tool.
 * @class cli.Makefile
 * @static
 */
cd(__dirname+'/..');

/**
 * The application settings.
 * @property config
 * @type Object
 */
config.fatal=true;
config.output=util.format('var/%s-%s', pkg.yuidoc.name.toLowerCase(), pkg.version);

/**
 * Runs the default tasks.
 * @method all
 */
target.all=function() {
  echo('Please specify a target. Available targets:');
  for(var task in target) {
    if(task!='all') echo(' ', task);
  }
};

/**
 * Deletes all generated files and reset any saved state.
 * @method clean
 */
target.clean=function() {
  echo('Delete the output files...');

  rm('-rf', 'src/crypt.console/obj');
  rm('-rf', 'src/crypt.core/obj');
  rm('-rf', 'src/crypt.encoders/obj');
  rm('-rf', 'src/crypt.windows/obj');
  rm('-rf', 'var/debug');
  rm('-rf', 'var/release');
  rm('-f', config.output+'.exe');
  rm('-f', config.output+'.zip');
};

/**
 * Creates a distribution file for this program. 
 * @method dist
 */
target.dist=function() {
  echo('Build the redistributable...');

  var builders=[
    {
      binary: 'MSBuild/12.0/Bin/MSBuild.exe',
      command: '"%s" /maxcpucount /property:Configuration=Release'
    },
    {
      binary: 'Inno Setup/ISCC.exe',
      command: '"%s" setup.iss'
    }
  ];
  
  builders.forEach(function(builder) {
    var executable=path.join(env.ProgramFiles, builder.binary);
    if(!test('-f', executable) && ('ProgramFiles(x86)' in env)) executable=path.join(env['ProgramFiles(x86)'], builder.binary);
    exec(util.format(builder.command, executable));
  });

  var archive=archiver('zip');
  archive.on('entry', function(entry) { echo('Pack:', entry.name); });
  archive.pipe(fs.createWriteStream(config.output+'.zip'));
  archive.bulk({ cwd: 'var/release', expand: true, src: '**/*' }).finalize();
};

/**
 * Builds the documentation.
 * @method doc
 */
target.doc=function() {
  echo('Build the documentation...');
  exec('docgen');
  cp('-f', [ 'www/apple-touch-icon.png', 'www/favicon.ico' ], 'doc/api/assets');
};

/**
 * Performs static analysis of source code.
 * @method lint
 */
target.lint=function() {
  config.fatal=false;

  echo('Static analysis of JavaScript sources...');
  exec('jshint --verbose bin');

  echo('Static analysis of documentation comments...');
  exec('docgen --lint');

  config.fatal=true;
};
