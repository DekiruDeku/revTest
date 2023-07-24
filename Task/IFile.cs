using System.Threading.Tasks;

namespace TestTask.Task
{
    public interface IFile
    {
        Task<byte[]> ReadFileInBytes(string Path);
        
        void MakeOrUpdateBytesInFile(byte[] subsequence, string Path);
    }
}