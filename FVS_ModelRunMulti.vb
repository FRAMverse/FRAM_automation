Public Class FVS_ModelRunMulti
    Private Sub FVS_ModelRunMulti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create the MenuStrip
        Dim menuStrip As New MenuStrip()

        ' Create File menu
        Dim fileMenu As New ToolStripMenuItem("&File")

        ' Create File menu items
        Dim newItem As New ToolStripMenuItem("&New")
        Dim openItem As New ToolStripMenuItem("&Open")
        Dim saveItem As New ToolStripMenuItem("&Save")
        Dim exitItem As New ToolStripMenuItem("E&xit")

        ' Add event handlers
        AddHandler newItem.Click, AddressOf NewFile_Click
        AddHandler openItem.Click, AddressOf OpenFile_Click
        AddHandler saveItem.Click, AddressOf SaveFile_Click
        AddHandler exitItem.Click, AddressOf ExitApp_Click

        ' Add separator
        Dim separator As New ToolStripSeparator()

        ' Add items to File menu
        fileMenu.DropDownItems.Add(newItem)
        fileMenu.DropDownItems.Add(openItem)
        fileMenu.DropDownItems.Add(saveItem)
        fileMenu.DropDownItems.Add(separator)
        fileMenu.DropDownItems.Add(exitItem)

        ' Create Edit menu
        Dim editMenu As New ToolStripMenuItem("&Edit")
        Dim cutItem As New ToolStripMenuItem("Cu&t")
        Dim copyItem As New ToolStripMenuItem("&Copy")
        Dim pasteItem As New ToolStripMenuItem("&Paste")

        editMenu.DropDownItems.Add(cutItem)
        editMenu.DropDownItems.Add(copyItem)
        editMenu.DropDownItems.Add(pasteItem)

        ' Add menus to MenuStrip
        menuStrip.Items.Add(fileMenu)
        menuStrip.Items.Add(editMenu)

        ' Add MenuStrip to form
        Me.MainMenuStrip = menuStrip
        Me.Controls.Add(menuStrip)
    End Sub

    ' Event handlers
    Private Sub NewFile_Click(sender As Object, e As EventArgs)
        MessageBox.Show("New file clicked!")
    End Sub

    Private Sub OpenFile_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Open file clicked!")
    End Sub

    Private Sub SaveFile_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Save file clicked!")
    End Sub

    Private Sub ExitApp_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class