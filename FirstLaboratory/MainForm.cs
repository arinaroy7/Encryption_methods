using System;
using System.Windows.Forms;

namespace CipherLab
{
    public partial class MainForm : Form
    {
        private readonly alphabeticCipher _cipher = new alphabeticCipher();
        public MainForm()
        {
            InitializeComponent();

            txtExample.Text = "Введите исходный текст:\r\n\r\nСавельич поглядел на меня с глубокой горестью и пошел за моим долгом. " +
                              "Мне было жаль бедного старика; но я хотел вырваться на волю и доказать, что уж я не ребенок. " +
                              "Деньги были доставлены Зурину. Савельич поспешил вывезти меня из проклятого трактира. " +
                              "Он явился с известием, что лошади готовы. С неспокойной совестию и с безмолвным раскаянием " +
                              "выехал я из Симбирска, не простясь с моим учителем и не думая с ним уже когда-нибудь увидеться.\r\n\r\n" +
                              "* После взлома программа попытается восстановить ключ методом частотного анализа: " +
                              "она анализирует, как часто встречаются буквы в зашифрованном тексте. Самые " +
                              "частые буквы в шифротексте сопоставляются с самыми частыми буквами русского языка " +
                              "(например, «о», «е», «а»). На основе этого строится предполагаемый ключ, с помощью которого " +
                              "текст расшифровывается. ";
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtKey.Text = _cipher.CreateRandomKey();
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = _cipher.EncryptText(txtInput.Text.ToLower(), txtKey.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = _cipher.DecryptText(txtInput.Text.ToLower(), txtKey.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void btnHack_Click(object sender, EventArgs e)
        {
            try
            {
                var (guessedKey, decrypted) = _cipher.HackDecrypt(txtInput.Text.ToLower());
                txtKey.Text = guessedKey;
                txtResult.Text = decrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при взломе: {ex.Message}");
            }
        }
    }
}