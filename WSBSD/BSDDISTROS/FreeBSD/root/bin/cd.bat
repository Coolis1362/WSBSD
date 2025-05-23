@echo off
REM Simulating BSD 'cd' command in Windows

if "%1"=="" (
    echo Current Directory: %CD%
) else (
    cd /d "%1"
    echo Changed directory to: %CD%
)
