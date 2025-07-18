using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    // Cache for commonly used strings to reduce allocations
    private const string ResultPrefix = "SONUÇ=";
    private const string ErrorTitle = "ERROR";
    private const string ErrorMessage = "Girilen değerleri kontrol ediniz";
    
    public Form1()
    {
        InitializeComponent();
        
        // Optimize form loading
        SetStyle(ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.UserPaint | 
                 ControlStyles.DoubleBuffer, true);
        
        // Pre-validate input format
        textBox1.KeyPress += ValidateNumericInput;
        textBox2.KeyPress += ValidateNumericInput;
    }
    
    private void ValidateNumericInput(object? sender, KeyPressEventArgs e)
    {
        // Allow only numbers, decimal point, negative sign, and control keys
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && 
            e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-')
        {
            e.Handled = true;
        }
    }
    
    private bool TryGetInputValues(out decimal value1, out decimal value2)
    {
        value1 = 0;
        value2 = 0;
        
        // Use TryParse instead of Convert for better performance and error handling
        return decimal.TryParse(textBox1.Text, NumberStyles.Number, 
                               CultureInfo.CurrentCulture, out value1) &&
               decimal.TryParse(textBox2.Text, NumberStyles.Number, 
                               CultureInfo.CurrentCulture, out value2);
    }
    
    private void ShowResult(decimal result)
    {
        // Use string interpolation for better performance
        label3.Text = $"{ResultPrefix}{result}";
    }
    
    private void ShowFormattedResult(decimal result)
    {
        // Use string interpolation with format specifier
        label3.Text = $"{ResultPrefix}{result:N2}";
    }
    
    private void HandleInputError()
    {
        // Clear inputs and show error
        textBox1.Clear();
        textBox2.Clear();
        textBox1.Focus();
        
        // Use cached strings to reduce allocations
        MessageBox.Show(ErrorMessage, ErrorTitle, 
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (TryGetInputValues(out decimal sayi1, out decimal sayi2))
        {
            ShowResult(sayi1 + sayi2);
        }
        else
        {
            HandleInputError();
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (TryGetInputValues(out decimal sayi1, out decimal sayi2))
        {
            ShowResult(sayi1 - sayi2);
        }
        else
        {
            HandleInputError();
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (TryGetInputValues(out decimal sayi1, out decimal sayi2))
        {
            ShowResult(sayi1 * sayi2);
        }
        else
        {
            HandleInputError();
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (TryGetInputValues(out decimal sayi1, out decimal sayi2))
        {
            if (sayi2 == 0)
            {
                MessageBox.Show("Sıfıra bölme hatası!", ErrorTitle, 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowFormattedResult(sayi1 / sayi2);
        }
        else
        {
            HandleInputError();
        }
    }

    private void button5_Click(object sender, EventArgs e)
    {
        // Use double for Math.Pow operations
        if (double.TryParse(textBox1.Text, NumberStyles.Number, 
                           CultureInfo.CurrentCulture, out double sayi1) &&
            double.TryParse(textBox2.Text, NumberStyles.Number, 
                           CultureInfo.CurrentCulture, out double sayi2))
        {
            double result = Math.Pow(sayi1, sayi2);
            
            // Check for overflow or invalid results
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                MessageBox.Show("Sonuç çok büyük veya geçersiz!", ErrorTitle, 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            label3.Text = $"{ResultPrefix}{result}";
        }
        else
        {
            HandleInputError();
        }
    }
}
