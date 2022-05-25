using System;
namespace ShellAndEnum
{
    public class FileMetaData
    {
        public FileMetaData()
        {
            FullPath = string.Empty;
            FullFileName = string.Empty;
            Duration = TimeSpan.Zero;
        }
        public string FullPath { get; set; }
        public string FullFileName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
