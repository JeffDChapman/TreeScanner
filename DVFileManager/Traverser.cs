using System.IO;
using DVFileManager;

namespace KayeScholer.DiskView.DVFileManager {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Traverser {

        static private CompareType	g_CompareType	= CompareType.BySize;
        //Allow a global change from sorting by size and sorting by count

        public static CompareType GlobalCompareType {
            get {	return g_CompareType; }
            set {	g_CompareType = value; }
        }

        private static MsgCallback		_msgCallback;

        public static void SetMessageCallback(MsgCallback Callback) {
            Traverser._msgCallback = Callback;
        }

        public static void Message(string Msg) {
            if (Traverser._msgCallback != null)
                Traverser._msgCallback(Msg);
        }

        ScanFolder		_rootFolder = null;

        public ScanFolder RootFolder { get { return this._rootFolder; }}

        public Traverser(string RootFolderPath) {
            DirectoryInfo	RootInfo;

            RootInfo = new DirectoryInfo(RootFolderPath);
            this._rootFolder = new ScanFolder(RootInfo);
        }


        public void Scan() {
            this._rootFolder.Scan();
        }

        public void DumpFolders() {
            this._rootFolder.DumpScanFolder();
        }

        public void SetFiltersLike(BucketManager BMgr) {
            this.RootFolder.Visit2(new FolderVisitor2(this.SetFiltersForFolderLike), BMgr);
        }

        public void ResortFolders() {
            this.RootFolder.Visit(new FolderVisitor(SortFolder));
        }

        //This is a node visitor.  It is called once for each folder.
        private void SetFiltersForFolderLike(ScanFolder f, object BMgr) {
            BucketManager Mgr = (BucketManager) BMgr;
            f.BucketMgr.SetFiltersLike(Mgr);
        }


        //This is a node visitor.  It is called once for each folder.
        private void SortFolder(ScanFolder f) {
            f.SubfolderMgr.Sort();			
        }
    }
}