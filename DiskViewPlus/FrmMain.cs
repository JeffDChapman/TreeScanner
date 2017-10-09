using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;
using DVFileManager;
using KayeScholer.DiskView.DVFileManager;

namespace DiskViewPlus {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form {
		private System.Windows.Forms.Panel CtlPanelTop;
		private System.Windows.Forms.StatusBar CtlStatusBar;
		private System.Windows.Forms.StatusBarPanel CtlSBMessage;
		private System.Windows.Forms.Panel CtlPanelLeft;
		private System.Windows.Forms.Splitter CtlVSplitter;
		private System.Windows.Forms.Panel CtlPanelRight;
		private System.Windows.Forms.ToolBar CtlToolBar;
		private System.Windows.Forms.ToolBarButton CtlBtnOpenFolder;
		private System.Windows.Forms.FolderBrowserDialog CtlFolderBrowser;
		private System.Windows.Forms.TextBox CtlSelectedFolder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.StatusBarPanel CtlSBState;
		private System.Windows.Forms.TreeView CtlFolderTree;
		private System.Windows.Forms.ListView CtlLVContents;
		private System.Windows.Forms.ColumnHeader CTLLVColFileType;
		private System.Windows.Forms.ColumnHeader CtlLVColFileCount;
		private System.Windows.Forms.ColumnHeader CtlLVColFileSize;
		private System.Windows.Forms.ToolBarButton CtlBtnFilter;
		private System.Windows.Forms.GroupBox CtlSortGroup;
		private System.Windows.Forms.RadioButton CtlRdoBySize;
		private System.Windows.Forms.RadioButton CtlRdoByCount;
		private System.Windows.Forms.TextBox CtlCurrentSubfolder;
		private System.Windows.Forms.ContextMenu CtlMenuFolder;
		private System.Windows.Forms.MenuItem CtlMnuExplore;
        private System.Windows.Forms.MenuItem CtlMnuQuickViewPlus;
		private Traverser	_scanner;

		public FrmMain() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this._scanner = null;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
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
		private void InitializeComponent() {
            this.CtlPanelTop = new System.Windows.Forms.Panel();
            this.CtlSelectedFolder = new System.Windows.Forms.TextBox();
            this.CtlToolBar = new System.Windows.Forms.ToolBar();
            this.CtlBtnOpenFolder = new System.Windows.Forms.ToolBarButton();
            this.CtlBtnFilter = new System.Windows.Forms.ToolBarButton();
            this.CtlStatusBar = new System.Windows.Forms.StatusBar();
            this.CtlSBState = new System.Windows.Forms.StatusBarPanel();
            this.CtlSBMessage = new System.Windows.Forms.StatusBarPanel();
            this.CtlPanelLeft = new System.Windows.Forms.Panel();
            this.CtlSortGroup = new System.Windows.Forms.GroupBox();
            this.CtlRdoByCount = new System.Windows.Forms.RadioButton();
            this.CtlRdoBySize = new System.Windows.Forms.RadioButton();
            this.CtlFolderTree = new System.Windows.Forms.TreeView();
            this.CtlMenuFolder = new System.Windows.Forms.ContextMenu();
            this.CtlMnuExplore = new System.Windows.Forms.MenuItem();
            this.CtlMnuQuickViewPlus = new System.Windows.Forms.MenuItem();
            this.CtlVSplitter = new System.Windows.Forms.Splitter();
            this.CtlPanelRight = new System.Windows.Forms.Panel();
            this.CtlCurrentSubfolder = new System.Windows.Forms.TextBox();
            this.CtlLVContents = new System.Windows.Forms.ListView();
            this.CTLLVColFileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CtlLVColFileCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CtlLVColFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CtlFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.CtlPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlSBState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtlSBMessage)).BeginInit();
            this.CtlPanelLeft.SuspendLayout();
            this.CtlSortGroup.SuspendLayout();
            this.CtlPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtlPanelTop
            // 
            this.CtlPanelTop.BackColor = System.Drawing.SystemColors.Control;
            this.CtlPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CtlPanelTop.Controls.Add(this.CtlSelectedFolder);
            this.CtlPanelTop.Controls.Add(this.CtlToolBar);
            this.CtlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.CtlPanelTop.Name = "CtlPanelTop";
            this.CtlPanelTop.Size = new System.Drawing.Size(712, 80);
            this.CtlPanelTop.TabIndex = 0;
            // 
            // CtlSelectedFolder
            // 
            this.CtlSelectedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlSelectedFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CtlSelectedFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtlSelectedFolder.ForeColor = System.Drawing.Color.Lime;
            this.CtlSelectedFolder.Location = new System.Drawing.Point(8, 57);
            this.CtlSelectedFolder.Name = "CtlSelectedFolder";
            this.CtlSelectedFolder.PasswordChar = '*';
            this.CtlSelectedFolder.Size = new System.Drawing.Size(688, 15);
            this.CtlSelectedFolder.TabIndex = 1;
            this.CtlSelectedFolder.TabStop = false;
            this.CtlSelectedFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CtlToolBar
            // 
            this.CtlToolBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CtlToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.CtlBtnOpenFolder,
            this.CtlBtnFilter});
            this.CtlToolBar.DropDownArrows = true;
            this.CtlToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtlToolBar.Location = new System.Drawing.Point(0, 0);
            this.CtlToolBar.Name = "CtlToolBar";
            this.CtlToolBar.ShowToolTips = true;
            this.CtlToolBar.Size = new System.Drawing.Size(708, 47);
            this.CtlToolBar.TabIndex = 0;
            this.CtlToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.CtlToolBar_ButtonClick);
            // 
            // CtlBtnOpenFolder
            // 
            this.CtlBtnOpenFolder.Name = "CtlBtnOpenFolder";
            this.CtlBtnOpenFolder.Tag = "CMDOPEN";
            this.CtlBtnOpenFolder.Text = "Open";
            this.CtlBtnOpenFolder.ToolTipText = "Open folder to scan";
            // 
            // CtlBtnFilter
            // 
            this.CtlBtnFilter.Name = "CtlBtnFilter";
            this.CtlBtnFilter.Tag = "CMDFILTER";
            this.CtlBtnFilter.Text = "Filter";
            this.CtlBtnFilter.ToolTipText = "Filter File Types";
            // 
            // CtlStatusBar
            // 
            this.CtlStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtlStatusBar.Location = new System.Drawing.Point(0, 488);
            this.CtlStatusBar.Name = "CtlStatusBar";
            this.CtlStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.CtlSBState,
            this.CtlSBMessage});
            this.CtlStatusBar.ShowPanels = true;
            this.CtlStatusBar.Size = new System.Drawing.Size(712, 22);
            this.CtlStatusBar.TabIndex = 1;
            // 
            // CtlSBState
            // 
            this.CtlSBState.Name = "CtlSBState";
            // 
            // CtlSBMessage
            // 
            this.CtlSBMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.CtlSBMessage.Name = "CtlSBMessage";
            this.CtlSBMessage.Width = 595;
            // 
            // CtlPanelLeft
            // 
            this.CtlPanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtlPanelLeft.Controls.Add(this.CtlSortGroup);
            this.CtlPanelLeft.Controls.Add(this.CtlFolderTree);
            this.CtlPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.CtlPanelLeft.Location = new System.Drawing.Point(0, 80);
            this.CtlPanelLeft.Name = "CtlPanelLeft";
            this.CtlPanelLeft.Size = new System.Drawing.Size(384, 408);
            this.CtlPanelLeft.TabIndex = 2;
            // 
            // CtlSortGroup
            // 
            this.CtlSortGroup.BackColor = System.Drawing.SystemColors.Control;
            this.CtlSortGroup.Controls.Add(this.CtlRdoByCount);
            this.CtlSortGroup.Controls.Add(this.CtlRdoBySize);
            this.CtlSortGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtlSortGroup.Location = new System.Drawing.Point(24, 3);
            this.CtlSortGroup.Name = "CtlSortGroup";
            this.CtlSortGroup.Size = new System.Drawing.Size(176, 40);
            this.CtlSortGroup.TabIndex = 1;
            this.CtlSortGroup.TabStop = false;
            this.CtlSortGroup.Text = "Sort By";
            // 
            // CtlRdoByCount
            // 
            this.CtlRdoByCount.Location = new System.Drawing.Point(105, 18);
            this.CtlRdoByCount.Name = "CtlRdoByCount";
            this.CtlRdoByCount.Size = new System.Drawing.Size(64, 16);
            this.CtlRdoByCount.TabIndex = 1;
            this.CtlRdoByCount.Text = "Count";
            // 
            // CtlRdoBySize
            // 
            this.CtlRdoBySize.Checked = true;
            this.CtlRdoBySize.Location = new System.Drawing.Point(9, 18);
            this.CtlRdoBySize.Name = "CtlRdoBySize";
            this.CtlRdoBySize.Size = new System.Drawing.Size(64, 16);
            this.CtlRdoBySize.TabIndex = 0;
            this.CtlRdoBySize.TabStop = true;
            this.CtlRdoBySize.Text = "Size";
            this.CtlRdoBySize.CheckedChanged += new System.EventHandler(this.CtlRdo_CheckedChanged);
            // 
            // CtlFolderTree
            // 
            this.CtlFolderTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlFolderTree.ContextMenu = this.CtlMenuFolder;
            this.CtlFolderTree.Location = new System.Drawing.Point(16, 48);
            this.CtlFolderTree.Name = "CtlFolderTree";
            this.CtlFolderTree.Size = new System.Drawing.Size(344, 344);
            this.CtlFolderTree.TabIndex = 0;
            this.CtlFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CtlFolderTree_AfterSelect);
            // 
            // CtlMenuFolder
            // 
            this.CtlMenuFolder.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.CtlMnuExplore,
            this.CtlMnuQuickViewPlus});
            // 
            // CtlMnuExplore
            // 
            this.CtlMnuExplore.Index = 0;
            this.CtlMnuExplore.Text = "Explore";
            this.CtlMnuExplore.Click += new System.EventHandler(this.CtlMnuExplore_Click);
            // 
            // CtlMnuQuickViewPlus
            // 
            this.CtlMnuQuickViewPlus.Index = 1;
            this.CtlMnuQuickViewPlus.Text = "Quick View Plus";
            this.CtlMnuQuickViewPlus.Click += new System.EventHandler(this.CtlMnuQuickViewPlus_Click);
            // 
            // CtlVSplitter
            // 
            this.CtlVSplitter.Location = new System.Drawing.Point(384, 80);
            this.CtlVSplitter.Name = "CtlVSplitter";
            this.CtlVSplitter.Size = new System.Drawing.Size(3, 408);
            this.CtlVSplitter.TabIndex = 3;
            this.CtlVSplitter.TabStop = false;
            // 
            // CtlPanelRight
            // 
            this.CtlPanelRight.Controls.Add(this.CtlCurrentSubfolder);
            this.CtlPanelRight.Controls.Add(this.CtlLVContents);
            this.CtlPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtlPanelRight.Location = new System.Drawing.Point(387, 80);
            this.CtlPanelRight.Name = "CtlPanelRight";
            this.CtlPanelRight.Size = new System.Drawing.Size(325, 408);
            this.CtlPanelRight.TabIndex = 4;
            // 
            // CtlCurrentSubfolder
            // 
            this.CtlCurrentSubfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlCurrentSubfolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CtlCurrentSubfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtlCurrentSubfolder.ForeColor = System.Drawing.Color.OrangeRed;
            this.CtlCurrentSubfolder.Location = new System.Drawing.Point(8, 16);
            this.CtlCurrentSubfolder.Name = "CtlCurrentSubfolder";
            this.CtlCurrentSubfolder.ReadOnly = true;
            this.CtlCurrentSubfolder.Size = new System.Drawing.Size(304, 19);
            this.CtlCurrentSubfolder.TabIndex = 1;
            this.CtlCurrentSubfolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CtlLVContents
            // 
            this.CtlLVContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtlLVContents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CTLLVColFileType,
            this.CtlLVColFileCount,
            this.CtlLVColFileSize});
            this.CtlLVContents.FullRowSelect = true;
            this.CtlLVContents.GridLines = true;
            this.CtlLVContents.Location = new System.Drawing.Point(8, 48);
            this.CtlLVContents.Name = "CtlLVContents";
            this.CtlLVContents.Size = new System.Drawing.Size(304, 344);
            this.CtlLVContents.TabIndex = 0;
            this.CtlLVContents.UseCompatibleStateImageBehavior = false;
            this.CtlLVContents.View = System.Windows.Forms.View.Details;
            this.CtlLVContents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.CtlLVContents_ColumnClick);
            // 
            // CTLLVColFileType
            // 
            this.CTLLVColFileType.Text = "File Type";
            this.CTLLVColFileType.Width = 82;
            // 
            // CtlLVColFileCount
            // 
            this.CtlLVColFileCount.Text = "File Count";
            this.CtlLVColFileCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CtlLVColFileCount.Width = 100;
            // 
            // CtlLVColFileSize
            // 
            this.CtlLVColFileSize.Text = "FileSize";
            this.CtlLVColFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CtlLVColFileSize.Width = 100;
            // 
            // CtlFolderBrowser
            // 
            this.CtlFolderBrowser.Description = "Select folder to scan";
            this.CtlFolderBrowser.ShowNewFolderButton = false;
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(712, 510);
            this.Controls.Add(this.CtlPanelRight);
            this.Controls.Add(this.CtlVSplitter);
            this.Controls.Add(this.CtlPanelLeft);
            this.Controls.Add(this.CtlStatusBar);
            this.Controls.Add(this.CtlPanelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.Text = "DiskView+";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.CtlPanelTop.ResumeLayout(false);
            this.CtlPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtlSBState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtlSBMessage)).EndInit();
            this.CtlPanelLeft.ResumeLayout(false);
            this.CtlSortGroup.ResumeLayout(false);
            this.CtlPanelRight.ResumeLayout(false);
            this.CtlPanelRight.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			try {
				//Application.EnableVisualStyles();
				Application.ThreadException += new ThreadExceptionEventHandler(ErrorHandler);
				Application.Run(new FrmMain());
			}
			catch (Exception E) {
				Trace.WriteLine(E.ToString());
				MessageBox.Show(E.ToString());
			}
		}

		static void ErrorHandler(object sender, System.Threading.ThreadExceptionEventArgs e) {
			Trace.WriteLine(string.Format("Unhandled exception {0} thrown by {1}", e.ToString(), sender.ToString()));
		}

		private void FrmMain_Load(object sender, System.EventArgs e) {
			Traverser.GlobalCompareType = (this.CtlRdoBySize.Checked) ? CompareType.BySize : CompareType.ByCount;
			Traverser.SetMessageCallback(new MsgCallback(this.Message));
		}

		private void CtlToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
			if (e.Button.Tag != null) {
				if (e.Button.Tag.Equals("CMDOPEN")) 
					CmdOpen();
				else if (e.Button.Tag.Equals("CMDFILTER")) 
					CmdFilter();
			}
		}

		private void CmdFilter() {
			if (this._scanner != null) {
				this.Cursor = Cursors.WaitCursor;
				try {
					FrmFilter	FilterForm = new FrmFilter(this._scanner.RootFolder.BucketMgr);

					if (FilterForm.ShowDialog(this) == DialogResult.OK) {
						SetStateText("Setting filter...");
						this._scanner.SetFiltersLike(FilterForm.BucketMgr);
						SetStateText("Clearning totals...");
						this.ClearAllFolderTotals();
						SetStateText("Resorting based on new totals...");
						this._scanner.ResortFolders();
						SetStateText("Reloading tree...");
						this.LoadTree();
						SetStateText("");
					}
					else
						Message("Not setting filter");
				}
				catch (Exception E) {
					MessageBox.Show(this, E.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally {
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void CmdOpen() {
            string pwSave = this.CtlSelectedFolder.Text;
            this.CtlSelectedFolder.Clear();
            this.CtlSelectedFolder.PasswordChar = '\0';
            this.CtlSelectedFolder.ReadOnly = true;

			if (this.CtlFolderBrowser.ShowDialog() == DialogResult.OK) {
                if (pwSave != "thirty")
                {
                    string licMsg = "Software License Expired";
                    MessageBox.Show(this, licMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
				this.CtlSelectedFolder.Text = this.CtlFolderBrowser.SelectedPath;
				this.SetStateText("Folder Selected");
				DoScan();
			}
			else
				this.CtlSelectedFolder.Clear();
		}

		private void SetStateText(string StateText) {
			this.CtlSBState.Text = StateText;
			this.Message(StateText);
		}

		private void DoScan() {
			this.Cursor = Cursors.WaitCursor;
			try {

				this._scanner = new Traverser(this.CtlSelectedFolder.Text);
				this.SetStateText("Scanning");
				this.Refresh();
				this._scanner.Scan();
				this.SetStateText("Loading Tree");
				LoadTree();
				this.SetStateText("Scan Complete");
				this.ClearMessage();
			}
			catch (Exception E) {
				MessageBox.Show(this, E.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally {
				this.Cursor = Cursors.Default;
			}
		}

		private void LoadTree() {
			TreeNode		RootNode;		//Current root
			this.CtlFolderTree.Nodes.Clear();
		
			RootNode = CreateTreeNode(this._scanner.RootFolder);
			this.CtlFolderTree.Nodes.Add(RootNode);
			LoadChildren(RootNode);
		}

		private TreeNode CreateTreeNode(ScanFolder Folder) {
			TreeNode NewNode;

            try
            {
                NewNode = new TreeNode(Folder.DisplayName);
            }
            catch { NewNode = new TreeNode("<Missed in scan>"); }

			NewNode.Tag = Folder;	//Use the Tag to hold the node's ScanFolder

			return NewNode;
		}

		private void Message(string Msg) {
			Trace.WriteLine(Msg);
			this.CtlSBMessage.Text = Msg;
			//this.Refresh();
			Application.DoEvents();
		}

		private void ClearMessage() {
			this.Message("");
		}

		private void CtlFolderTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			if (this.CtlFolderTree.SelectedNode != null) {
				DisplayTreeNode(this.CtlFolderTree.SelectedNode);
			}
		}

		private void DisplayTreeNode(TreeNode Node) {
			ScanFolder		Folder;
			BucketManager	BucketMgr;
			ListViewItem	NewItem;
			//Bucket			B;
			this.Cursor = Cursors.WaitCursor;
			try {
				this.CtlLVContents.Items.Clear();
				this.CtlLVContents.BeginUpdate();

				try {
					Folder = (ScanFolder) Node.Tag;
					BucketMgr = Folder.BucketMgr;

					this.CtlCurrentSubfolder.Text = Folder.FolderName;
					foreach(Bucket B in BucketMgr) {
						NewItem = new ListViewItem(new string[] { B.FileType.Trim(),
																	string.Format("{0:#,##0}", B.FileCount),
																	string.Format("{0:#,##0}", B.FileSize)
																});
						NewItem.Tag = B;
						this.CtlLVContents.Items.Add(NewItem);
					}
				}
				finally {
					this.CtlLVContents.EndUpdate();
				}
			}
			catch (Exception E) {
				MessageBox.Show(this, E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally {
				this.Cursor = Cursors.Default;
			}

		}


		private void LoadChildren(TreeNode TNode) {
			ScanFolder		Folder;
			FolderManager	SubfolderMgr;
			TreeNode		NewNode;

            try
            {
                Folder = (ScanFolder)TNode.Tag;
                SubfolderMgr = Folder.SubfolderMgr;
                foreach (ScanFolder f in SubfolderMgr)
                {
                    NewNode = CreateTreeNode(f);
                    TNode.Nodes.Add(NewNode);
                    LoadChildren(NewNode);
                }
            }
            catch { }
		}

		//This is a node visitor
		private void ClearTotalVisitor(ScanFolder f) {
			f.ClearTotals();
		}

		private void ClearAllFolderTotals() {
			this._scanner.RootFolder.Visit(new FolderVisitor(ClearTotalVisitor));
		}

		private void CtlRdo_CheckedChanged(object sender, System.EventArgs e) {
			Traverser.GlobalCompareType = (this.CtlRdoBySize.Checked) ? CompareType.BySize : CompareType.ByCount;

			if (this._scanner != null) {
				this.Cursor = Cursors.WaitCursor;
				try {
					Message("Clearning totals...");
					this.ClearAllFolderTotals();
					Message("Resorting based on new totals...");
					this._scanner.ResortFolders();
					Message("Reloading tree...");
					this.LoadTree();
					Message("Tree reloaded.");
				}
				finally {
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void CtlMnuExplore_Click(object sender, System.EventArgs e) {
			ScanFolder	CurrentScanFolder;

			CurrentScanFolder = this.GetCurrentScanFolder();
			if (CurrentScanFolder != null) {
				Explore(CurrentScanFolder);
			}
			else
				this.Message("No folder to explore.");
		}

		private void CtlMnuQuickViewPlus_Click(object sender, System.EventArgs e) {
			ScanFolder	CurrentScanFolder;

			CurrentScanFolder = this.GetCurrentScanFolder();
			if (CurrentScanFolder != null) {
				this.LaunchQuickViewPlus(CurrentScanFolder);
			}
			else
				this.Message("No folder to view.");
		
		}

		private ScanFolder GetCurrentScanFolder() {
			ScanFolder Result = null;

			TreeNode Node = this.CtlFolderTree.SelectedNode;
			if (Node != null)
				Result = (ScanFolder) Node.Tag;

			return Result;
		}

		private void Explore(ScanFolder Folder) {

			ProcessStartInfo	StartInfo;

			this.Cursor = Cursors.WaitCursor;
			try {
				this.Message(string.Format("Exploring {0}", Folder.FolderName));

				StartInfo = new ProcessStartInfo("explorer.exe", string.Format("\"{0}\"", Folder.FolderPath));
				Process.Start(StartInfo);
			}
			catch (Exception E) {
				MessageBox.Show(this, E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally {
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Make this generic
		/// </summary>
		/// <param name="Folder"></param>
		private void LaunchQuickViewPlus(ScanFolder Folder) {

			ProcessStartInfo	StartInfo;

			this.Cursor = Cursors.WaitCursor;
			try {
				this.Message(string.Format("Launching QuickViewPlus for {0}", Folder.FolderName));

				StartInfo = new ProcessStartInfo(@"C:\Program Files\Quick View Plus\Program\qvp32.exe", 
					string.Format("\"{0}\"", Folder.FolderPath));
				Process.Start(StartInfo);
			}
			catch (Exception E) {
				MessageBox.Show(this, E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally {
				this.Cursor = Cursors.Default;
			}
		}

		private void CtlLVContents_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) {
			this.CtlLVContents.ListViewItemSorter = new ColSorter(e.Column);
			this.CtlLVContents.Sort();
		}
	}

	public class ColSorter : IComparer {

		enum SortCol { FileType, FileCount, FileSize };

		private SortCol _sortColumn;

		public ColSorter(int Col) {
			this._sortColumn = (SortCol) Col;
		}
		#region IComparer Members

		public int Compare(object x, object y) {
			ListViewItem	xItem = (ListViewItem) x;
			ListViewItem	yItem = (ListViewItem) y;
			Bucket			xBucket = (Bucket) xItem.Tag;
			Bucket			yBucket = (Bucket) yItem.Tag;

			switch (this._sortColumn) {
				case SortCol.FileType:
					return xBucket.FileType.CompareTo(yBucket.FileType);
				case SortCol.FileCount:
					return yBucket.FileCount.CompareTo(xBucket.FileCount);
				case SortCol.FileSize:
					return yBucket.FileSize.CompareTo(xBucket.FileSize);
			}

			return 0;
		}

		#endregion

	}
}
