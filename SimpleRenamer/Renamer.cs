using System;
using System.IO;

namespace SimpleRenamer
{
    class Renamer
    {
        public void Execute(string path)
        {
            AnalyzeResult analyzeResult = AnalyzePath(path);
            string prefix = GetPrefix(path);

            if (analyzeResult.Exists && analyzeResult.IsFile)
            {
                File.Move(path, GetNewFilePath(analyzeResult, prefix));
            }
            else if (analyzeResult.Exists)
            {
                Directory.Move(path, GetNewDirectoryPath(analyzeResult, prefix));
            }
        }

        private AnalyzeResult AnalyzePath(string path)
        {
            AnalyzeResult result = new AnalyzeResult(path);

            if (File.Exists(path))
            {
                result.Exists = true;
                result.IsFile = true;
                result.ParentDicrectory = Path.GetDirectoryName(path);
                result.SimpleName = Path.GetFileNameWithoutExtension(path);
                result.Extension = Path.GetExtension(path);
            }
            else if (Directory.Exists(path))
            {
                result.Exists = true;
                result.IsFile = false;
                result.ParentDicrectory = Path.GetDirectoryName(path);
                result.SimpleName = Path.GetFileNameWithoutExtension(path);
            }

            return result;
        }

        private string GetNewFilePath(AnalyzeResult data, string prefix)
        {
            string newPath = null;
            int ct = 0;

            do
            {
                newPath = data.ParentDicrectory + Path.DirectorySeparatorChar
                + prefix + data.SimpleName + GetSuffix(ct) + data.Extension;
                ct++;
            } while (File.Exists(newPath));

            return newPath;
        }

        private string GetNewDirectoryPath(AnalyzeResult data, string prefix)
        {
            string newPath = null;
            int ct = 0;

            do
            {
                newPath = data.ParentDicrectory + Path.DirectorySeparatorChar
                + prefix + data.SimpleName + GetSuffix(ct);
                ct++;
            } while (Directory.Exists(newPath));

            return newPath;
        }

        private string GetPrefix(string path)
        {
            FileInfo info = new FileInfo(path);
            return info.CreationTime.ToString("yyyyMMdd") + "_";
        }

        private string GetSuffix(int ct)
        {
            if (ct == 0)
            {
                return string.Empty;
            }
            return "_" + ct.ToString();
        }
    }
}
