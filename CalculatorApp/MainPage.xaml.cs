namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        double input1;
        double input2;
        string currentInput;
        bool secondInput = false;
        char currentOperation;
        double Output;

        public MainPage()
        {
            InitializeComponent();
            currentInput = string.Empty;
            input1 = 0;
            input2 = 0;
            currentOperation = ' ';

        }

        void SecondInputCheck()
        {
            if (secondInput == false)
            {
                ConvertToDouble();
                secondInput = true;
                InputBox.Text = " ";
                currentInput = "";
            }
            else if (secondInput == true)
            {
                PerformOperation();
                input2 = 0;

            }
        }

        void ConvertToDouble()
        {
            if (input1 == 0 && input2 == 0)
            {
                input1 = double.Parse(InputBox.Text);
            }
            else
            {
                input1 = double.Parse(currentInput);

            }
        }

        void AppendToInput(string value)
        {
            currentInput += value;
            DisplayInput();
        }

        void DisplayInput()
        {
            InputBox.Text = currentInput;
        }

        void ResetCalculator()
        {
            input1 = 0;
            input2 = 0;
            currentOperation = ' ';
            secondInput = false;
        }

        void PerformOperation()
        {
            if (double.TryParse(currentInput, out input2))
            {
                switch (currentOperation)
                {
                    case '+':
                        input1 += input2;
                        break;
                    case '-':
                        input1 -= input2;
                        break;
                    case '*':
                        input1 *= input2;
                        break;
                    case '/':
                        if (input2 != 0)
                            input1 /= input2;
                        else
                        {
                            ResetCalculator();
                            InputBox.Text = "Error";
                            return;
                        }
                        break;

                    default:
                        break;
                }
                Output = input1;
                InputBox.Text = Output.ToString();
                currentInput = "";
            }
        }


        private void ButtonEqual_Clicked(object sender, EventArgs e)
        {
            PerformOperation();
            ResetCalculator();
        }

        private void ButtonDot_Clicked(object sender, EventArgs e)
        {
            AppendToInput(".");
        }

        private void ButtonZero_Clicked(object sender, EventArgs e)
        {
            AppendToInput("0");
        }

        private void ButtonPlus_Clicked(object sender, EventArgs e)
        {
            SecondInputCheck();
            currentOperation = '+';
        }

        private void ButtonThree_Clicked(object sender, EventArgs e)
        {
            AppendToInput("3");
        }

        private void ButtonTwo_Clicked(object sender, EventArgs e)
        {
            AppendToInput("2");
        }

        private void ButtonOne_Clicked(object sender, EventArgs e)
        {
            AppendToInput("1");
        }

        private void ButtonMinus_Clicked(object sender, EventArgs e)
        {
            SecondInputCheck();
            currentOperation = '-';
        }

        private void ButtonSix_Clicked(object sender, EventArgs e)
        {
            AppendToInput("6");
        }

        private void ButtonFive_Clicked(object sender, EventArgs e)
        {
            AppendToInput("5");
        }

        private void ButtonFour_Clicked(object sender, EventArgs e)
        {
            AppendToInput("4");
        }

        private void ButtonMultiply_Clicked(object sender, EventArgs e)
        {
            SecondInputCheck();
            currentOperation = '*';
        }

        private void ButtonNine_Clicked(object sender, EventArgs e)
        {
            AppendToInput("9");
        }

        private void ButtonEight_Clicked(object sender, EventArgs e)
        {
            AppendToInput("8");
        }

        private void ButtonSeven_Clicked(object sender, EventArgs e)
        {
            AppendToInput("7");
        }

        private void ButtonDivide_Clicked(object sender, EventArgs e)
        {
            SecondInputCheck();
            currentOperation = '/';
        }

        private void ButtonPercent_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double currentValue))
            {
                currentValue /= 100;
                currentInput = currentValue.ToString();
                DisplayInput();
            }
        }

        private void ButtonPositiveNegative_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double currentValue))
            {
                currentValue *= -1;
                currentInput = currentValue.ToString();
                DisplayInput();
            }
        }

        private void ButtonClear_Clicked(object sender, EventArgs e)
        {
            input1 = 0;
            input2 = 0;
            currentInput = "";
            currentOperation = ' ';
            secondInput = false;
            DisplayInput();
        }
    }
    

}
