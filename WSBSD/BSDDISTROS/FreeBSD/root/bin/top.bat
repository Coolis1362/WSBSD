@echo off
REM Simulating BSD 'top' command in Windows

wmic process get name, workingsetsize, caption, commandline
