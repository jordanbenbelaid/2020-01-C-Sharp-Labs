Imports System.Data.Entity

Namespace Data
    
    Public Class lab_47_mvc_framework_demoContext
        Inherits DbContext
    
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, please use data migrations.
        ' For more information refer to the documentation:
        ' http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        Public Sub New()
            MyBase.New("name=lab_47_mvc_framework_demoContext")
        End Sub

        Public Property Users As System.Data.Entity.DbSet(Of lab_47_mvc_framework_demo.User)
        Public Property Categories As System.Data.Entity.DbSet(Of lab_47_mvc_framework_demo.Category)
    End Class
    
End Namespace
