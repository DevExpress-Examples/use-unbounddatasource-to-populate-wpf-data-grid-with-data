Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Core
Imports System.Collections.ObjectModel

Namespace UnboundSource
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DXWindow

        Private vm As MyViewModel

        Public Sub New()
            vm = New MyViewModel()
            InitializeComponent()
        End Sub

        Private Sub UnboundDataSource_ValueNeeded(ByVal sender As Object, ByVal e As DevExpress.Data.UnboundSourceValueNeededEventArgs)
            Dim ind = e.RowIndex
            If e.PropertyName = "UnboundFirstName" Then
                e.Value = vm.ListPerson(ind).FirstName
            End If
            If e.PropertyName = "UnboundAge" Then
                e.Value = vm.ListPerson(ind).Age
            End If
            If e.PropertyName = "UnboundGroup" Then
                e.Value = vm.ListPerson(ind).Group
            End If
        End Sub

        Private Sub UnboundDataSource_ValuePushed(ByVal sender As Object, ByVal e As DevExpress.Data.UnboundSourceValuePushedEventArgs)
            Dim ind = e.RowIndex
            If e.PropertyName = "UnboundFirstName" Then
                vm.ListPerson(ind).FirstName = CStr(e.Value)
            End If
            If e.PropertyName = "UnboundAge" Then
                vm.ListPerson(ind).Age = CInt((e.Value))
            End If
            If e.PropertyName = "UnboundGroup" Then
                vm.ListPerson(ind).Group = CBool(e.Value)
            End If
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            unboundDataSource1.SetRowCount(10)
        End Sub
    End Class

    Public Class MyViewModel
        Public Sub New()
            CreateList()
        End Sub

        Private Sub CreateList()
            ListPerson = New ObservableCollection(Of Person)()

            For i As Integer = 0 To 49
                Dim p As New Person(i)
                ListPerson.Add(p)
            Next i
        End Sub

        Public Property ListPerson() As ObservableCollection(Of Person)
    End Class

    Public Class Person

        Public Sub New(ByVal i As Integer)
            FirstName = "FirstName" & i
            LastName = "LastName" & i
            Age = i * 10
            Group = i Mod 2 = 0

        End Sub

        Public Property Age() As Integer
        Public Property FirstName() As String
        Public Property Group() As Object
        Public Property LastName() As String
    End Class

End Namespace
