namespace SimpleRenamer
{
    class AnalyzeResult
    {
        public AnalyzeResult(string path)
        {
            OrignalPath = path;
            Exists = false;
        }

        public bool Exists { get; set; }

        public bool IsFile { get; set; }

        public string OrignalPath { get; set; }

        public string ParentDicrectory { get; set; }

        public string SimpleName { get; set; }

        public string Extension { get; set; }
    }
}
