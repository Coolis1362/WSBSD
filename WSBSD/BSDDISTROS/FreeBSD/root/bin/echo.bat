@echo off
REM Simulating BSD 'echo' command in Windows

if "%1"=="" (
    echo Usage: echo [text]
    exit /b 1
)

echo %*
