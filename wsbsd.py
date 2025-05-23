import sys
import os

# Get arguments from the command line
args1 = sys.argv[1:]  # Excludes the script name
args2 = sys.argv[2:]  # Includes the script name

if args1 == "--start" and args2 == "--FreeBSD":
    print("Starting FreeBSD...")
    os.system("C:\\WSBSD\\FreeBSD\\root\\wsbsdfreebsd.exe")