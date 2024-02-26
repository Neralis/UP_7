namespace UP_7
{
    public partial class Form1 : Form
    {
        int Min = 0;
        int Max = 10;
        int[] array = new int[10];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }

            string arrayString = string.Join(", ", array);
            textBox1.Text = arrayString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                string condition = radioButton1.Checked ? "<" : (radioButton2.Checked ? ">" : "=");

                int referenceValue;

                if (int.TryParse(textBox2.Text, out referenceValue))
                {
                    int[] resultArray = ProcessArray(array, condition, referenceValue);
                    textBox3.Text = string.Join(", ", resultArray);

                    int count = resultArray.Length;
                    label3.Text = $"���������� �� ���. : {count}";

                    int sum = resultArray.Sum();
                    label4.Text = $"�����: {sum}";
                    int product = resultArray.Aggregate(1, (acc, x) => acc * x);
                    label5.Text = $"������������: {product}";

                    // ����� ������������� ��������
                    int min = resultArray.Min();
                    int max = resultArray.Max();
                    label6.Text = $"������������� ��������: {min}; {max}";
                }
                else
                {
                    MessageBox.Show("������� ���������� �������� ��� ���������.");
                }
            }
            else
            {
                MessageBox.Show("�������� ������� ��� ��������� �������.");
            }
        }

        private int[] ProcessArray(int[] array, string condition, int referenceValue)
        {
            switch (condition)
            {
                case "<":
                    return array.Where(x => x < referenceValue).ToArray();
                case ">":
                    return array.Where(x => x > referenceValue).ToArray();
                case "=":
                    return array.Where(x => x == referenceValue).ToArray();
                default:
                    throw new ArgumentException("������������ �������");
            }
        }
    }
}
