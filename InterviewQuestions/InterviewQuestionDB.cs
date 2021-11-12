//using System;

//// To execute C#, please define "static void Main" on a class
//// named Solution.

//class Solution
//{
//    /* Dictionary<string, List<string>>
//        1. Got a root 
//            0. Init valriables 
//                1. List<strings> directoryPaths
//            1. Get the contents -> List<string> paths
//                1. For each  entry/path
//                    if its !(is_dir(path)
//                    {
//                        var hashedKey =  hash_content(File.ReadAllText(file))
//                    }
//                2. else 
//                {
//                    directoryPaths.Add(path)
//                }
//            2. While directoryPaths.Length >0 
//                1. Repeat the step # 1 ;
//         3.  
//        Key -> content,  List<FilePaths>
//        Unique files => List<Filepaths>.Count == 1 
//    */
//    static void Main(string[] args)
//    {
//        for (var i = 0; i < 5; i++)
//        {
//            Console.WriteLine("Hello, World");
//        }
//    }

//    int chunkSize = 100;

//    public static List<List<string>> GenerateDuplicateFileReport(string root)
//    {
//        var directoryPaths = new List<string> { root };
//        var dictionary = new Dictionary<string, List<string>>();
//        while (directoryPaths.Count > 0)
//        {
//            var paths = list_dir(is_Simlink(directoryPaths.First()));
//            var parent = is_Simlink(directoryPaths.First();
//            foreach (var path in paths)
//            {
//                if (!(is_dir(path))
//                {
//                    var fullPath = Path.Combine(parent, path);
//                    var hashedKey = hash_Content(File.Read(fullPath, chunkSize));
//                    if (dictionary.ContainsKey(hashedKey))
//                    {
//                        if (File.ReadAllText(filePath).Length != File.ReadAllText(fullPath).Length)
//                        {

//                            dictionary.Add(hash_Content(hashedKey), new List<string> { fullPath });
//                        }
//                        else
//                        {

//                            foreach (var filePath in dictionary[hashedKey])
//                            {
//                                if (isItSameFile(filePath, fullPath)) ;
//                                {
//                                    dictionary[hashedKey] = fullPath;
//                                }else
//                                {
//                                    dictionary.Add(hash_Content(hashedKey), new List<string> { fullPath });
//                                }
//                            }
//                        }

//                    }
//                    else
//                    {
//                        dictionary.Add(hashedKey, new List<string> { fullPath });
//                    }
//                }
//                else
//                {
//                    directoryPaths.Add(fullPath);
//                }
//            }

//            directoryPaths.RemoveAt(0);
//        }

//        var result = new List<< list < String >> ();
//        foreach (var entry in dictionary)
//        {
//            if (entry.Value.Count > 1)
//            {
//                result.Add(entry.Value); // 
//            }
//        }

//        return result;
//    }
//}

///*
// readNchunk, hashit 
// and comapre 
// */

//public bool isItSameFile(string path1, string path2)
//{
//    int chunkNo = 1;

//    while ((chunkNo++) * chunkSize <= File.ReadAllText(path1).Length)
//    {
//        var conent1 = Hash_Content(File.ReadAllText(path1, chunkNo * chunkSize, chunkSize));
//        var conent2 = Hash_Content(File.ReadAllText(path2, chunkNo * chunkSize, chunkSize));

//        if (conent1 != content2)
//        {
//            return false;
//        }
//    }

//    return true;
//}



///* 
//Your previous Python 2 content is preserved below:

//def is_Simlink(path:str): str // real absolute path 


//# If you are familiar with os.listdir, os.path.isdir and os.path.join, feel free to use those.
//# If not, you can assume that the following methods have been implemented.
//def list_dir(path: str) -> List[str]:
//    """
//    Returns a non-recursive list of entries (files and folders) with relative
//    paths in this directory only. Basically the same functionality as doing "ls"
//    or "dir" in a shell
//    """
//    pass


//def is_dir(path: str) -> bool:
//    """
//    Returns True if the given path corresponds to a directory.
//    """
//    pass


//def join_path(path: str, subpath: str) -> str:
//    """
//    Returns a path formed by combining the given path and the given subpath.
//    """
//    pass

//def hash_content(content:str)-> str:
//"""
//Imagine I’m on my personal computer, and I have been copying a bunch of files around and making edits to them (eg. “presentation.pptx”, “final_presentation.pptx”, “final_for_realz_presentation.pptx”, etc.). I’m running low on hard drive space, but I know that I have a bunch of duplicate files lying around.

//- /foo
//  - /images
//    - /foo.png  <------.
//  - /temp              | same file contents
//    - /baz             |
//      - /that.foo  <---|--.
//  - /bar.png  <--------'  |
//  - /file.tmp  <----------+-- same file contents
//  - /blah.txt  <----------|-- unique file contents
//  - /other.temp  <--------'

//[
//     ['/foo/bar.png', '/foo/images/foo.png'],
//     ['/foo/file.tmp', '/foo/other.temp', '/foo/temp/baz/that.foo']
//]
//"""

//----
//def find_duplicates(root_path: str) -> List[List[str]]:
//    raise NotImplementedError
//```
// */