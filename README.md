# InMemoryFile

# Requirements
Dotnet Core 5.0


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
> change directory to homework
>> homework directory doesn't exist
> get working directory contents
>> homework_1, math, history, spanish, school
> change directory math
>> Invalid command
> change directory tp math
>> Invalid command
> change directory to math
> make file homework_1
> change directory to parent
> move file homework_1 math
> change directory to math
> get working directory contents
>> homework_1, homework_1_copy
>
```


#Todo
Add unit tests