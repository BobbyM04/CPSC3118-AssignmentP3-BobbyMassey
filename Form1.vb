Public Class Form1
    Public Property rbGourmetCheese As RadioButton
    Public Property rbPinwheelWraps As RadioButton
    Public Property rbVeggie As RadioButton
    Public Property rbSausageCheese As RadioButton
    Public Property rbFruit As RadioButton
    Public Property rbPrePay As RadioButton
    Public Property rbPayUponPickup As RadioButton
    Public Property txtTotalPayment As TextBox
    Public Property txtLoyaltyPoints As TextBox
    Public Property txtLoyaltyPointsInput As TextBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sets the background color to Ginger Orange
        Me.BackColor = Color.FromArgb(255, 176, 101)

        'Create and position labels for "Catering" and "Star Market"
        Dim lblCatering As New Label
        lblCatering.Text = "Catering"
        lblCatering.Font = New Font(lblCatering.Font, FontStyle.Bold)
        lblCatering.Location = New Point(180, 20)
        Me.Controls.Add(lblCatering)

        Dim lblStarMarket As New Label
        lblStarMarket.Text = "Star Market"
        lblStarMarket.Font = New Font(lblStarMarket.Font, FontStyle.Bold)
        lblStarMarket.Location = New Point(160, 50)
        Me.Controls.Add(lblStarMarket)

        'Create and position picture box for the platter image
        Dim picPlatter As New PictureBox
        picPlatter.SizeMode = PictureBoxSizeMode.StretchImage
        picPlatter.Size = New Size(250, 180)
        picPlatter.Location = New Point(Me.Width - picPlatter.Width - 200, 20)
        Try
            picPlatter.Image = Image.FromFile("C:\Users\Bobby\platter.jpg")
        Catch ex As Exception
            MessageBox.Show("Error loading payroll image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Controls.Add(picPlatter)

        'Create and position radio buttons for food options inside a GroupBox with light orange background
        Dim gbFoodOptions As New GroupBox
        gbFoodOptions.Text = "Food Options:"
        gbFoodOptions.Font = New Font(gbFoodOptions.Font, FontStyle.Bold)
        gbFoodOptions.Location = New Point(100, 90)
        gbFoodOptions.Size = New Size(200, 160)
        gbFoodOptions.BackColor = Color.FromArgb(255, 206, 154) 'Light orange background color
        Me.Controls.Add(gbFoodOptions)

        'Create and position radio buttons for food options
        rbGourmetCheese = New RadioButton
        rbGourmetCheese.Text = "Gourmet Cheese $49.99"
        rbGourmetCheese.AutoSize = True
        rbGourmetCheese.Location = New Point(10, 20)
        gbFoodOptions.Controls.Add(rbGourmetCheese)

        rbPinwheelWraps = New RadioButton
        rbPinwheelWraps.Text = "Pinwheel Wraps $59.99"
        rbPinwheelWraps.AutoSize = True
        rbPinwheelWraps.Location = New Point(10, 50)
        gbFoodOptions.Controls.Add(rbPinwheelWraps)

        rbVeggie = New RadioButton
        rbVeggie.Text = "Veggie $29.99"
        rbVeggie.AutoSize = True
        rbVeggie.Location = New Point(10, 80)
        gbFoodOptions.Controls.Add(rbVeggie)

        rbSausageCheese = New RadioButton
        rbSausageCheese.Text = "Sausage and Cheese $49.99"
        rbSausageCheese.AutoSize = True
        rbSausageCheese.Location = New Point(10, 110)
        gbFoodOptions.Controls.Add(rbSausageCheese)

        rbFruit = New RadioButton
        rbFruit.Text = "Fruit $29.99"
        rbFruit.AutoSize = True
        rbFruit.Location = New Point(10, 140)
        gbFoodOptions.Controls.Add(rbFruit)

        'Create and position radio buttons for payment options inside a GroupBox with light orange background
        Dim gbPaymentOptions As New GroupBox
        gbPaymentOptions.Text = "Payment Options:"
        gbPaymentOptions.Font = New Font(gbPaymentOptions.Font, FontStyle.Bold)
        gbPaymentOptions.Location = New Point(140, 280)
        gbPaymentOptions.Size = New Size(200, 90)
        gbPaymentOptions.BackColor = Color.FromArgb(255, 206, 154) 'Light orange background color
        Me.Controls.Add(gbPaymentOptions)

        'Create and position radio buttons for payment options
        rbPrePay = New RadioButton
        rbPrePay.Text = "Pre-Pay"
        rbPrePay.Location = New Point(10, 20)
        gbPaymentOptions.Controls.Add(rbPrePay)

        rbPayUponPickup = New RadioButton
        rbPayUponPickup.Text = "Pay upon Pickup"
        rbPayUponPickup.Location = New Point(10, 50)
        gbPaymentOptions.Controls.Add(rbPayUponPickup)

        'Create and position textbox for total payment
        txtTotalPayment = New TextBox
        txtTotalPayment.Text = "Please Pay:"
        txtTotalPayment.Font = New Font(txtTotalPayment.Font, FontStyle.Bold)
        txtTotalPayment.Location = New Point(100, 400)
        txtTotalPayment.ReadOnly = True
        txtTotalPayment.Width = 100
        Me.Controls.Add(txtTotalPayment)

        'Create and position textbox for loyalty points
        txtLoyaltyPoints = New TextBox
        txtLoyaltyPoints.Text = "Loyalty Points: "
        txtLoyaltyPoints.Location = New Point(Me.Width - 200, 400)
        txtLoyaltyPoints.BackColor = Color.FromArgb(255, 176, 101) 'Ginger Orange background color
        Me.Controls.Add(txtLoyaltyPoints)

        'Create and position textbox for loyalty points input
        txtLoyaltyPointsInput = New TextBox
        txtLoyaltyPointsInput.Location = New Point(Me.Width - 100, 400)
        txtLoyaltyPointsInput.BackColor = Color.FromArgb(255, 176, 101) 'Ginger Orange background color
        Me.Controls.Add(txtLoyaltyPointsInput)

        ' Center the loyalty points textboxes to the right underneath the platter.jpg
        Dim platterLocation = picPlatter.Location
        Dim platterSize = picPlatter.Size
        Dim loyaltyPointsWidth = txtLoyaltyPoints.Width + txtLoyaltyPointsInput.Width
        Dim xOffset = (platterSize.Width - loyaltyPointsWidth) / 2
        txtLoyaltyPoints.Location = New Point(platterLocation.X + xOffset, platterLocation.Y + platterSize.Height + 10)
        txtLoyaltyPointsInput.Location = New Point(txtLoyaltyPoints.Location.X + txtLoyaltyPoints.Width, txtLoyaltyPoints.Location.Y)

        'Create and position buttons for calculate and clear
        Dim btnCalculate As New Button
        btnCalculate.Text = "Calculate"
        btnCalculate.Location = New Point(txtLoyaltyPoints.Location.X, txtLoyaltyPoints.Location.Y + txtLoyaltyPoints.Height + 40)
        Me.Controls.Add(btnCalculate)
        AddHandler btnCalculate.Click, AddressOf btnCalculate_Click

        Dim btnClear As New Button
        btnClear.Text = "Clear"
        btnClear.Location = New Point(txtLoyaltyPointsInput.Location.X, txtLoyaltyPointsInput.Location.Y + txtLoyaltyPointsInput.Height + 40)
        Me.Controls.Add(btnClear)
        AddHandler btnClear.Click, AddressOf btnClear_Click
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        'Clear points textbox and sets focus
        txtLoyaltyPointsInput.Clear()
        txtLoyaltyPointsInput.Focus()

        'Clear payment display label
        txtTotalPayment.Text = "Please Pay: "

        'Returns state of all radio buttons to default
        rbGourmetCheese.Checked = False
        rbPinwheelWraps.Checked = False
        rbVeggie.Checked = False
        rbSausageCheese.Checked = False
        rbFruit.Checked = False
        rbPrePay.Checked = False
        rbPayUponPickup.Checked = False

        'Change txtTotalPayment width back after clearing
        txtTotalPayment.Width = 100
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs)
        'Determines the cost of the platter selected
        Dim platterCost As Decimal = 0
        If rbGourmetCheese.Checked Then
            platterCost = 49.99
        ElseIf rbPinwheelWraps.Checked Then
            platterCost = 59.99
        ElseIf rbVeggie.Checked Then
            platterCost = 29.99
        ElseIf rbSausageCheese.Checked Then
            platterCost = 49.99
        ElseIf rbFruit.Checked Then
            platterCost = 29.99
        End If

        'Check if loyalty points input is a valid number
        Dim loyaltyPointsInput As String = txtLoyaltyPointsInput.Text.Trim()
        Dim loyaltyPoints As Integer
        If Not Integer.TryParse(loyaltyPointsInput, loyaltyPoints) Then
            MessageBox.Show("Please enter a valid number for loyalty points.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoyaltyPointsInput.Clear()
            txtLoyaltyPointsInput.Focus()
            Return
        End If

        'Calculate the discount based on loyalty points
        Dim discount As Decimal = loyaltyPoints * 0.01

        'Calculate the final price after discount
        Dim finalPrice As Decimal = platterCost - (platterCost * discount)

        'Check if the final price is zero or negative
        If finalPrice <= 0 Then
            MessageBox.Show("The loyalty points entered cannot be used for this order.", "Invalid Loyalty Points", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoyaltyPointsInput.Clear()
            txtLoyaltyPointsInput.Focus()
            Return
        End If

        'Change txtTotalPayment width after calculation
        txtTotalPayment.Width = 820

        'Format the payment information string
        Dim paymentInfo As String = $"Your order {GetPlatterName()} costs ${finalPrice.ToString("F2")} using {GetPaymentOption()} after a discount of {loyaltyPoints} loyalty points."

        'Display the payment information in the label
        txtTotalPayment.Text = $"Please Pay: {paymentInfo}"
    End Sub

    'Helper function to get the selected platter name
    Private Function GetPlatterName() As String
        If rbGourmetCheese.Checked Then
            Return "Gourmet Cheese Platter"
        ElseIf rbPinwheelWraps.Checked Then
            Return "Pinwheel Wraps Platter"
        ElseIf rbVeggie.Checked Then
            Return "Veggie Platter"
        ElseIf rbSausageCheese.Checked Then
            Return "Sausage and Cheese Platter"
        ElseIf rbFruit.Checked Then
            Return "Fruit Platter"
        Else
            Return ""
        End If
    End Function

    'Helper function to get the selected payment option
    Private Function GetPaymentOption() As String
        If rbPrePay.Checked Then
            Return "Pre-Pay"
        ElseIf rbPayUponPickup.Checked Then
            Return "Pay upon Pickup"
        Else
            Return ""
        End If
    End Function
End Class