@echo off
REM Simulating BSD 'cp' command in Windows

if "%1"=="" (
    echo Usage: cp [source] [destination]
    exit /b 1
)

if exist "%1" (
    if exist "%1\*" (
        xcopy /E /I "%1" "%2"
        echo Directory copied: %1 to %2
    ) else (
        copy "%1" "%2"
        echo File copied: %1 to %2
    )
) else (
    echo Error: %1 does not exist.
    exit /b 1
)
