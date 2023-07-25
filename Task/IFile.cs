using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Task
{
    public interface IFile
    {
        Task<Stack<byte>> ReadFileInBytes(string Path);
        
        void MakeOrUpdateBytesInFile(Stack<byte> subsequence, string Path);
    }
}