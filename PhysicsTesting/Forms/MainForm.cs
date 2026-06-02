using PhysicsTesting.Services;

namespace PhysicsTesting.Forms
{
    public partial class MainForm : Form
    {
        private readonly TestManager _testManager = new();
        private readonly DatabaseManager _databaseManager = new();

        public MainForm()
        {
            InitializeComponent();
            LoadTopics();
        }

        private void LoadTopics()
        {
            cmbTopic.DataSource = _testManager.GetTopics();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Пожалуйста, введите ФИО ученика", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTopic.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тему", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var testForm = new TestForm(txtFullName.Text, cmbTopic.SelectedItem.ToString() ?? "", 
                _testManager, _databaseManager);
            testForm.ShowDialog();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm(_databaseManager);
            resultsForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
