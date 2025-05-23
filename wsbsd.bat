if "%1"=="--start--FreeBSD"(
    echo Starting WSBSD FreeBSD...
    "C:\\WSLBSD\\FreeBSD\\14.2 (Default)\\root\\WSBSD FreeBSD 14.2 Default (14.2).exe"
)
else if "%1"=="--version"(
    echo WSBSD Kernel Version 1.0.0.1
)
else (
    echo ARGUMENT ERROR: %1
    echo Usage: wsbsd.bat --start--FreeBSD
    echo PLEASE USE A VALID ARGUMENT NEXT TIME.
)