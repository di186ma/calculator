using System;

namespace CalculatorLogic
{
    public class Calculations
    {

        private static int ReadOperand(string input, int i)
        {
            bool digitflag = false;
            if (input[i] == '-')
            {
                i++;
            }
            while (input[i] is '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' or ',')
            {
                if (input[i] is ',')
                {
                    if (digitflag is false)
                    {
                        digitflag = true;
                    }
                    else
                    {
                        return -1;
                    }
                }
                i++;
            }
            return i;
        }

        public static string Calculate(string input)
        {
            string operand1, operand2, expr = input;
            char op = '\0';
            int i, n;
            double num1, num2, result = 0;
            input += '\0';
            while (true)
            {
                i = 0;
                n = 0;
                i = ReadOperand(input, i);
                if (i == -1)
                {
                    throw new Exception("Ошибка в выражении!");
                }
                if (input[i] is '\0')
                {
                    if (op is '\0')
                    {
                        throw new ArgumentException("Выражение осталось неизменным.");
                    }
                    else
                    {
                        break;
                    }
                }
                operand1 = input[0..i];
                if (string.IsNullOrEmpty(operand1))
                {
                    throw new Exception("Ошибка в выражении!");
                }
                op = input[i++];
                if (op is not '+' and not '-' and not '*' and not '/')
                {
                    throw new Exception("Ошибка в выражении!");
                }
                n = i;
                i = ReadOperand(input, i);
                if (i == -1)
                {
                    throw new Exception("Ошибка в выражении!");
                }
                operand2 = input[(operand1.Length + 1)..i];
                if (string.IsNullOrEmpty(operand2))
                {
                    throw new Exception("Ошибка в выражении!");
                }
                if (input[i] is '/' or '*')
                {
                    op = input[i++];
                    n = i;
                    operand1 = operand2;
                    i = ReadOperand(input, i);
                    if (i == -1)
                    {
                        throw new Exception("Ошибка в выражении!");
                    }
                    operand2 = input[n..i];
                    if (string.IsNullOrEmpty(operand2))
                    {
                        throw new Exception("Ошибка в выражении!");
                    }
                }
                double.TryParse(operand1, out num1);
                double.TryParse(operand2, out num2);
                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                }
                input = input.Replace(input[(n - operand1.Length - 1)..i], result.ToString());
            }
            input = input.Remove(input.Length - 1, 1);
            return input;
        }
    }
}
