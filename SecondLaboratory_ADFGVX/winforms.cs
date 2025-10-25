﻿using System.Windows.Forms;

namespace SecondLaboratory_ADFGVX
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

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
                this.txtExample = new TextBox();
                this.SuspendLayout();

                this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
                this.lblTitle.ForeColor = Color.FromArgb(40, 40, 80);
                this.lblTitle.Location = new Point(20, 15);
                this.lblTitle.Size = new Size(800, 40);
                this.lblTitle.Text = "ADFGVX";
                this.lblInput.AutoSize = true;
                this.lblInput.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                this.lblInput.Location = new Point(20, 70);
                this.lblInput.Text = "Исходный текст:";

                this.txtInput.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
                this.txtInput.Location = new Point(20, 100);
                this.txtInput.Multiline = true;
                this.txtInput.ScrollBars = ScrollBars.Vertical;
                this.txtInput.Size = new Size(790, 140);
                this.txtInput.BackColor = Color.White;

                this.btnGenerateKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                this.btnGenerateKey.BackColor = Color.FromArgb(241, 196, 15);
                this.btnGenerateKey.ForeColor = Color.Black;
                this.btnGenerateKey.FlatStyle = FlatStyle.Flat;
                this.btnGenerateKey.Location = new Point(20, 250);
                this.btnGenerateKey.Size = new Size(200, 38);
                this.btnGenerateKey.Text = "Сгенерировать ключ";
                this.btnGenerateKey.Click += new EventHandler(this.btnGenerateKey_Click);

                this.txtKey.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
                this.txtKey.Location = new Point(20, 295);
                this.txtKey.Size = new Size(250, 28);
                this.txtKey.BackColor = Color.White;

                this.btnEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                this.btnEncrypt.BackColor = Color.FromArgb(46, 204, 113);
                this.btnEncrypt.ForeColor = Color.White;
                this.btnEncrypt.FlatStyle = FlatStyle.Flat;
                this.btnEncrypt.Location = new Point(290, 290);
                this.btnEncrypt.Size = new Size(150, 38);
                this.btnEncrypt.Text = "Зашифровать";
                this.btnEncrypt.Click += new EventHandler(this.btnEncrypt_Click);

                this.btnDecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                this.btnDecrypt.BackColor = Color.FromArgb(52, 152, 219);
                this.btnDecrypt.ForeColor = Color.White;
                this.btnDecrypt.FlatStyle = FlatStyle.Flat;
                this.btnDecrypt.Location = new Point(460, 290);
                this.btnDecrypt.Size = new Size(150, 38);
                this.btnDecrypt.Text = "Дешифровать";
                this.btnDecrypt.Click += new EventHandler(this.btnDecrypt_Click);

                this.lblResult.AutoSize = true;
                this.lblResult.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                this.lblResult.Location = new Point(20, 335);
                this.lblResult.Text = "Результат:";

                this.txtResult.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
                this.txtResult.Location = new Point(20, 365);
                this.txtResult.Multiline = true;
                this.txtResult.ScrollBars = ScrollBars.Vertical;
                this.txtResult.Size = new Size(790, 160);
                this.txtResult.ReadOnly = true;
                this.txtResult.BackColor = Color.WhiteSmoke;

                this.txtExample = new TextBox();
                this.txtExample.Font = new Font("Consolas", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                this.txtExample.Location = new Point(830, 100);
                this.txtExample.Multiline = true;
                this.txtExample.ScrollBars = ScrollBars.Vertical;
                this.txtExample.Size = new Size(420, 425);
                this.txtExample.ReadOnly = true;
                this.txtExample.BackColor = Color.WhiteSmoke;
                this.txtExample.Text = "Тестовые примеры, для которых в папке pictures есть ручные расчеты:\r\n\r\n" +
                "1.Введите слово: азбука\r\n\r\n" +
                "Ключ: ключ\r\n\r\n" +
                "Ожидаемый результат: adxaaddgaffa";

                this.AutoScaleDimensions = new SizeF(8F, 20F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new Size(1280, 550);
                this.Controls.Add(this.lblTitle);
                this.Controls.Add(this.lblInput);
                this.Controls.Add(this.txtInput);
                this.Controls.Add(this.txtKey);
                this.Controls.Add(this.btnGenerateKey);
                this.Controls.Add(this.btnEncrypt);
                this.Controls.Add(this.btnDecrypt);
                this.Controls.Add(this.lblResult);
                this.Controls.Add(this.txtResult);
                this.Controls.Add(this.txtExample);
                this.BackColor = Color.FromArgb(245, 247, 250);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Text = "Лабораторная работа №2: шифр 1 Мировой войны";
                this.ResumeLayout(false);
                this.PerformLayout();
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
            private TextBox txtExample;
    }
}