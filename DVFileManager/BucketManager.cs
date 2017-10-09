using System;
using System.Collections;
using System.Diagnostics;

namespace DVFileManager {
    public class BucketManager : IEnumerable, ICloneable {
        private SortedList	_buckets;

        public BucketManager() {
            this._buckets = new SortedList();
        }

        /// <summary>
        /// Return the bucket for this type or null if not found
        /// </summary>
        /// <param name="FileType"></param>
        /// <returns></returns>
        public Bucket FindBucket(string FileType) {
            Bucket	TargetBucket = null;
            string	NormalizedFileType;

            NormalizedFileType = FileType.ToLower();
            TargetBucket = (Bucket) this._buckets[NormalizedFileType];
            return TargetBucket;
        }

        /// <summary>
        /// Return the bucket for this type.  If it is not found, add it.
        /// </summary>
        /// <param name="FileType"></param>
        /// <returns></returns>
        public Bucket FindOrAddBucket(string FileType) {
            Bucket	b;
            string	NormalizedFileType;
			
            b = this.FindBucket(FileType);
            //Add new bucket for new file type
            if (b == null) {
                NormalizedFileType = this.NormalizedFileType(FileType);
                b = new Bucket(NormalizedFileType);
                this._buckets.Add(NormalizedFileType, b);
            }

            return b;
        }

        public void AddFile(string FileType, long FileSize) {
            Bucket b;
            b = this.FindOrAddBucket(FileType);
            ++b.FileCount;
            b.FileSize += FileSize;
        }

        private string NormalizedFileType(string FileType) {
            return FileType.ToLower();
        }

        /// <summary>
        /// Take all the buckets maintained by the SourceManager and add them to our totals.  If we won't have a
        /// particular bucket, it is added.  In this context, we are the Target.
        /// </summary>
        /// <param name="OtherManager"></param>
        public void AddBuckets(BucketManager SourceManager) {
            Bucket	TargetBucket;

            foreach(Bucket SourceBucket in SourceManager) {
                TargetBucket = this.FindOrAddBucket(SourceBucket.FileType);
                TargetBucket.AddOtherBucket(SourceBucket);
            }
        }

        /// <summary>
        /// Set our filters (i.e. the IncludeInTotals flags of our buckets
        /// to match that of the SourceManager.  We expect that our buckets
        /// match (that the SourceManager was probably set from our clone, but
        /// that is not a requirement of calling this method.
        /// </summary>
        /// <param name="SourceManager"></param>
        public void SetFiltersLike(BucketManager SourceManager) {
            Bucket Target;
            foreach(Bucket B in SourceManager) {
                Target = this.FindBucket(B.FileType);
                if (Target != null)
                    Target.IncludedInTotals = B.IncludedInTotals;
            }
        }

        public void Sort() {
            //this._buckets.Sort();
        }


        public Bucket ComputeTotalsBucket() {
            Bucket B;
            Bucket	Totals = new Bucket("");		//The type is not used for a totals buket
            try
            {
                foreach (DictionaryEntry Entry in this._buckets)
                {
                    B = (Bucket)Entry.Value;
                    if (B.IncludedInTotals)
                    {
                        Totals.FileCount += B.FileCount;
                        Totals.FileSize += B.FileSize;
                    }
                }
            }
            catch { }
            return Totals;
        }

        internal void DumpBuckets() {
            Trace.WriteLine("Dump of Buckets");
            Trace.WriteLine("---------------");
            foreach(Bucket B in this._buckets) {
                B.DumpBucket();
            }
        }
        #region IEnumerable Members

        public IEnumerator GetEnumerator() {
            return this._buckets.GetValueList().GetEnumerator();
        }

        #endregion

        #region ICloneable Members

        public object Clone() {
            BucketManager Other = new BucketManager();
            foreach(Bucket B in this) {
                Other._buckets.Add(B.FileType, B.Clone());
            }
            return Other;
        }

        #endregion
    }
}