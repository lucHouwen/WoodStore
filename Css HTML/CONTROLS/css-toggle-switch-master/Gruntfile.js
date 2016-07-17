'use strict';
var LIVERELOAD_PORT = 35729;
var lrSnippet = require('connect-livereload')({ port: LIVERELOAD_PORT });
var mountFolder = function (connect, dir) {
  return connect.static(require('path').resolve(dir));
};

module.exports = function (grunt) {
  require('matchdep').filterDev('grunt-*').forEach(grunt.loadNpmTasks);
  grunt.loadNpmTasks('assemble');

  grunt.initConfig({
    watch: {
      sass: {
        files: [ '{src,site}/{,*/}*.scss' ],
        tasks: [ 'sass:server' ]
      },
      assemble: {
        files: [ 'site/{,*/}*.{hbs,html}' ],
        tasks: [ 'assemble' ]
      },
      livereload: {
        options: {
          livereload: LIVERELOAD_PORT
        },
        files: [
          './build/*.html',
          './build/{,*/}*.css',
          './dist/*.css'
        ]
      }
    },
    connect: {
      options: {
        port: 9000,
        hostname: '0.0.0.0'
      },
      livereload: {
        options: {
          middleware: function (connect) {
            return [
              lrSnippet,
              mountFolder(connect, './build/'),
              mountFolder(connect, './')
            ];
          }
        }
      },
      dist: {
        options: {
          middleware: function (connect) {
            return [
              mountFolder(connect, './build/')
            ];
          }
        }
      }
    },
    sass: {
      options: {
        sourceMap: true
      },
      server: {
        files: {
          'dist/toggle-switch.css': 'src/toggle-switch.scss',
          'dist/toggle-switch-rem.css': 'src/toggle-switch-rem.scss',
          'dist/toggle-switch-px.css': 'src/toggle-switch-px.scss',
          'build/css/docs.css': 'site/css/docs.scss'
        }
      }
    },
    'saucelabs-qunit': {
      all: {
        options: {
          urls: [ 'http://127.0.0.1:9000/test' ],
          browsers: [
            {
              browserName: 'chrome',
              platform: 'Windows 10'
            }, {
              browserName: 'microsoftedge',
              platform: 'Windows 10'
            }, {
              browserName: 'firefox',
              platform: 'Windows 10'
            }, {
              browserName: 'opera',
              platform: 'Windows 7'
            }, {
              browserName: 'android',
              platform: 'Linux',
              version: '4'
            }, {
              browserName: 'internet explorer',
              platform: 'Windows 7',
              version: '9'
            }, {
              browserName: 'internet explorer',
              platform: 'Windows 8',
              version: '10'
            }, {
              browserName: 'safari',
              platform: 'OS X 10.10',
              version: '8'
            }, {
              browserName: 'iphone',
              deviceName: 'iPhone 4s',
              platform: 'OS X 10.10',
              version: '8.0'
            }
          ]
        }
      }
    },
    qunit: {
      all: {
        options: {
          urls: [
            'http://127.0.0.1:9000/test'
          ]
        }
      }
    },
    assemble: {
      options: {
        layoutdir: 'site/layouts',
        partials: 'site/partials/*.html'
      },
      site: {
        files: [{
          expand: true,
          cwd: 'site',
          src: '{,*/}*.hbs',
          dest: 'build'
        }]
      }
    },
    clean: {
      site: {
        src: [
          'build/',
          'dist/'
        ]
      }
    },
    copy: {
      site: {
        files: [
          {
            src: [
              'bower_components/**',
              'test/**',
              'dist/**'
            ],
            dest: 'build/'
          }
        ]
      }
    },
    buildcontrol: {
      options: {
        dir: 'build',
        commit: true,
        push: true
      },
      site: {
        options: {
          remote: 'git@github.com:ghinda/css-toggle-switch.git',
          branch: 'gh-pages'
        }
      }
    }
  });

  grunt.registerTask('server', function (target) {
    if (target === 'dist') {
      return grunt.task.run(['build', 'connect:dist:keepalive']);
    }

    grunt.task.run([
      'clean',
      'assemble',
      'sass',
      'connect:livereload',
      'watch'
    ]);
  });

  grunt.registerTask('test', [
    'build',
    'connect:dist',
    'saucelabs-qunit'
  ]);

  grunt.registerTask('build', [
    'clean',
    'assemble',
    'sass',
    'copy'
  ]);

  grunt.registerTask('deploy', [
    'test',
    'buildcontrol'
  ]);

  grunt.registerTask('default', [
    'build'
  ]);
};
