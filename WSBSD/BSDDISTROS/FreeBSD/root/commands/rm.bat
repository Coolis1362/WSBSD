@echo off
REM Simulating BSD 'rm' command in Windows

if "%1"=="" (
    echo Usage: rm [file or directory]
    exit /b 1
)

if exist "%1" (
    if exist "%1\*" (
        rmdir /s /q "%1"
        echo Directory removed: %1
    ) else (
        del /q "%1"
        echo File removed: %1
    )
) else (
    echo Error: %1 does not exist.
    exit /b 1
)
