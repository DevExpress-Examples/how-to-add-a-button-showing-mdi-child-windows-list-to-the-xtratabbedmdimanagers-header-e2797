Imports System
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.Buttons
Imports DevExpress.XtraTab.ViewInfo

Namespace CustomTabbedMdiManager
	Public Class MySkinTabControlViewInfo
		Inherits SkinTabControlViewInfo
		Public Event ActiveFilesButtonClick As EventHandler(Of ActiveFilesButtonClickEventArgs)

		Public Sub New(ByVal tabControl As IXtraTab)
			MyBase.New(tabControl)
			AddActiveFilesButton = False
		End Sub

		Protected Overrides Sub OnHeaderButtonClick(ByVal button As TabButtonInfo)
			MyBase.OnHeaderButtonClick(button)

			If button.ButtonType = TabButtonType.User Then
				OnActiveFilesButtonClick(New ActiveFilesButtonClickEventArgs(button))
			End If
		End Sub

		Protected Overridable Sub OnActiveFilesButtonClick(ByVal ea As ActiveFilesButtonClickEventArgs)
			RaiseEvent ActiveFilesButtonClick(Me, ea)
		End Sub

		Private privateAddActiveFilesButton As Boolean
		Public Property AddActiveFilesButton() As Boolean
			Get
				Return privateAddActiveFilesButton
			End Get
			Set(ByVal value As Boolean)
				privateAddActiveFilesButton = value
			End Set
		End Property
	End Class
End Namespace