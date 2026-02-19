# PasswordStrengthFinder
This is a tool built in C# to quickly calculate whether a password is strong or not.
## Using the program
Download the program from the releases tab here on github.

To use, run the .exe file and a console window will open. Make your choice to check a password or add/remove a word from the banned word list.

### Limitations
This program will not persistently save the banned word list. As such, if a banned list is used, it will only be useful when the full banned list is added, and will be less useful when it is not.

### Future concerns
This program does not connect to the internet. With any password checker, it is important to not allow internet access as it could result in passwords getting stolen.

### Credit
This program utilizes  [zxcvbn-core](https://github.com/trichards57/zxcvbn-cs/tree/master) to analyze passwords efficiently.