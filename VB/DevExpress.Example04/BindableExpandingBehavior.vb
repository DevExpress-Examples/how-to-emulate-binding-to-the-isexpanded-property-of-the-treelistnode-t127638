Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Windows

Namespace DevExpress.Example04

	Public Class BindableExpandingBehavior
		Inherits Behavior(Of GridControl)

		Public Property ExpandingProperty() As String
			Get
				Return CStr(GetValue(ExpnaderProperty))
			End Get
			Set(ByVal value As String)
				SetValue(ExpnaderProperty, value)
			End Set
		End Property

		Public Shared ReadOnly ExpnaderProperty As DependencyProperty = DependencyProperty.Register("ExpandingProperty", GetType(String), GetType(BindableExpandingBehavior), New PropertyMetadata(String.Empty))

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			AddHandler Me.AssociatedObject.Loaded, AddressOf GridLoaded
		End Sub

		Protected Sub AttachItems(ByVal nodes As TreeListNodeCollection)
			Dim iterator As New TreeListNodeIterator(nodes)
			Do While iterator.MoveNext()
				Me.SubscribeObject(iterator.Current.Content)
				If iterator.Current.HasChildren Then
					Me.AttachItems(iterator.Current.Nodes)
				End If
			Loop
		End Sub

		Protected Sub GridLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If Not(TypeOf Me.AssociatedObject.View Is TreeListView) Then
				Return
			End If

			Dim grid = Me.AssociatedObject
			Me.AttachItems((TryCast(grid.View, TreeListView)).Nodes)

			Dim collection As INotifyCollectionChanged = CType(grid.ItemsSource, INotifyCollectionChanged)
			If collection IsNot Nothing Then
				AddHandler collection.CollectionChanged, AddressOf collection_CollectionChanged
			End If

			Dim tree = (TryCast(Me.AssociatedObject.View, TreeListView))
			AddHandler tree.NodeExpanded, AddressOf GridNodeChanged
			AddHandler tree.NodeCollapsed, AddressOf GridNodeChanged
		End Sub

		Protected Sub SubscribeObject(ByVal item As Object)
			Dim iPropChanged = CType(item, INotifyPropertyChanged)
			If iPropChanged IsNot Nothing Then
				AddHandler iPropChanged.PropertyChanged, AddressOf PropertyChanged
			End If
		End Sub

		Private Sub collection_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
			Select Case e.Action
				Case System.Collections.Specialized.NotifyCollectionChangedAction.Add, System.Collections.Specialized.NotifyCollectionChangedAction.Replace
					For Each item In e.NewItems
						Me.SubscribeObject(item)
						Dim node = Me.FindNodeByValue(item, (TryCast(Me.AssociatedObject.View, TreeListView)).Nodes)
						If node IsNot Nothing Then
							Me.AttachItems(node.Nodes)
						End If
					Next item

				Case Else
			End Select
		End Sub

		Protected Function FindNodeByValue(ByVal obj As Object, ByVal nodes As TreeListNodeCollection) As TreeListNode
			Dim result As TreeListNode = Nothing
			Dim iterator As New TreeListNodeIterator(nodes)
			Do While iterator.MoveNext() AndAlso result Is Nothing
				If iterator.Current.Content Is obj Then
					result = iterator.Current
				End If
				If result Is Nothing AndAlso iterator.Current.HasChildren Then
					result = Me.FindNodeByValue(obj, iterator.Current.Nodes)
				End If
			Loop

			Return result
		End Function

		Public Sub PropertyChanged(ByVal obj As Object, ByVal args As PropertyChangedEventArgs)
			If args.PropertyName = Me.ExpandingProperty Then
				Dim treeView = TryCast(Me.AssociatedObject.View, TreeListView)
				Dim node = Me.FindNodeByValue(obj, treeView.Nodes)
				If node IsNot Nothing Then
					Dim rowHandle As Integer = node.RowHandle
                    Dim isExpanded As Boolean = CBool(obj.GetType().GetProperty(args.PropertyName).GetValue(obj, Nothing))
					If Me.AssociatedObject.IsValidRowHandle(rowHandle) Then
						node.IsExpanded = isExpanded
					End If

					Do While isExpanded AndAlso node.ParentNode IsNot Nothing
						node.ParentNode.IsExpanded = isExpanded
						node = node.ParentNode
					Loop
				End If
			End If
		End Sub

		Private Sub GridNodeChanged(ByVal sender As Object, ByVal e As Xpf.Grid.TreeList.TreeListNodeEventArgs)
			Dim propInfo = e.Node.Content.GetType().GetProperty(Me.ExpandingProperty)
			If propInfo IsNot Nothing Then
                propInfo.SetValue(e.Node.Content, e.Node.IsExpanded, Nothing)
			End If
		End Sub
	End Class
End Namespace
