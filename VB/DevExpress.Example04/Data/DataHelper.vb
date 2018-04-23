Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Namespace DevExpress.Example04.Data
	Public NotInheritable Class DataHelper

		Public Shared r As New Random()

		Private Sub New()
		End Sub
		Public Shared Function GetParents(ByVal amount As Integer) As List(Of Parent)
			Dim result As New List(Of Parent)()
			Dim i As Integer = 0
			Do While i < amount
				Dim parent = New Parent() With {.Name = _Names(r.Next(100)), .Age = r.Next(30) + 30}
				Dim childrenCount As Integer = r.Next(10) + 3
				Dim j As Integer = 0
				Do While j < childrenCount
					Dim child = New Child() With {.Name = _Names(r.Next(100)), .Age = r.Next(15) + 4}
					Dim toysCount As Integer = r.Next(15) + 2
					Dim q As Integer = 0
					Do While q < toysCount
						child.Toys.Add(New Toy() With {.Name = _Names(r.Next(100))})
						q += 1
					Loop

					parent.Children.Add(child)
					j += 1
				Loop

				result.Add(parent)
				i += 1
			Loop

			Return result
		End Function

		#Region "Names"

		Private Shared _Names() As String = { "Carla Abbott", "Carolyn Sosa", "Jared England", "Mannix Padilla", "Tanek Molina", "Skyler Tillman", "Jescie Shepard", "TaShya Barlow", "Georgia Bond", "Keane Wynn", "Rylee Shaw", "Susan Hardy", "Zane Park", "Fay Levy", "Emily Lee", "Kerry Bowen", "Quinn Carson", "Macaulay Camacho", "Judith Farley", "Kendall Poole", "Macy Klein", "Jackson Hays", "Maxwell Meadows", "Kenyon Calhoun", "Hammett Murphy", "Thor Carr", "Ahmed Rowland", "Clark Atkinson", "Lunea Warner", "Elijah Phillips", "Minerva Crane", "Merrill Delgado", "Derek Manning", "Kyla Hoffman", "Emi Steele", "Clark Miller", "Darius Riley", "Brittany Trujillo", "Vernon Compton", "Ora Bright", "Whoopi Hopkins", "Russell Dennis", "Colt Whitehead", "Fiona English", "Delilah Spears", "Chantale Savage", "Kimberley Cortez", "Buckminster Grant", "Lucian Bryant", "Veda Dunlap", "Laurel Cotton", "Willa Roach", "William Delacruz", "Sonya Sampson", "Xena Burt", "Tarik Conrad", "Cullen Henson", "Brian Joyce", "Quyn Benton", "Fallon Edwards", "Neville Sutton", "Slade Gould", "Thaddeus Little", "Wyoming Wood", "Kiona Moon", "Erasmus Holden", "Portia Cross", "Kennan Calderon", "Karen Dillard", "Francis Jacobson", "Simon Bailey", "Zephr Jimenez", "Sonia Holloway", "Ramona Hardy", "Sawyer Orr", "Tara Ramirez", "Anne Hutchinson", "Blake Baldwin", "Leigh Odonnell", "Quail Mccormick", "Zachery Bean", "Jasmine Benjamin", "Kerry Guy", "Lance Bowers", "Otto Bates", "Dara Bowen", "Geraldine Simon", "Thaddeus Cook", "Lara Todd", "Samson Kirk", "William Franks", "Laura Burt", "Riley Shaw", "Kaitlin Reeves", "Linda Strickland", "Yetta Brown", "Daryl Lopez", "Yen Marquez", "Alika May", "Jennifer Pickett" }

		#End Region ' Names

	End Class
End Namespace




































































































