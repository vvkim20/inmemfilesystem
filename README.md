# Requirements
Dotnet Core 5.0

# Prompts
- make file FILE_NAME
- write file FILENAME CONTENTS => FileName : FILENAME \r\n Content: CONTENTS
- make directory DIRECTORY_NAME
- move file FILE_NAME TARGET_DIRECTORY_NAME
- change directory to DIRECTORY_NAME
- change directory to parent
- delete driectory DIRECTORY_NAME
- get working directory contents
- get working directory

# Example
```
PS C:\inmemfilesystem\src\FileSystem\ConsoleApp> dotnet run
> make file homework_1
> write file homework_1 asdkfjlaksjdflkajsdflkjakdsflkjsadf
> read file homework_1
>> FileName: homework_1
 Content: asdkfjlaksjdflkajsdflkjakdsflkjsadf
> make directory math
> make directory lunch
> make directory history
> make directory spanish
> delete directory lunch
> get working directory contents
>> homework_1, math, history, spanish
> get working directory
/
> change directory to homework
>> homework directory doesn't exist
> make directory school
> change directory to school
> get working directory
/school
> get working directory contents
>> homework_1, math, history, spanish, school
> get working directory contents
>> homework_1, math, history, spanish, school
> change directory to math
> make file homework_1
> change directory to parent
> move file homework_1 math
> change directory to math
> get working directory contents
>> homework_1, homework_1_copy
>
```


# Todo
Add unit tests
