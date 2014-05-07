# Crypt.cs
![Screenshot](http://dev.belin.io/crypt.cs/raw/master/doc/screenshot.png)

Simple string encoder (Base64, CRC32, DES, MD, SHA...), implemented in [C#](https://www.microsoft.com/net).  
This program uses the [MiniFramework.cs](http://dev.belin.io/miniframework.cs) library.

## Command Line Interface
In addition to the graphical user interface, you can also use the application from the command prompt:

    > .\crypt.console.exe -h
    
    Encode a message by applying a hash algorithm.
    
    Usage: crypt.console <algorithm> <message>
    
    Options:
    -?, -h, --help             Show this help.
    -l, --list                 Show the supported hash algorithms.
    -v, --version              Show the program version.

## Documentation
* [API Reference](http://api.belin.io/crypt.cs)

## License
[Crypt.cs](http://dev.belin.io/crypt.cs) is distributed under the MIT License.