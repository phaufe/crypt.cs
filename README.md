# Crypt.cs
![Screenshot](https://github.com/cedx/crypt.cs/raw/gh-pages/screenshot.png)

Simple string encoder (Base64, CRC32, DES, MD, SHA...), implemented in [C#](https://www.microsoft.com/net).  
This program uses the [MiniFramework.cs](https://github.com/cedx/miniframework.cs) library.

## Command Line Interface
In addition to the graphical user interface, you can also use the application from the command prompt:

    $ ./crypt.console.exe -h
    
    Encode a message by applying a hash algorithm.
    
    Usage: crypt.console <algorithm> <message>
    
    Options:
    -?, -h, --help             Show this help.
    -l, --list                 Show the supported hash algorithms.
    -v, --version              Show the program version.

## Documentation
* [API Reference](http://cedx.github.io/crypt.cs/api)

## License
[Crypt.cs](https://github.com/cedx/crypt.cs) is distributed under the MIT License.