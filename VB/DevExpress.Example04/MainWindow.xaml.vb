Imports Microsoft.VisualBasic
Imports DevExpress.Example04.Data
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DevExpress.Example04
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Me.DataContext = Me
		End Sub

        Protected _items As ObservableCollection(Of Parent)

        Public ReadOnly Property Items() As ObservableCollection(Of Parent)
            Get
                If Me._items Is Nothing Then
                    Me._items = New ObservableCollection(Of Parent)(DataHelper.GetParents(200))
                End If
                Return Me._items
            End Get
        End Property

        Private Sub TableView_CellValueChanging(ByVal sender As Object, ByVal e As Xpf.Grid.CellValueChangedEventArgs)
            TryCast(sender, TableView).PostEditor()
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.Items.Clear()
        End Sub

        Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.Items.Add(DataHelper.GetParents(1).First())
        End Sub
    End Class
End Namespace
