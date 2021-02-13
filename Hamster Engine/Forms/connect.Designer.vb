<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnect
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
        Me.txtIPaddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNickname = New System.Windows.Forms.TextBox()
        Me.btnConn = New System.Windows.Forms.Button()
        Me.btnEND = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtIPaddress
        '
        Me.txtIPaddress.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtIPaddress.Location = New System.Drawing.Point(12, 54)
        Me.txtIPaddress.MaxLength = 15
        Me.txtIPaddress.Name = "txtIPaddress"
        Me.txtIPaddress.Size = New System.Drawing.Size(288, 41)
        Me.txtIPaddress.TabIndex = 0
        Me.txtIPaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "마피아 서버 연결"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "서버의 IP 주소를 입력해주세요"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(307, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "게임에서 사용하실 닉네임을 입력해주세요(※실명 권장)"
        '
        'txtNickname
        '
        Me.txtNickname.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtNickname.Location = New System.Drawing.Point(12, 123)
        Me.txtNickname.MaxLength = 10
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(288, 41)
        Me.txtNickname.TabIndex = 4
        Me.txtNickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnConn
        '
        Me.btnConn.Enabled = False
        Me.btnConn.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnConn.Location = New System.Drawing.Point(12, 170)
        Me.btnConn.Name = "btnConn"
        Me.btnConn.Size = New System.Drawing.Size(234, 29)
        Me.btnConn.TabIndex = 5
        Me.btnConn.Text = "접속"
        Me.btnConn.UseVisualStyleBackColor = True
        '
        'btnEND
        '
        Me.btnEND.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnEND.Location = New System.Drawing.Point(252, 170)
        Me.btnEND.Name = "btnEND"
        Me.btnEND.Size = New System.Drawing.Size(48, 29)
        Me.btnEND.TabIndex = 6
        Me.btnEND.Text = "종료"
        Me.btnEND.UseVisualStyleBackColor = True
        '
        'FrmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEND)
        Me.Controls.Add(Me.btnConn)
        Me.Controls.Add(Me.txtNickname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIPaddress)
        Me.MaximumSize = New System.Drawing.Size(328, 247)
        Me.MinimumSize = New System.Drawing.Size(328, 247)
        Me.Name = "FrmConnect"
        Me.Text = "초기화 되지 않음"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEND As System.Windows.Forms.Button
    Public Shared WithEvents txtNickname As System.Windows.Forms.TextBox
    Public Shared WithEvents txtIPaddress As System.Windows.Forms.TextBox
    Public Shared WithEvents btnConn As System.Windows.Forms.Button
    '이 개체들은 반드시 Public Shared 로 선언되야 합니다.
    'Public Shared 개체목록 끝


End Class
