using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview.Native;
using DevExpress.XtraPrinting;

namespace CustomItem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReportPrintTool tool = new ReportPrintTool(new XtraReport1());
            tool.PreviewForm.Shown += PreviewForm_Shown;
            tool.ShowPreviewDialog();
        }

        void PreviewForm_Shown(object sender, EventArgs e)
        {
            PrintPreviewFormEx form = (PrintPreviewFormEx)sender;
            PrintPreviewBarItem item = (PrintPreviewBarItem)form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile);
            PrintPreviewBarItemsLogic.PopupMenuEx control = (PrintPreviewBarItemsLogic.PopupMenuEx)((DevExpress.XtraBars.BarButtonItem)(item)).DropDownControl;            
            BarButtonItem barItem = new BarButtonItem();
            barItem.ItemClick += barItem_ItemClick;
            barItem.Caption = "Custom Item";
            control.AddItem(barItem);
        }

        void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {            
            MessageBox.Show("Item is clicked!");
        }
    }
}
