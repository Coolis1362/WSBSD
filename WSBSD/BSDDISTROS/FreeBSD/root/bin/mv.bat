@echo off
REM Simulating BSD 'mv' command in Windows

if "%1"=="" (
    echo Usage: mv [source] [destination]
    exit /b 1
)

if exist "%1" (
    move "%1" "%2"
    echo Moved %1 to %2
) else (
    echo Error: %1 does not exist.
    exit /b 1
)
