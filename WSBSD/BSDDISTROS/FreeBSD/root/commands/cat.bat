@echo off
REM Simulating BSD 'cat' command in Windows

if "%1"=="" (
    echo Usage: cat [file]
    exit /b 1
)

if exist "%1" (
    type "%1"
) else (
    echo Error: %1 does not exist.
    exit /b 1
)
