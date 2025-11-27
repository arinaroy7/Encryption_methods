using System;
using System.Windows.Forms;

namespace FifthLaboratory_RSA
{
    public partial class Form1 : Form
    {
        private readonly CipherService _rsa = new CipherService();
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
            this.lblInput = new Label();
            this.txtInput = new TextBox();
            this.txtKeys = new TextBox();
            this.btnGenerateKeys = new Button();
            this.btnEncrypt = new Button();
            this.btnDecrypt = new Button();
            this.lblResult = new Label();
            this.txtResult = new TextBox();

            this.SuspendLayout();

            this.lblInput.AutoSize = true;
            this.lblInput.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblInput.Location = new Point(20, 20);
            this.lblInput.Text = "Введите текст:";

            this.txtInput.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtInput.Location = new Point(20, 50);
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = ScrollBars.Vertical;
            this.txtInput.Size = new Size(790, 120);
            this.txtInput.BackColor = Color.FromArgb(240, 248, 255);

            this.btnGenerateKeys.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGenerateKeys.BackColor = Color.FromArgb(255, 240, 245);
            this.btnGenerateKeys.Location = new Point(20, 185);
            this.btnGenerateKeys.Size = new Size(220, 38);
            this.btnGenerateKeys.Text = "Сгенерировать ключ";
            this.btnGenerateKeys.Click += new EventHandler(this.btnGenerateKeys_Click);

            this.txtKeys.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtKeys.Location = new Point(20, 235);
            this.txtKeys.Size = new Size(500, 28);
            this.txtKeys.BackColor = Color.FromArgb(240, 248, 255);
            this.txtKeys.PlaceholderText = "n,e,d";

            this.btnEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEncrypt.BackColor = Color.FromArgb(46, 204, 113);
            this.btnEncrypt.ForeColor = Color.White;
            this.btnEncrypt.FlatStyle = FlatStyle.Flat;
            this.btnEncrypt.Location = new Point(540, 230);
            this.btnEncrypt.Size = new Size(140, 38);
            this.btnEncrypt.Text = "Зашифровать";
            this.btnEncrypt.Click += new EventHandler(this.btnEncrypt_Click);

            this.btnDecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnDecrypt.BackColor = Color.FromArgb(52, 152, 219);
            this.btnDecrypt.ForeColor = Color.White;
            this.btnDecrypt.FlatStyle = FlatStyle.Flat;
            this.btnDecrypt.Location = new Point(690, 230);
            this.btnDecrypt.Size = new Size(140, 38);
            this.btnDecrypt.Text = "Дешифровать";
            this.btnDecrypt.Click += new EventHandler(this.btnDecrypt_Click);

            this.lblResult.AutoSize = true;
            this.lblResult.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblResult.Location = new Point(20, 285);
            this.lblResult.Text = "Результат:";

            this.txtResult.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtResult.Location = new Point(20, 315);
            this.txtResult.Multiline = true;
            this.txtResult.ScrollBars = ScrollBars.Vertical;
            this.txtResult.Size = new Size(790, 170);
            this.txtResult.ReadOnly = true;
            this.txtResult.BackColor = Color.FromArgb(240, 248, 255);

            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(850, 520);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtKeys);
            this.Controls.Add(this.btnGenerateKeys);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №5: RSA";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            try
            {
                var keys = _rsa.GenerateKeys();
                txtKeys.Text = keys;
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
                string key = txtKeys.Text.Trim();

                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("Введите корректный ключ в формате n,e,d.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string result = _rsa.Encrypt(text, key);
                txtResult.Text = result;
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
                string text = txtInput.Text.Trim();
                string key = txtKeys.Text.Trim();

                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("Введите корректный ключ в формате n,e,d.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string result = _rsa.Decrypt(text, key);
                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка дешифрования:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label lblInput;
        private TextBox txtInput;
        private TextBox txtKeys;
        private Button btnGenerateKeys;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblResult;
        private TextBox txtResult;
    }
}