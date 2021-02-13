<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoom
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstPlayer = New System.Windows.Forms.ListView()
        Me.NickName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClientVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstChat = New System.Windows.Forms.ListBox()
        Me.txtChat = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnServerInfo = New System.Windows.Forms.Button()
        Me.btnvote = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstPlayer
        '
        Me.lstPlayer.AllowColumnReorder = True
        Me.lstPlayer.BackColor = System.Drawing.SystemColors.Window
        Me.lstPlayer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NickName, Me.ClientName, Me.ClientVersion})
        Me.lstPlayer.Font = New System.Drawing.Font("굴림", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstPlayer.Location = New System.Drawing.Point(12, 12)
        Me.lstPlayer.Name = "lstPlayer"
        Me.lstPlayer.Size = New System.Drawing.Size(470, 296)
        Me.lstPlayer.TabIndex = 0
        Me.lstPlayer.UseCompatibleStateImageBehavior = False
        Me.lstPlayer.View = System.Windows.Forms.View.Details
        '
        'NickName
        '
        Me.NickName.Text = "닉네임"
        Me.NickName.Width = 184
        '
        'ClientName
        '
        Me.ClientName.Text = "클라이언트 이름"
        Me.ClientName.Width = 140
        '
        'ClientVersion
        '
        Me.ClientVersion.Text = "클라이언트 버젼"
        Me.ClientVersion.Width = 141
        '
        'lstChat
        '
        Me.lstChat.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstChat.FormattingEnabled = True
        Me.lstChat.HorizontalExtent = 900
        Me.lstChat.HorizontalScrollbar = True
        Me.lstChat.ItemHeight = 16
        Me.lstChat.Location = New System.Drawing.Point(12, 325)
        Me.lstChat.Name = "lstChat"
        Me.lstChat.Size = New System.Drawing.Size(470, 164)
        Me.lstChat.TabIndex = 1
        '
        'txtChat
        '
        Me.txtChat.Location = New System.Drawing.Point(12, 503)
        Me.txtChat.Name = "txtChat"
        Me.txtChat.Size = New System.Drawing.Size(390, 21)
        Me.txtChat.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(407, 501)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "전송"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 530)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(81, 30)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "종료"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnServerInfo
        '
        Me.btnServerInfo.BackColor = System.Drawing.SystemColors.Control
        Me.btnServerInfo.Location = New System.Drawing.Point(99, 530)
        Me.btnServerInfo.Name = "btnServerInfo"
        Me.btnServerInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnServerInfo.Size = New System.Drawing.Size(148, 30)
        Me.btnServerInfo.TabIndex = 5
        Me.btnServerInfo.Text = "서버 정보"
        Me.btnServerInfo.UseVisualStyleBackColor = False
        '
        'btnvote
        '
        Me.btnvote.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnvote.Location = New System.Drawing.Point(253, 531)
        Me.btnvote.Name = "btnvote"
        Me.btnvote.Size = New System.Drawing.Size(229, 29)
        Me.btnvote.TabIndex = 6
        Me.btnvote.Text = "게임 시작 투표"
        Me.btnvote.UseVisualStyleBackColor = True
        '
        'FrmRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 565)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnvote)
        Me.Controls.Add(Me.btnServerInfo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtChat)
        Me.Controls.Add(Me.lstChat)
        Me.Controls.Add(Me.lstPlayer)
        Me.MaximumSize = New System.Drawing.Size(510, 603)
        Me.MinimumSize = New System.Drawing.Size(510, 603)
        Me.Name = "FrmRoom"
        Me.Text = "초기화 되지 않음"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstPlayer As System.Windows.Forms.ListView
    Friend WithEvents NickName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClientVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstChat As System.Windows.Forms.ListBox
    Friend WithEvents txtChat As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Public Shared WithEvents btnvote As System.Windows.Forms.Button
    Public Shared WithEvents btnServerInfo As System.Windows.Forms.Button
End Class
