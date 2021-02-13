<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGame
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
        Me.lstmemo = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtjob = New System.Windows.Forms.Label()
        Me.btnP1 = New System.Windows.Forms.Button()
        Me.btnP2 = New System.Windows.Forms.Button()
        Me.btnP3 = New System.Windows.Forms.Button()
        Me.btnP4 = New System.Windows.Forms.Button()
        Me.btnP5 = New System.Windows.Forms.Button()
        Me.btnP6 = New System.Windows.Forms.Button()
        Me.btnP7 = New System.Windows.Forms.Button()
        Me.btnP8 = New System.Windows.Forms.Button()
        Me.btnP9 = New System.Windows.Forms.Button()
        Me.btnP10 = New System.Windows.Forms.Button()
        Me.btnP11 = New System.Windows.Forms.Button()
        Me.btnP12 = New System.Windows.Forms.Button()
        Me.lstChat = New System.Windows.Forms.ListBox()
        Me.txtchat = New System.Windows.Forms.TextBox()
        Me.btnchat = New System.Windows.Forms.Button()
        Me.txtChatMode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTime = New System.Windows.Forms.Label()
        Me.btnTimePlus = New System.Windows.Forms.Button()
        Me.btnTimeMinus = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.txtmemo = New System.Windows.Forms.TextBox()
        Me.btnPublicmemo = New System.Windows.Forms.Button()
        Me.btnPrivateMemo = New System.Windows.Forms.Button()
        Me.BoxVote = New System.Windows.Forms.GroupBox()
        Me.btnVNo = New System.Windows.Forms.Button()
        Me.btnVP12 = New System.Windows.Forms.Button()
        Me.btnVP11 = New System.Windows.Forms.Button()
        Me.btnVP10 = New System.Windows.Forms.Button()
        Me.btnVP9 = New System.Windows.Forms.Button()
        Me.btnVP8 = New System.Windows.Forms.Button()
        Me.btnVP7 = New System.Windows.Forms.Button()
        Me.btnVP6 = New System.Windows.Forms.Button()
        Me.btnVP5 = New System.Windows.Forms.Button()
        Me.btnVP4 = New System.Windows.Forms.Button()
        Me.btnVP3 = New System.Windows.Forms.Button()
        Me.btnVP2 = New System.Windows.Forms.Button()
        Me.btnVP1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.BoxVote.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstmemo
        '
        Me.lstmemo.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstmemo.FormattingEnabled = True
        Me.lstmemo.ItemHeight = 15
        Me.lstmemo.Location = New System.Drawing.Point(12, 87)
        Me.lstmemo.Name = "lstmemo"
        Me.lstmemo.Size = New System.Drawing.Size(214, 469)
        Me.lstmemo.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtjob)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 69)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "내 직업"
        '
        'txtjob
        '
        Me.txtjob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtjob.Font = New System.Drawing.Font("굴림", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtjob.Location = New System.Drawing.Point(6, 17)
        Me.txtjob.Name = "txtjob"
        Me.txtjob.Size = New System.Drawing.Size(202, 49)
        Me.txtjob.TabIndex = 0
        Me.txtjob.Text = "내 직업"
        Me.txtjob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnP1
        '
        Me.btnP1.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP1.Location = New System.Drawing.Point(232, 12)
        Me.btnP1.Name = "btnP1"
        Me.btnP1.Size = New System.Drawing.Size(212, 69)
        Me.btnP1.TabIndex = 2
        Me.btnP1.Text = "플레이어 1"
        Me.btnP1.UseVisualStyleBackColor = True
        '
        'btnP2
        '
        Me.btnP2.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP2.Location = New System.Drawing.Point(232, 87)
        Me.btnP2.Name = "btnP2"
        Me.btnP2.Size = New System.Drawing.Size(212, 69)
        Me.btnP2.TabIndex = 3
        Me.btnP2.Text = "플레이어 2"
        Me.btnP2.UseVisualStyleBackColor = True
        '
        'btnP3
        '
        Me.btnP3.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP3.Location = New System.Drawing.Point(232, 162)
        Me.btnP3.Name = "btnP3"
        Me.btnP3.Size = New System.Drawing.Size(212, 69)
        Me.btnP3.TabIndex = 4
        Me.btnP3.Text = "플레이어 3"
        Me.btnP3.UseVisualStyleBackColor = True
        '
        'btnP4
        '
        Me.btnP4.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP4.Location = New System.Drawing.Point(232, 237)
        Me.btnP4.Name = "btnP4"
        Me.btnP4.Size = New System.Drawing.Size(212, 69)
        Me.btnP4.TabIndex = 5
        Me.btnP4.Text = "플레이어 4"
        Me.btnP4.UseVisualStyleBackColor = True
        '
        'btnP5
        '
        Me.btnP5.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP5.Location = New System.Drawing.Point(232, 312)
        Me.btnP5.Name = "btnP5"
        Me.btnP5.Size = New System.Drawing.Size(212, 69)
        Me.btnP5.TabIndex = 6
        Me.btnP5.Text = "플레이어 5"
        Me.btnP5.UseVisualStyleBackColor = True
        '
        'btnP6
        '
        Me.btnP6.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP6.Location = New System.Drawing.Point(232, 387)
        Me.btnP6.Name = "btnP6"
        Me.btnP6.Size = New System.Drawing.Size(212, 69)
        Me.btnP6.TabIndex = 7
        Me.btnP6.Text = "플레이어 6"
        Me.btnP6.UseVisualStyleBackColor = True
        '
        'btnP7
        '
        Me.btnP7.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP7.Location = New System.Drawing.Point(450, 12)
        Me.btnP7.Name = "btnP7"
        Me.btnP7.Size = New System.Drawing.Size(212, 69)
        Me.btnP7.TabIndex = 8
        Me.btnP7.Text = "플레이어 7"
        Me.btnP7.UseVisualStyleBackColor = True
        '
        'btnP8
        '
        Me.btnP8.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP8.Location = New System.Drawing.Point(450, 87)
        Me.btnP8.Name = "btnP8"
        Me.btnP8.Size = New System.Drawing.Size(212, 69)
        Me.btnP8.TabIndex = 9
        Me.btnP8.Text = "플레이어 8"
        Me.btnP8.UseVisualStyleBackColor = True
        '
        'btnP9
        '
        Me.btnP9.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP9.Location = New System.Drawing.Point(450, 162)
        Me.btnP9.Name = "btnP9"
        Me.btnP9.Size = New System.Drawing.Size(212, 69)
        Me.btnP9.TabIndex = 10
        Me.btnP9.Text = "플레이어 9"
        Me.btnP9.UseVisualStyleBackColor = True
        '
        'btnP10
        '
        Me.btnP10.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP10.Location = New System.Drawing.Point(450, 237)
        Me.btnP10.Name = "btnP10"
        Me.btnP10.Size = New System.Drawing.Size(212, 69)
        Me.btnP10.TabIndex = 11
        Me.btnP10.Text = "플레이어 10"
        Me.btnP10.UseVisualStyleBackColor = True
        '
        'btnP11
        '
        Me.btnP11.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP11.Location = New System.Drawing.Point(450, 312)
        Me.btnP11.Name = "btnP11"
        Me.btnP11.Size = New System.Drawing.Size(212, 69)
        Me.btnP11.TabIndex = 12
        Me.btnP11.Text = "플레이어 11"
        Me.btnP11.UseVisualStyleBackColor = True
        '
        'btnP12
        '
        Me.btnP12.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnP12.Location = New System.Drawing.Point(450, 386)
        Me.btnP12.Name = "btnP12"
        Me.btnP12.Size = New System.Drawing.Size(212, 69)
        Me.btnP12.TabIndex = 13
        Me.btnP12.Text = "플레이어 12"
        Me.btnP12.UseVisualStyleBackColor = True
        '
        'lstChat
        '
        Me.lstChat.Font = New System.Drawing.Font("굴림", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstChat.FormattingEnabled = True
        Me.lstChat.ItemHeight = 15
        Me.lstChat.Location = New System.Drawing.Point(232, 462)
        Me.lstChat.Name = "lstChat"
        Me.lstChat.Size = New System.Drawing.Size(430, 124)
        Me.lstChat.TabIndex = 14
        '
        'txtchat
        '
        Me.txtchat.Location = New System.Drawing.Point(278, 592)
        Me.txtchat.Name = "txtchat"
        Me.txtchat.Size = New System.Drawing.Size(315, 21)
        Me.txtchat.TabIndex = 15
        '
        'btnchat
        '
        Me.btnchat.Location = New System.Drawing.Point(599, 590)
        Me.btnchat.Name = "btnchat"
        Me.btnchat.Size = New System.Drawing.Size(55, 23)
        Me.btnchat.TabIndex = 16
        Me.btnchat.Text = "전송"
        Me.btnchat.UseVisualStyleBackColor = True
        '
        'txtChatMode
        '
        Me.txtChatMode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtChatMode.Location = New System.Drawing.Point(232, 592)
        Me.txtChatMode.Name = "txtChatMode"
        Me.txtChatMode.Size = New System.Drawing.Size(40, 26)
        Me.txtChatMode.TabIndex = 17
        Me.txtChatMode.Text = "모드"
        Me.txtChatMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTime)
        Me.GroupBox2.Location = New System.Drawing.Point(668, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 80)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "남은 시간"
        '
        'txtTime
        '
        Me.txtTime.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtTime.Location = New System.Drawing.Point(6, 17)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(161, 60)
        Me.txtTime.TabIndex = 0
        Me.txtTime.Text = "남은 시간"
        Me.txtTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTimePlus
        '
        Me.btnTimePlus.Location = New System.Drawing.Point(668, 98)
        Me.btnTimePlus.Name = "btnTimePlus"
        Me.btnTimePlus.Size = New System.Drawing.Size(173, 30)
        Me.btnTimePlus.TabIndex = 18
        Me.btnTimePlus.Text = "시간 연장"
        Me.btnTimePlus.UseVisualStyleBackColor = True
        '
        'btnTimeMinus
        '
        Me.btnTimeMinus.Location = New System.Drawing.Point(668, 134)
        Me.btnTimeMinus.Name = "btnTimeMinus"
        Me.btnTimeMinus.Size = New System.Drawing.Size(173, 30)
        Me.btnTimeMinus.TabIndex = 19
        Me.btnTimeMinus.Text = "시간 단축"
        Me.btnTimeMinus.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(668, 583)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(173, 30)
        Me.btnExit.TabIndex = 20
        Me.btnExit.Text = "종료"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnInfo
        '
        Me.btnInfo.Location = New System.Drawing.Point(668, 547)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(173, 30)
        Me.btnInfo.TabIndex = 21
        Me.btnInfo.Text = "서버 정보"
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'txtmemo
        '
        Me.txtmemo.Location = New System.Drawing.Point(12, 565)
        Me.txtmemo.Name = "txtmemo"
        Me.txtmemo.Size = New System.Drawing.Size(214, 21)
        Me.txtmemo.TabIndex = 22
        '
        'btnPublicmemo
        '
        Me.btnPublicmemo.Location = New System.Drawing.Point(12, 590)
        Me.btnPublicmemo.Name = "btnPublicmemo"
        Me.btnPublicmemo.Size = New System.Drawing.Size(101, 23)
        Me.btnPublicmemo.TabIndex = 23
        Me.btnPublicmemo.Text = "전체메모"
        Me.btnPublicmemo.UseVisualStyleBackColor = True
        '
        'btnPrivateMemo
        '
        Me.btnPrivateMemo.Location = New System.Drawing.Point(125, 590)
        Me.btnPrivateMemo.Name = "btnPrivateMemo"
        Me.btnPrivateMemo.Size = New System.Drawing.Size(101, 23)
        Me.btnPrivateMemo.TabIndex = 24
        Me.btnPrivateMemo.Text = "개인 메모"
        Me.btnPrivateMemo.UseVisualStyleBackColor = True
        '
        'BoxVote
        '
        Me.BoxVote.BackColor = System.Drawing.SystemColors.Control
        Me.BoxVote.Controls.Add(Me.btnVNo)
        Me.BoxVote.Controls.Add(Me.btnVP12)
        Me.BoxVote.Controls.Add(Me.btnVP11)
        Me.BoxVote.Controls.Add(Me.btnVP10)
        Me.BoxVote.Controls.Add(Me.btnVP9)
        Me.BoxVote.Controls.Add(Me.btnVP8)
        Me.BoxVote.Controls.Add(Me.btnVP7)
        Me.BoxVote.Controls.Add(Me.btnVP6)
        Me.BoxVote.Controls.Add(Me.btnVP5)
        Me.BoxVote.Controls.Add(Me.btnVP4)
        Me.BoxVote.Controls.Add(Me.btnVP3)
        Me.BoxVote.Controls.Add(Me.btnVP2)
        Me.BoxVote.Controls.Add(Me.btnVP1)
        Me.BoxVote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BoxVote.Location = New System.Drawing.Point(668, 170)
        Me.BoxVote.Name = "BoxVote"
        Me.BoxVote.Size = New System.Drawing.Size(173, 355)
        Me.BoxVote.TabIndex = 25
        Me.BoxVote.TabStop = False
        Me.BoxVote.Text = "투표"
        '
        'btnVNo
        '
        Me.btnVNo.Location = New System.Drawing.Point(11, 326)
        Me.btnVNo.Name = "btnVNo"
        Me.btnVNo.Size = New System.Drawing.Size(156, 20)
        Me.btnVNo.TabIndex = 38
        Me.btnVNo.Text = "무효투표"
        Me.btnVNo.UseVisualStyleBackColor = True
        '
        'btnVP12
        '
        Me.btnVP12.Location = New System.Drawing.Point(11, 300)
        Me.btnVP12.Name = "btnVP12"
        Me.btnVP12.Size = New System.Drawing.Size(156, 20)
        Me.btnVP12.TabIndex = 37
        Me.btnVP12.Text = "플레이어 12"
        Me.btnVP12.UseVisualStyleBackColor = True
        '
        'btnVP11
        '
        Me.btnVP11.Location = New System.Drawing.Point(11, 274)
        Me.btnVP11.Name = "btnVP11"
        Me.btnVP11.Size = New System.Drawing.Size(156, 20)
        Me.btnVP11.TabIndex = 36
        Me.btnVP11.Text = "플레이어 11"
        Me.btnVP11.UseVisualStyleBackColor = True
        '
        'btnVP10
        '
        Me.btnVP10.Location = New System.Drawing.Point(11, 248)
        Me.btnVP10.Name = "btnVP10"
        Me.btnVP10.Size = New System.Drawing.Size(156, 20)
        Me.btnVP10.TabIndex = 35
        Me.btnVP10.Text = "플레이어 10"
        Me.btnVP10.UseVisualStyleBackColor = True
        '
        'btnVP9
        '
        Me.btnVP9.Location = New System.Drawing.Point(11, 222)
        Me.btnVP9.Name = "btnVP9"
        Me.btnVP9.Size = New System.Drawing.Size(156, 20)
        Me.btnVP9.TabIndex = 34
        Me.btnVP9.Text = "플레이어 9"
        Me.btnVP9.UseVisualStyleBackColor = True
        '
        'btnVP8
        '
        Me.btnVP8.Location = New System.Drawing.Point(11, 196)
        Me.btnVP8.Name = "btnVP8"
        Me.btnVP8.Size = New System.Drawing.Size(156, 20)
        Me.btnVP8.TabIndex = 33
        Me.btnVP8.Text = "플레이어 8"
        Me.btnVP8.UseVisualStyleBackColor = True
        '
        'btnVP7
        '
        Me.btnVP7.Location = New System.Drawing.Point(11, 170)
        Me.btnVP7.Name = "btnVP7"
        Me.btnVP7.Size = New System.Drawing.Size(156, 20)
        Me.btnVP7.TabIndex = 32
        Me.btnVP7.Text = "플레이어 7"
        Me.btnVP7.UseVisualStyleBackColor = True
        '
        'btnVP6
        '
        Me.btnVP6.Location = New System.Drawing.Point(11, 144)
        Me.btnVP6.Name = "btnVP6"
        Me.btnVP6.Size = New System.Drawing.Size(156, 20)
        Me.btnVP6.TabIndex = 31
        Me.btnVP6.Text = "플레이어 6"
        Me.btnVP6.UseVisualStyleBackColor = True
        '
        'btnVP5
        '
        Me.btnVP5.Location = New System.Drawing.Point(11, 118)
        Me.btnVP5.Name = "btnVP5"
        Me.btnVP5.Size = New System.Drawing.Size(156, 20)
        Me.btnVP5.TabIndex = 30
        Me.btnVP5.Text = "플레이어 5"
        Me.btnVP5.UseVisualStyleBackColor = True
        '
        'btnVP4
        '
        Me.btnVP4.Location = New System.Drawing.Point(11, 92)
        Me.btnVP4.Name = "btnVP4"
        Me.btnVP4.Size = New System.Drawing.Size(156, 20)
        Me.btnVP4.TabIndex = 29
        Me.btnVP4.Text = "플레이어 4"
        Me.btnVP4.UseVisualStyleBackColor = True
        '
        'btnVP3
        '
        Me.btnVP3.Location = New System.Drawing.Point(11, 67)
        Me.btnVP3.Name = "btnVP3"
        Me.btnVP3.Size = New System.Drawing.Size(156, 20)
        Me.btnVP3.TabIndex = 28
        Me.btnVP3.Text = "플레이어 3"
        Me.btnVP3.UseVisualStyleBackColor = True
        '
        'btnVP2
        '
        Me.btnVP2.Location = New System.Drawing.Point(11, 42)
        Me.btnVP2.Name = "btnVP2"
        Me.btnVP2.Size = New System.Drawing.Size(156, 20)
        Me.btnVP2.TabIndex = 27
        Me.btnVP2.Text = "플레이어 2"
        Me.btnVP2.UseVisualStyleBackColor = True
        '
        'btnVP1
        '
        Me.btnVP1.Location = New System.Drawing.Point(11, 16)
        Me.btnVP1.Name = "btnVP1"
        Me.btnVP1.Size = New System.Drawing.Size(156, 20)
        Me.btnVP1.TabIndex = 26
        Me.btnVP1.Text = "플레이어 1"
        Me.btnVP1.UseVisualStyleBackColor = True
        '
        'FrmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.BoxVote)
        Me.Controls.Add(Me.btnPrivateMemo)
        Me.Controls.Add(Me.btnPublicmemo)
        Me.Controls.Add(Me.txtmemo)
        Me.Controls.Add(Me.btnInfo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnTimeMinus)
        Me.Controls.Add(Me.btnTimePlus)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtChatMode)
        Me.Controls.Add(Me.btnchat)
        Me.Controls.Add(Me.txtchat)
        Me.Controls.Add(Me.lstChat)
        Me.Controls.Add(Me.btnP12)
        Me.Controls.Add(Me.btnP11)
        Me.Controls.Add(Me.btnP10)
        Me.Controls.Add(Me.btnP9)
        Me.Controls.Add(Me.btnP8)
        Me.Controls.Add(Me.btnP7)
        Me.Controls.Add(Me.btnP6)
        Me.Controls.Add(Me.btnP5)
        Me.Controls.Add(Me.btnP4)
        Me.Controls.Add(Me.btnP3)
        Me.Controls.Add(Me.btnP2)
        Me.Controls.Add(Me.btnP1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstmemo)
        Me.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Name = "FrmGame"
        Me.Text = "초기화 되지 않음"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.BoxVote.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public Shared WithEvents btnVNo As System.Windows.Forms.Button
    Public Shared WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public Shared WithEvents lstChat As System.Windows.Forms.ListBox
    Public Shared WithEvents txtchat As System.Windows.Forms.TextBox
    Public Shared WithEvents btnchat As System.Windows.Forms.Button
    Public Shared WithEvents txtChatMode As System.Windows.Forms.Label
    Public Shared WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public Shared WithEvents txtmemo As System.Windows.Forms.TextBox
    Public Shared WithEvents btnPublicmemo As System.Windows.Forms.Button
    Public Shared WithEvents btnPrivateMemo As System.Windows.Forms.Button
    Public Shared WithEvents BoxVote As System.Windows.Forms.GroupBox
    Public Shared WithEvents btnVP12 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP11 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP10 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP9 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP8 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP7 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP6 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP5 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP4 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP3 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP2 As System.Windows.Forms.Button
    Public Shared WithEvents btnVP1 As System.Windows.Forms.Button
    Public Shared WithEvents btnTimePlus As System.Windows.Forms.Button
    Public Shared WithEvents btnTimeMinus As System.Windows.Forms.Button
    Public Shared WithEvents btnExit As System.Windows.Forms.Button
    Public Shared WithEvents btnInfo As System.Windows.Forms.Button
    Public Shared WithEvents lstmemo As System.Windows.Forms.ListBox
    Public Shared WithEvents txtTime As System.Windows.Forms.Label
    Public Shared WithEvents btnP1 As System.Windows.Forms.Button
    Public Shared WithEvents btnP2 As System.Windows.Forms.Button
    Public Shared WithEvents btnP3 As System.Windows.Forms.Button
    Public Shared WithEvents btnP4 As System.Windows.Forms.Button
    Public Shared WithEvents btnP5 As System.Windows.Forms.Button
    Public Shared WithEvents btnP6 As System.Windows.Forms.Button
    Public Shared WithEvents btnP7 As System.Windows.Forms.Button
    Public Shared WithEvents btnP8 As System.Windows.Forms.Button
    Public Shared WithEvents btnP9 As System.Windows.Forms.Button
    Public Shared WithEvents btnP10 As System.Windows.Forms.Button
    Public Shared WithEvents btnP11 As System.Windows.Forms.Button
    Public Shared WithEvents btnP12 As System.Windows.Forms.Button
    Public Shared WithEvents txtjob As System.Windows.Forms.Label
End Class
