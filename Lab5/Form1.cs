namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lstResult.Items.Clear();

            char[] separators = new[] { ' ', '\r', '\n', ',', '.', ';', ':' };
            string[] rawEntries = txtInput.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var words = rawEntries
                .Where(w => w.All(c => char.IsLetter(c)))
                .ToArray();

            if (words.Length == 0)
            {
                MessageBox.Show("Введіть коректні слова!");
                return;
            }

            string alphabetFirst = words.Min();

            lstResult.Items.Add("Завдання А");
            lstResult.Items.Add($"Перше слово за алфавітом: {alphabetFirst}");
            lstResult.Items.Add("");

            lstResult.Items.Add("Завдання Б");
            lstResult.Items.Add("Слова з двома літерами 'd':");

            bool foundD = false;
            foreach (string word in words)
            {
                int count = word.ToLower().Count(c => c == 'd');

                if (count == 2)
                {
                    lstResult.Items.Add(word);
                    foundD = true;
                }
            }

            if (!foundD) lstResult.Items.Add("Слів із двома літерами 'd' не знайдено");
        }
    }
}
