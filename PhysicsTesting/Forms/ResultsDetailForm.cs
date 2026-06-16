using PhysicsTesting.Models;

namespace PhysicsTesting.Forms
{
    public partial class ResultsDetailForm : Form
    {
        private readonly TestResult _result;

        public ResultsDetailForm(TestResult result)
        {
            InitializeComponent();
            _result = result;
            DisplayResults();
        }

        private void DisplayResults()
        {
            lblStudentValue.Text = _result.StudentName;
            lblTopicValue.Text = _result.Topic;
            lblCorrectAnswersValue.Text = $"{_result.CorrectAnswers}/{_result.TotalQuestions}";
            lblPercentageValue.Text = $"{_result.Percentage:F1}%";
            lblGradeValue.Text = _result.Grade.ToString();
            lblDurationValue.Text = $"{_result.Duration.Minutes:D2}:{_result.Duration.Seconds:D2}";

            // Смена цвета оценки в зависимости от значения
            if (_result.Grade >= 8)
                lblGradeValue.ForeColor = System.Drawing.Color.FromArgb(0, 153, 76); // Зелёный
            else if (_result.Grade >= 5)
                lblGradeValue.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7); // Жёлтый
            else
                lblGradeValue.ForeColor = System.Drawing.Color.FromArgb(204, 0, 0); // Красный
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
