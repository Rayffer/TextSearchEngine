# TextSearchEngine
A tool to search text inside the files of any directory

### Usage 

To call this program from the command line, navigate to the directory in which the executable is present and call it with a parameter that specifies the directory over which to perform any text searchs.

`%PathToExecutable%\\TextSearchEngine.exe %PathToPerformSearchsIn%`

Mind that if you specify a path that does not exists, the program will not work.

Once you have specified a valid path for the executable, the program will ask for a search term, you can fill in any word you want and then press enter to start the search. In case no search term is specified, it will ask again for a search term. An example of the previous usage is shown in the next image:

![alt text](https://github.com/Rayffer/TextSearchEngine/blob/master/ReadmeResources/NormalOperationExample.png)

Once you're done searching in the specified directory, writing `$end` as a search term will signal the engine that we want to stop searching and the program will exit. An example of the previous command is shown in the next image:

![alt text](https://github.com/Rayffer/TextSearchEngine/blob/master/ReadmeResources/ExitOperationExample.png)
