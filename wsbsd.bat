if "%1"=="--start--FreeBSD"(
    echo Starting WSBSD FreeBSD...
    WSBSD FreeBSD Default (14.2).exe
)
else (
    echo ARGUMENT ERROR: %1
    echo Usage: wsbsd.bat --start--FreeBSD
    echo PLEASE USE A VALID ARGUMENT NEXT TIME.
)