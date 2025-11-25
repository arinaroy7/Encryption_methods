using System;
using System.Windows.Forms;
using Backend.Services;

namespace FourthLaboratory_StreamEncryption
{
    public partial class Form1 : Form
    {
        private readonly CipherService _cipher = new CipherService();
        private System.ComponentModel.IContainer components = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblInput = new Label();
            this.txtInput = new TextBox();
            this.txtKey = new TextBox();
            this.btnEncrypt = new Button();
            this.btnDecrypt = new Button();
            this.btnGenerateKey = new Button();
            this.lblResult = new Label();
            this.txtResult = new TextBox();
            this.SuspendLayout();

            this.lblInput.AutoSize = true;
            this.lblInput.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblInput.Location = new Point(20, 70);
            this.lblInput.Text = "Введите текст для шифрования/дешифрования:";

            this.txtInput.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtInput.Location = new Point(20, 100);
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = ScrollBars.Vertical;
            this.txtInput.Size = new Size(790, 140);
            this.txtInput.BackColor = Color.FromArgb(240, 248, 255);

            this.btnGenerateKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGenerateKey.BackColor = Color.FromArgb(255, 240, 245);
            this.btnGenerateKey.ForeColor = Color.Black;
            this.btnGenerateKey.FlatStyle = FlatStyle.Flat;
            this.btnGenerateKey.Location = new Point(20, 250);
            this.btnGenerateKey.Size = new Size(220, 38);
            this.btnGenerateKey.Text = "Сгенерировать ключ";
            this.btnGenerateKey.Click += new EventHandler(this.btnGenerateKey_Click);

            this.txtKey.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtKey.Location = new Point(20, 305);
            this.txtKey.Size = new Size(300, 28);
            this.txtKey.BackColor = Color.FromArgb(240, 248, 255);
            this.txtKey.PlaceholderText = "Сгенерируйте или введите ключ";

            this.btnEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEncrypt.BackColor = Color.FromArgb(46, 204, 113);
            this.btnEncrypt.ForeColor = Color.White;
            this.btnEncrypt.FlatStyle = FlatStyle.Flat;
            this.btnEncrypt.Location = new Point(350, 300);
            this.btnEncrypt.Size = new Size(150, 38);
            this.btnEncrypt.Text = "Зашифровать";
            this.btnEncrypt.Click += new EventHandler(this.btnEncrypt_Click);

            this.btnDecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnDecrypt.BackColor = Color.FromArgb(52, 152, 219);
            this.btnDecrypt.ForeColor = Color.White;
            this.btnDecrypt.FlatStyle = FlatStyle.Flat;
            this.btnDecrypt.Location = new Point(510, 300);
            this.btnDecrypt.Size = new Size(150, 38);
            this.btnDecrypt.Text = "Дешифровать";
            this.btnDecrypt.Click += new EventHandler(this.btnDecrypt_Click);

            this.lblResult.AutoSize = true;
            this.lblResult.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblResult.Location = new Point(20, 345);
            this.lblResult.Text = "Результат:";

            this.txtResult.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtResult.Location = new Point(20, 375);
            this.txtResult.Multiline = true;
            this.txtResult.ScrollBars = ScrollBars.Vertical;
            this.txtResult.Size = new Size(790, 140);
            this.txtResult.ReadOnly = true;
            this.txtResult.BackColor = Color.FromArgb(240, 248, 255);

            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(850, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnGenerateKey);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №4: Поточный шифр";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            try
            {
                string key = _cipher.GenerateKey();
                txtKey.Text = key;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации ключа:\n{ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtInput.Text.Trim();
                string key = txtKey.Text.Trim();

                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Введите или сгенерируйте ключ!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("Введите текст для шифрования!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string encrypted = _cipher.Encrypt(text, key);
                txtResult.Text = encrypted;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: ключ не является валидной Base64-строкой.\n" +
                    "Убедитесь, что ключ был сгенерирован программой или скопирован без пробелов.", 
                    "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка шифрования:\n{ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string cipherText = txtInput.Text.Trim();
                string key = txtKey.Text.Trim();

                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Введите или сгенерируйте ключ!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cipherText))
                {
                    MessageBox.Show("Введите шифротекст для дешифрования!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string decrypted = _cipher.Decrypt(cipherText, key);
                txtResult.Text = decrypted;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: введённый текст не является валидным Base64.\n" +
                    "Убедитесь, что это результат шифрования.\n" +
                    "• Проверьте, нет ли пробелов в начале/конце введенного текста.", 
                    "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при дешифровании:\n{ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label lblTitle;
        private Label lblInput;
        private TextBox txtInput;
        private TextBox txtKey;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblResult;
        private TextBox txtResult;
        private Button btnGenerateKey;
    }
}