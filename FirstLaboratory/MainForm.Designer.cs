namespace CipherLab
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtExample = new System.Windows.Forms.TextBox();
            this.btnHack = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblInput.Location = new System.Drawing.Point(20, 20);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(165, 28);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Исходный текст:";
       
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput.Location = new System.Drawing.Point(20, 50);
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(520, 180);
            this.txtInput.BackColor = System.Drawing.Color.White;
            this.txtInput.Name = "txtInput";
            this.txtInput.TabIndex = 1;
          
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblKey.Location = new System.Drawing.Point(20, 245);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(56, 25);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Ключ:";
         
            this.txtKey.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKey.Location = new System.Drawing.Point(20, 270);
            this.txtKey.Size = new System.Drawing.Size(520, 30);
            this.txtKey.BackColor = System.Drawing.Color.White;
            this.txtKey.Name = "txtKey";
            this.txtKey.TabIndex = 3;
      
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.Location = new System.Drawing.Point(20, 315);
            this.btnGenerate.Size = new System.Drawing.Size(160, 40);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = false;
          
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.Location = new System.Drawing.Point(195, 315);
            this.btnEncrypt.Size = new System.Drawing.Size(160, 40);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.TabIndex = 5;
            this.btnEncrypt.Text = "Зашифровать";
            this.btnEncrypt.UseVisualStyleBackColor = false;
        
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnDecrypt.ForeColor = System.Drawing.Color.Black;
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.FlatAppearance.BorderSize = 0;
            this.btnDecrypt.Location = new System.Drawing.Point(370, 315);
            this.btnDecrypt.Size = new System.Drawing.Size(160, 40);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "Расшифровать";
            this.btnDecrypt.UseVisualStyleBackColor = false;
         
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblResult.Location = new System.Drawing.Point(20, 370);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(103, 28);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Результат:";
        
            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtResult.Location = new System.Drawing.Point(20, 400);
            this.txtResult.Multiline = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(520, 250);
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Name = "txtResult";
            this.txtResult.TabIndex = 8;
    
            this.txtExample.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExample.Location = new System.Drawing.Point(570, 50);
            this.txtExample.Multiline = true;
            this.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExample.Size = new System.Drawing.Size(600, 560);
            this.txtExample.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExample.ReadOnly = true;
            this.txtExample.Name = "txtExample";
            this.txtExample.TabIndex = 9;
    
            this.btnHack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHack.ForeColor = System.Drawing.Color.White;
            this.btnHack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHack.FlatAppearance.BorderSize = 0;
            this.btnHack.Location = new System.Drawing.Point(570, 620);
            this.btnHack.Size = new System.Drawing.Size(600, 45);
            this.btnHack.Name = "btnHack";
            this.btnHack.TabIndex = 10;
            this.btnHack.Text = "Взломать";
            this.btnHack.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Text = "Шифр одноалфавитной замены";
            this.Name = "MainForm";

            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            this.btnHack.Click += new System.EventHandler(this.btnHack_Click);

            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtExample);
            this.Controls.Add(this.btnHack);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtExample;
        private System.Windows.Forms.Button btnHack;
    }
}