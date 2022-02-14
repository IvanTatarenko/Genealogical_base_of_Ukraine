namespace Genealogical_base_of_Ukraine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.f1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParserReabit parserReabit = new ParserReabit();
            parserReabit.reabit();
        }

        private void console_box_TextChanged(object sender, EventArgs e)
        {
            console_box.SelectionStart = console_box.Text.Length;
            console_box.ScrollToCaret();
            console_box.Refresh();
        }
    }
}