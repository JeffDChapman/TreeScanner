using System;
using System.Diagnostics;
using KayeScholer.DiskView.DVFileManager;

namespace DVFileManager {
    public class Bucket : IComparable, ICloneable {
        public string	FileType;
        public long		FileCount;
        public long		FileSize;
        public bool		IncludedInTotals;

        public Bucket(string FileType) {
            this.FileType = FileType.ToLower();
            this.FileCount = 0;
            this.FileSize = 0;
            this.IncludedInTotals = true;		//Include in FOLDER totals (not type totals)
        }

        public override string ToString() {
            return FileType;
        }

        public void AddOtherBucket(Bucket OtherBucket) {
            if (!OtherBucket.FileType.Equals(this.FileType))
                throw new ApplicationException(string.Format("Cannot add bucket for type {0} into one for type {1}", OtherBucket.FileType, this.FileType));

            this.FileCount += OtherBucket.FileCount;
            this.FileSize += OtherBucket.FileSize;
        }
        public void DumpBucket() {
            Trace.WriteLine(string.Format("{0,10}: {1,20:#,##0} {2,20:#,##0} {3}", FileType, FileCount, FileSize, this.IncludedInTotals));
        }
        #region IComparable Members

        public int CompareTo(object obj) {
            if (!(obj is Bucket))
                throw new ApplicationException("Buckets can only compare to other buckets.");

            Bucket Other = (Bucket) obj;

            //Remember that we want a DESCENDING sort
            if (Traverser.GlobalCompareType == CompareType.BySize) {
                if (this.FileSize > Other.FileSize)
                    return -1;
                else if (this.FileSize < Other.FileSize)
                    return 1;
                else
                    return 0;
            }
            else if (Traverser.GlobalCompareType == CompareType.ByCount) {
                if (this.FileCount > Other.FileCount)
                    return -1;
                else if (this.FileCount < Other.FileCount)
                    return 1;
                else
                    return 0;
            }
            else
                return 0;
        }

        #endregion

        #region ICloneable Members

        public object Clone() {
            Bucket	Other = new Bucket(this.FileType);
            Other.FileCount = this.FileCount;
            Other.FileSize = this.FileSize;
            Other.IncludedInTotals = this.IncludedInTotals;

            return Other;
        }

        #endregion
    }
}