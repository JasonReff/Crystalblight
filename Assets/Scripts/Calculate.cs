using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    public static int Calc(string equation)
    {
        //I do not know how fast or slow this code will preform
        Queue<int> operand1 = new Queue<int>();
        Queue<int> operand2 = new Queue<int>();
        Queue<int> operand3 = new Queue<int>();
        string operator1 = "none";
        string operator2 = "none";

        //string parsing section
        for (int i = 0; i < equation.Length; i++)
        {
            switch ((int)equation[i])
            {
                case 32:
                    // ' '
                    break;
                case 83:
                    // S
                    //this method only gets called if no stage number is given so a 0 is returned as an error
                    return 0;
                    break;
                case 43:
                    // +
                    if (operator1 == "null")
                    {
                        operator1 = "+";
                    }
                    else
                    {
                        operator2 = "+";
                    }
                    break;
                case 45:
                    // -
                    if (operator1 == "null")
                    {
                        operator1 = "-";
                    }
                    else
                    {
                        operator2 = "-";
                    }
                    break;
                case 42:
                    // *
                    if (operator1 == "null")
                    {
                        operator1 = "*";
                    }
                    else
                    {
                        operator2 = "*";
                    }
                    break;
                case 47:
                    // /
                    if (operator1 == "null")
                    {
                        operator1 = "/";
                    }
                    else
                    {
                        operator2 = "/";
                    }
                    break;
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    // 0 through 9
                    if (operator1 == "null")
                    {
                        operand1.Enqueue((int)equation[i] - 48);
                    }
                    else if (operator2 == "null")
                    {
                        operand2.Enqueue((int)equation[i] - 48);
                    }
                    else
                    {
                        operand3.Enqueue((int)equation[i] - 48);
                    }
                    break;
                default:
                    break;
            }
        }

        //math section
        int number1 = 0;
        int number2 = 0;
        int number3 = 0;
        int result = 0;
        while (operand1.Count != 0)
        {
            number1 = number1 * 10;
            number1 += operand1.Dequeue();
        }
        while (operand2.Count != 0)
        {
            number2 = number2 * 10;
            number2 += operand2.Dequeue();
        }
        while (operand3.Count != 0)
        {
            number3 = number3 * 10;
            number3 += operand3.Dequeue();
        }

        switch (operator1)
        {
            case "null":
                return number1;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                result = number1 / number2;
                break;
            case "+":
                if (operator2 != "*" && operator2 != "/")
                {
                    result = number1 + number2;
                }
                else if (operator2 == "*")
                {
                    return number1 + (number2 * number3);
                }
                else if (operator2 == "/")
                {
                    return number1 + (number2 / number3);
                }
                break;
            case "-":
                if (operator2 != "*" && operator2 != "/")
                {
                    result = number1 - number2;
                }
                else if (operator2 == "*")
                {
                    return number1 - (number2 * number3);
                }
                else if (operator2 == "/")
                {
                    return number1 - (number2 / number3);
                }
                break;
            default:
                break;
        }
        switch (operator2)
        {
            case "null":
                return result;
                break;
            case "+":
                return result + number3;
                break;
            case "-":
                return result - number3;
                break;
            case "*":
                return result * number3;
                break;
            case "/":
                return result / number3;
                break;
            default:
                break;
        }
        return 0;
    }

    public static int Calc(string equation, int S)
    {
        //I do not know how fast or slow this code will preform
        Queue<int> operand1 = new Queue<int>();
        Queue<int> operand2 = new Queue<int>();
        Queue<int> operand3 = new Queue<int>();
        string operator1 = "null";
        string operator2 = "null";

        //string parsing section
        for (int i = 0; i < equation.Length; i++)
        {
            switch ((int)equation[i])
            {
                case 32:
                    // ' '
                    break;
                case 83:
                    // S
                    if (operator1 == "null")
                    {
                        operand1.Enqueue(S);
                    }
                    else if (operator2 == "null")
                    {
                        operand2.Enqueue(S);
                    }
                    else
                    {
                        operand3.Enqueue(S);
                    }
                    break;
                case 43:
                    // +
                    if (operator1 == "null")
                    {
                        operator1 = "+";
                    }
                    else
                    {
                        operator2 = "+";
                    }
                    break;
                case 45:
                    // -
                    if (operator1 == "null")
                    {
                        operator1 = "-";
                    }
                    else
                    {
                        operator2 = "-";
                    }
                    break;
                case 42:
                    // *
                    if (operator1 == "null")
                    {
                        operator1 = "*";
                    }
                    else
                    {
                        operator2 = "*";
                    }
                    break;
                case 47:
                    // /
                    if (operator1 == "null")
                    {
                        operator1 = "/";
                    }
                    else
                    {
                        operator2 = "/";
                    }
                    break;
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    // 0 through 9
                    if (operator1 == "null")
                    {
                        operand1.Enqueue((int)equation[i] - 48);
                    }
                    else if (operator2 == "null")
                    {
                        operand2.Enqueue((int)equation[i] - 48);
                    }
                    else
                    {
                        operand3.Enqueue((int)equation[i] - 48);
                    }
                    break;
                default:
                    break;
            }
        }

        //math section
        int number1 = 0;
        int number2 = 0;
        int number3 = 0;
        int result = 0;
        while (operand1.Count != 0)
        {
            number1 = number1 * 10;
            number1 += operand1.Dequeue();
        }
        while (operand2.Count != 0)
        {
            number2 = number2 * 10;
            number2 += operand2.Dequeue();
        }
        while (operand3.Count != 0)
        {
            number3 = number3 * 10;
            number3 += operand3.Dequeue();
        }

        switch (operator1)
        {
            case "null":
                return number1;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                result = number1 / number2;
                break;
            case "+":
                if (operator2 != "*" && operator2 != "/")
                {
                    result = number1 + number2;
                }
                else if (operator2 == "*")
                {
                    return number1 + (number2 * number3);
                }
                else if (operator2 == "/")
                {
                    return number1 + (number2 / number3);
                }
                break;
            case "-":
                if (operator2 != "*" && operator2 != "/")
                {
                    result = number1 - number2;
                }
                else if (operator2 == "*")
                {
                    return number1 - (number2 * number3);
                }
                else if (operator2 == "/")
                {
                    return number1 - (number2 / number3);
                }
                break;
            default:
                break;
        }
        switch (operator2)
        {
            case "null":
                return result;
                break;
            case "+":
                return result + number3;
                break;
            case "-":
                return result - number3;
                break;
            case "*":
                return result * number3;
                break;
            case "/":
                return result / number3;
                break;
            default:
                break;
        }
        return 0;
    }
}
