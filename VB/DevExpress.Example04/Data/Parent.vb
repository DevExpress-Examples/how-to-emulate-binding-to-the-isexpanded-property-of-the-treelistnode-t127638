Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel

Namespace DevExpress.Example04.Data

	Public Class Toy
		Inherits BindableBase
		Protected _Name As String
		Public Property Name() As String
			Get
				Return Me._Name
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._Name, value, "Name")
			End Set
		End Property

	End Class

	Public Class Child
		Inherits BindableBase

		Protected _Name As String

		Public Property Name() As String
			Get
				Return Me._Name
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._Name, value, "Name")
			End Set
		End Property

		Protected _Age As Integer
		Public Property Age() As Integer
			Get
				Return Me._Age
			End Get
			Set(ByVal value As Integer)
				Me.SetProperty(Me._Age, value, "Age")
			End Set
		End Property

		Protected _IsExpanded As Boolean

		Public Property IsExpanded() As Boolean
			Get
				Return Me._IsExpanded
			End Get
			Set(ByVal value As Boolean)
				Me.SetProperty(Me._IsExpanded, value, "IsExpanded")
			End Set
		End Property

		Protected _Toys As ObservableCollection(Of Toy)

		Public ReadOnly Property Toys() As ObservableCollection(Of Toy)
			Get
				If Me._Toys Is Nothing Then
					Me._Toys = New ObservableCollection(Of Toy)()
				End If

				Return Me._Toys
			End Get
		End Property
	End Class

	Public Class Parent
		Inherits Child

		Protected _Children As ObservableCollection(Of Child)

		Public ReadOnly Property Children() As ObservableCollection(Of Child)
			Get
				If Me._Children Is Nothing Then
					Me._Children = New ObservableCollection(Of Child)()
				End If
				Return Me._Children
			End Get
		End Property
	End Class
End Namespace
