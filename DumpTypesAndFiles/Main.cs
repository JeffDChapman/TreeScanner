using System;
using System.IO;
using System.Diagnostics;

namespace DumpTypesAndFiles
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Dumper
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try {
				if (args.Length != 1) {
					Usage();
					return;
				}
				DirectoryInfo Root = new DirectoryInfo(args[0]);
				Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
					"FileType",
					"FileName",
					"FullName",
					"FileSize",
					"CreationTime",
					"LastWriteTime"));
				ScanFolder(Root);
			}
			catch (Exception E) {
				Console.WriteLine(E.ToString());
			}
		}

		static void Usage() {
			Console.WriteLine(string.Format("Usage: {0} <root-folder>", 
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name));
		}

		static void ScanFolder(DirectoryInfo Folder) {
			try {
				foreach (FileInfo f in Folder.GetFiles()) {
					try {
						Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
							f.Extension.ToLower(),
							f.Name,
							f.FullName,
							f.Length,
							f.CreationTime,
							f.LastWriteTime));
					}
					catch (System.IO.IOException E) {
						Trace.WriteLine(string.Format("Ignoring error {0} in folder {1}",
							E.Message, Folder.FullName));
					}
				}
				foreach (DirectoryInfo d in Folder.GetDirectories()) {
					try {
						ScanFolder(d);
					}
					catch (System.IO.IOException E) {
						Trace.WriteLine(string.Format("Ignoring error {0} in folder {1}",
							E.Message, Folder.FullName));
					}
				}
			}
			catch (System.Exception E) {
				Trace.WriteLine(string.Format("Ignoring error {0} in folder {1}",
					E.Message, Folder.FullName));
			}
		}
	}
}
