using PhysicsTesting.Services;

namespace PhysicsTesting.Forms
{
    public partial class ResultsForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private readonly TestManager _testManager = new();

        public ResultsForm(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            LoadTopics();
            LoadAllResults();
        }

        private void LoadTopics()
        {
            var topics = _testManager.GetTopics();
            var topicsList = new List<string> { "Все темы" };
            topicsList.AddRange(topics);
            cmbFilterTopic.DataSource = topicsList;
            cmbFilterTopic.SelectedIndex = 0;
        }

        private void LoadAllResults()
        {
            var results = _databaseManager.GetAllResults();
            BindResults(results);
        }

        private void BindResults(List<Models.TestResult> results)
        {
            dgvResults.DataSource = null;
            dgvResults.DataSource = results.Select(r => new
            {
                r.StudentName,
                r.Topic,
                ПравильныхОтветов = $"{r.CorrectAnswers}/{r.TotalQuestions}",
                Процент = $"{r.Percentage:F1}%",
                r.Grade,
                Время = $"{r.Duration.Minutes:D2}:{r.Duration.Seconds:D2}",
                r.Date
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Введите фамилию для поиска", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = _databaseManager.GetResultsByStudent(txtSearch.Text);
            BindResults(results);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterTopic.SelectedIndex = 0;
            LoadAllResults();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите результат для удаления", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = DialogResult.Yes == MessageBox.Show("Вы уверены?", "Подтверждение", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (!result) return;

            foreach (DataGridViewRow row in dgvResults.SelectedRows)
            {
                if (int.TryParse(row.Index.ToString(), out int id))
                {
                    _databaseManager.DeleteResult(id);
                }
            }

            LoadAllResults();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
