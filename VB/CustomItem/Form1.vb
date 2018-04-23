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

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tool As New ReportPrintTool(New XtraReport2())
        AddHandler tool.PreviewForm.Shown, AddressOf PreviewForm_Shown
        tool.ShowPreviewDialog()
    End Sub

    Private Sub PreviewForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
        Dim form As PrintPreviewFormEx = CType(sender, PrintPreviewFormEx)
        Dim item As PrintPreviewBarItem = CType(form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile), PrintPreviewBarItem)
        Dim control As PrintPreviewBarItemsLogic.PopupMenuEx = CType((CType(item, DevExpress.XtraBars.BarButtonItem)).DropDownControl, PrintPreviewBarItemsLogic.PopupMenuEx)
        Dim barItem As New BarButtonItem()
        AddHandler barItem.ItemClick, AddressOf barItem_ItemClick
        barItem.Caption = "Custom Item"
        control.AddItem(barItem)
    End Sub

    Private Sub barItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        MessageBox.Show("Item is clicked!")
    End Sub

End Class
