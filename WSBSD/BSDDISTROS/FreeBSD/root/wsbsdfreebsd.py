import os
import sys
import time

def freebsd_prompt():
    user = os.environ.get("USER", "FreeBSD")
    cwd = os.getcwd()
    return f"[{user}@WSBSDFreeBSD {cwd}]{'#' if user == 'root' else '$'} "

while True:
    command = input(freebsd_prompt())
    if command.lower() == "exit":
        break
    os.system(f"C:\\WSBSD\\FreeBSD\\bin\\{command}.bat")