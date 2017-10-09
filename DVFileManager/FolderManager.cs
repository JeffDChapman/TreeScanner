using System.Collections;

namespace DVFileManager {
    public  class FolderManager : IEnumerable {
        private ArrayList	_subfolders;

        public FolderManager() {
            this._subfolders = new ArrayList();
        }

        public void AddFolder(ScanFolder f) {
            this._subfolders.Add(f);
        }
	
        public void Sort() {
            this._subfolders.Sort();
        }


        public void DumpSubfolderList() {
            foreach(ScanFolder f in this._subfolders)
                f.DumpScanFolderRecurse();
        }
        #region IEnumerable Members

        public IEnumerator GetEnumerator() {
            return this._subfolders.GetEnumerator();
        }

        #endregion
    }
}