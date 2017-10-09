using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DVFileManager;
using KayeScholer.DiskView.DVFileManager;

namespace DiskViewPlus
{
	/// <summary>
	/// Summary description for FrmFilter.
	/// </summary>
	public class FrmFilter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckedListBox CtlFileTypeList;
		private System.Windows.Forms.Button CtlBtnOK;
		private System.Windows.Forms.Button CtlBtnCancel;
		private System.Windows.Forms.Button CtlBtnDeselectAll;
		private System.Windows.Forms.Button CtlBtnSelectAll;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private BucketManager	_bucketMgr;
		private bool			_suppressCheckedEvent = false;

		public BucketManager	BucketMgr { get { return this._bucketMgr; }}

		public FrmFilter(BucketManager TopBucketManager)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Initialize our bucket manager with a clone of the one passed to us.
			//That way if he cancels, we have not touched the callers.  The
			//caller should use our BucketMgr property to obtain the filtered
			//buckets should we set our DialogResult to OK.

			this._bucketMgr = (BucketManager) TopBucketManager.Clone();
			FillListBox();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CtlFileTypeList = new System.Windows.Forms.CheckedListBox();
			this.CtlBtnOK = new System.Windows.Forms.Button();
			this.CtlBtnCancel = new System.Windows.Forms.Button();
			this.CtlBtnDeselectAll = new System.Windows.Forms.Button();
			this.CtlBtnSelectAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CtlFileTypeList
			// 
			this.CtlFileTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.CtlFileTypeList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CtlFileTypeList.Location = new System.Drawing.Point(24, 24);
			this.CtlFileTypeList.MultiColumn = true;
			this.CtlFileTypeList.Name = "CtlFileTypeList";
			this.CtlFileTypeList.Size = new System.Drawing.Size(576, 361);
			this.CtlFileTypeList.Sorted = true;
			this.CtlFileTypeList.TabIndex = 0;
			this.CtlFileTypeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CtlFileTypeList_ItemCheck);
			// 
			// CtlBtnOK
			// 
			this.CtlBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CtlBtnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CtlBtnOK.Location = new System.Drawing.Point(68, 408);
			this.CtlBtnOK.Name = "CtlBtnOK";
			this.CtlBtnOK.Size = new System.Drawing.Size(124, 23);
			this.CtlBtnOK.TabIndex = 1;
			this.CtlBtnOK.Text = "&OK";
			this.CtlBtnOK.Click += new System.EventHandler(this.CtlBtnOK_Click);
			// 
			// CtlBtnCancel
			// 
			this.CtlBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CtlBtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CtlBtnCancel.Location = new System.Drawing.Point(192, 408);
			this.CtlBtnCancel.Name = "CtlBtnCancel";
			this.CtlBtnCancel.Size = new System.Drawing.Size(124, 23);
			this.CtlBtnCancel.TabIndex = 2;
			this.CtlBtnCancel.Text = "&Cancel";
			this.CtlBtnCancel.Click += new System.EventHandler(this.CtlBtnCancel_Click);
			// 
			// CtlBtnDeselectAll
			// 
			this.CtlBtnDeselectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CtlBtnDeselectAll.Location = new System.Drawing.Point(440, 408);
			this.CtlBtnDeselectAll.Name = "CtlBtnDeselectAll";
			this.CtlBtnDeselectAll.Size = new System.Drawing.Size(124, 23);
			this.CtlBtnDeselectAll.TabIndex = 3;
			this.CtlBtnDeselectAll.Text = "&Deselect All";
			this.CtlBtnDeselectAll.Click += new System.EventHandler(this.CtlBtnDeselectAll_Click);
			// 
			// CtlBtnSelectAll
			// 
			this.CtlBtnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CtlBtnSelectAll.Location = new System.Drawing.Point(316, 408);
			this.CtlBtnSelectAll.Name = "CtlBtnSelectAll";
			this.CtlBtnSelectAll.Size = new System.Drawing.Size(124, 23);
			this.CtlBtnSelectAll.TabIndex = 4;
			this.CtlBtnSelectAll.Text = "&Select All";
			this.CtlBtnSelectAll.Click += new System.EventHandler(this.CtlBtnSelectAll_Click);
			// 
			// FrmFilter
			// 
			this.AcceptButton = this.CtlBtnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CtlBtnCancel;
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.CtlBtnSelectAll);
			this.Controls.Add(this.CtlBtnDeselectAll);
			this.Controls.Add(this.CtlBtnCancel);
			this.Controls.Add(this.CtlBtnOK);
			this.Controls.Add(this.CtlFileTypeList);
			this.Name = "FrmFilter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Filter Totals";
			this.ResumeLayout(false);

		}
		#endregion

		private void FillListBox() {
			int NewIndex;
			this._suppressCheckedEvent = true;
			try {
				this.CtlFileTypeList.BeginUpdate();
				foreach (Bucket B in this._bucketMgr) {
					NewIndex = this.CtlFileTypeList.Items.Add(B);
				}
				this.CtlFileTypeList.EndUpdate();
				for (int i=0; i < this.CtlFileTypeList.Items.Count; ++i) {
					Bucket B = (Bucket) this.CtlFileTypeList.Items[i];
					this.CtlFileTypeList.SetItemChecked(i, B.IncludedInTotals);
				}
			}
			finally {
				this._suppressCheckedEvent = false;
			}

		}

		private void CtlBtnCancel_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void CtlBtnOK_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void CtlBtnSelectAll_Click(object sender, System.EventArgs e) {
			try {
				for (int i = 0; i < this.CtlFileTypeList.Items.Count; ++i)
					this.CtlFileTypeList.SetItemChecked(i, true);
			}
			catch (Exception E) {
				MessageBox.Show(E.ToString());
			}
		}

		private void CtlBtnDeselectAll_Click(object sender, System.EventArgs e) {
			for (int i = 0; i < this.CtlFileTypeList.Items.Count; ++i)
				this.CtlFileTypeList.SetItemChecked(i, false);
		}

		//If the item is checked, find the appropriate bucket and set it's IncludedInTotals 
		//flag accordingly.

		private void CtlFileTypeList_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e) {
			Bucket B;

			if (!this._suppressCheckedEvent) {
				string FileType = this.CtlFileTypeList.Items[e.Index].ToString();
				B = this._bucketMgr.FindBucket(FileType);
				B.IncludedInTotals = (e.NewValue == CheckState.Checked);
			}
		}
	}
}
