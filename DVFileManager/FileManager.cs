namespace DVFileManager {

	public delegate void FolderVisitor(ScanFolder f);
	public delegate void FolderVisitor2(ScanFolder f, object o);
	public delegate void MsgCallback(string Msg);

	public enum CompareType { BySize, ByCount };

    //TODO: All the methods taking a FolderVisitor have not been tested
}
