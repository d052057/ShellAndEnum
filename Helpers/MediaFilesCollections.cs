using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shell32;
namespace ShellAndEnum.Helpers
{
    class MediaMetaData
    {
        public static List<FileMetaData> SingleDir(string folder)
        {
            List<FileMetaData> list = new();
            var thread = new System.Threading.Thread(() =>
            {
              list =  GetFilesSingleDir(folder);
            });
#pragma warning disable CA1416 // Validate platform compatibility
            thread.SetApartmentState(ApartmentState.STA);
#pragma warning restore CA1416 // Validate platform compatibility
            thread.Start();
            thread.Join();

            return list;
        }
        private static List<FileMetaData> GetFilesSingleDir(String folder)
        {
            TimeSpan dur = TimeSpan.Zero;
            Shell shell = new Shell();
            Folder objFolder = shell.NameSpace(folder);
            List<FileMetaData> list = new();
            list.Clear();
            foreach (FolderItem2 item in objFolder.Items())
            {
                if (!item.IsFolder)
                {
                   FileMetaData md = new();
                    dur = TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000);   
                    
                    md.Duration = dur.Duration();
                    md.FullFileName = item.Name;
                    md.FullPath = folder;
                    list.Add(md);
                }
            }
            return list;
        }
    }
}
