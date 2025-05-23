@echo off
REM Simulating FreeBSD 'ls' command in Windows

if "%1"=="" (
    dir /b
) else (
    dir /b "%1"
)
