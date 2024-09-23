using System;
using System.Collections.Generic;

class MathStack
{
    // Основной метод для вычисления выражения
    public static double EvaluateExpression(string expression)
    {
        // Преобразуем инфиксную запись в постфиксную (обратная польская нотация)
        string[] postfix = InfixToPostfix(expression);
        // Вычисляем результат выражения в постфиксной нотации
        return EvaluatePostfix(postfix);
    }

    public static string[] InfixToPostfix(string expression)
    {
        Stack<char> operators = new Stack<char>();
        List<string> output = new List<string>();
        int i = 0;

        while (i < expression.Length)
        {
            char c = expression[i];

            if (char.IsDigit(c))
            {
                string number = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    number += expression[i];
                    i++;
                }
                output.Add(number);
                continue;
            }
            else if (c == '(')
            {
                operators.Push(c);
            }
            else if (c == ')')
            {
                while (operators.Peek() != '(')
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Pop(); 
            }
            else if (IsOperator(c))
            {
                while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(c))
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Push(c);
            }

            i++;
        }

        while (operators.Count > 0)
        {
            output.Add(operators.Pop().ToString());
        }

        return output.ToArray();
    }

    public static double EvaluatePostfix(string[] postfix)
    {
        Stack<double> stack = new Stack<double>();

        foreach (string token in postfix)
        {
            double number;
            if (double.TryParse(token, out number))
            {
                stack.Push(number);
            }
            else if (IsOperator(token[0]))
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(ApplyOperator(a, b, token[0]));
            }
        }

        return stack.Pop();
    }

    public static double ApplyOperator(double a, double b, char op)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                return a / b;
            default:
                throw new InvalidOperationException("Неизвестный оператор");
        }
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    public static int Priority(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }
}

