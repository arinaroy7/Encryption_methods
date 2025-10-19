using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SecondLaboratory_ADFGVX.Core;

namespace SecondLaboratory_ADFGVX
{
    public partial class Form1 : Form
    {
        private readonly CipherService cipher = new CipherService();

        public Form1()
        {
            InitializeComponent();
        }

        private string NormalizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = text.ToLowerInvariant();
            return Regex.Replace(text, @"[^а-яё\s]", ""); 
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = NormalizeText(txtInput.Text ?? "");
            string key = (txtKey.Text ?? "").ToLowerInvariant();

            txtResult.Text = cipher.Encrypt(input, key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string input = (txtInput.Text ?? "").ToLowerInvariant().Trim();
            string key = (txtKey.Text ?? "").ToLowerInvariant();

            txtResult.Text = cipher.Decrypt(input, key);
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKey.Text = cipher.GenerateKey();
        }
    }
}
