# Terminal PowerShell

## Main Idea in One Sentence

Working with the command line, without a graphical interface. It is fast and helps automate some processes. It also gives accuracy when working with files.

## What I Learned

1. Basic syntax and an initial understanding of how "requests" work. Verb - Noun is a convenient logic, because this way you can intuitively understand what request you can give to the command line.

2. Main commands that I practiced:

   * pwd - where I am right now
   * cd "folder_name" - go to a folder
   * dir - output a list of folders and files
   * mkdir - create a folder
   * ni - create a file
   * rm - delete a file
   * rm -Recurse "folder_name" - delete the whole folder because of recursion
   * cat "file_name" - output the content of a file
   * cp "file_name" "folder_name" - copy a file to a folder
   * mv "file_name" "folder_name" - move a file to a folder
   * mv "file_name" "new_file_name" - rename a file/folder

3. Aliases — the concept that ls, cd, cat are not the real names of commands, but synonyms for Get-ChildItem, Set-Location, Get-Content.

4. Pipeline | — this is a way to connect commands. The result of one command is passed as the input to the next one. In PowerShell, the pipeline passes objects, not text strings — this is its special feature compared to the regular cmd.

5. The difference between "|" and ";".

   * "|" - this is a pipeline, one single command in one line.
   * ";" - this symbol means the end of a command. So, if you write command1; command2; it will not be a pipeline, but 2 different commands.

6. Recursion — "doing the same thing inside what was just found." In files: apply an operation to a folder, then to every folder inside it, and so on.

## "Aha Moments"

Convenience of use. In practice, after learning the basic functions, it became much more convenient to understand working with the command line, because it feels like full "control" over the computer and the files inside it. Now I want to work only through the command line, because I can perform operations without limitations, delete something from the computer, or quickly create or find something.

## What I Still Do Not Fully Understand

A huge gap in the pipeline and in the additional options that the command line provides. I see and understand that the pipeline is very useful, but I have not yet learned how to use it 100%, or even 50%.

## Useful for the Future

* ls -Force        # show hidden files too
* ls -Recurse      # show everything inside, recursively
* ls *.cs          # show only files with the .cs extension
* ls -File         # only files
* ls -Directory    # only folders
