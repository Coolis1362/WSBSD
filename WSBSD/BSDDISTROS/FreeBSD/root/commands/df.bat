@echo off
REM Simulating BSD 'df' command in Windows

wmic logicaldisk get caption, size, freespace
