#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Forms = System.Windows.Forms;

#endregion

namespace RevitAddin4
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Selecting a file
            Forms.OpenFileDialog dialog = new Forms.OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Multiselect = false;
            dialog.Filter = "Revit File | *.rvt; *.rfa";

            // open the file
            string filePath = "";
            string[] filePaths;
            if (dialog.ShowDialog() == Forms.DialogResult.OK)
            {
                //filePath = dialog.FileName;
                filePaths = dialog.FileNames;
            }

            Forms.FolderBrowserDialog folderDialog = new Forms.FolderBrowserDialog();

            string folderPath = "";

            if (folderDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                folderPath = folderDialog.SelectedPath;
            }

            Tuple<string, int> t1 = new Tuple<string, int>("string 1", 55);
            Tuple<string, int> t2 = new Tuple<string, int>("string 2", 155);

            TestStruct struct1;
            struct1.Name = "Structure 1";
            struct1.Value = 100;
            struct1.Value2 = 10.5;

            TestStruct struct2 = new TestStruct("structure 1", 10, 1004.4);

            List<TestStruct> strctList = new List<TestStruct>();
            strctList.Add(struct1);


            return Result.Succeeded;
        }

        internal struct TestStruct
        {
            public string Name;
            public int Value;
            public double Value2;

            public TestStruct(string name, int value, double value2)
            {
                Name = name;
                Value = value;
                Value2 = value2;
            }
        }

    }
}
