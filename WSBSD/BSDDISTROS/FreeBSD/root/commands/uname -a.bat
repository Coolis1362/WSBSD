@echo off
REM Simulating BSD 'uname -a' command in Windows

echo Windows Version:
ver

echo System Info:
wmic os get Caption, Version, BuildNumber
