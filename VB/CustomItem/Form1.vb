Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting.Preview.Native
Imports DevExpress.XtraPrinting

Namespace CustomItem
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim tool As New ReportPrintTool(New XtraReport1())
			AddHandler tool.PreviewForm.Shown, AddressOf PreviewForm_Shown
			tool.ShowPreviewDialog()
		End Sub

		Private Sub PreviewForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
			Dim form As PrintPreviewFormEx = CType(sender, PrintPreviewFormEx)
			Dim item As PrintPreviewBarItem = CType(form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile), PrintPreviewBarItem)

			Dim control As PopupMenu = CType((CType(item, DevExpress.XtraBars.BarButtonItem)).DropDownControl, PopupMenu)
			Dim barItem As New BarButtonItem()
			AddHandler barItem.ItemClick, AddressOf barItem_ItemClick
			barItem.Caption = "Custom Item"
			control.AddItem(barItem)
		End Sub

		Private Sub barItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			MessageBox.Show("Item is clicked!")
		End Sub
	End Class
End Namespace
