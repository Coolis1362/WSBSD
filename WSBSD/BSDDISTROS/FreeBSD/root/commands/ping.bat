@echo off
REM Simulating BSD 'ping' command in Windows

if "%1"=="" (
    echo Usage: ping [hostname or IP]
    exit /b 1
)

ping -n 4 "%1"
