@echo off
REM Simulating BSD 'kill' command in Windows

if "%1"=="" (
    echo Usage: kill [PID]
    exit /b 1
)

taskkill /F /PID %1
echo Process %1 terminated.
