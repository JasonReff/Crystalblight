using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//unfinished
public class Calculate : MonoBehaviour
{
    public static int Calc(string equation)
    {
        //I do not know how fast or slow this code will preform
        Stack<int> operand1 = new Stack<int>();
        Stack<int> operand2 = new Stack<int>();
        string operator1 = "none";
        for (int i = 0; i < equation.Length; i++)
        {
            switch ((int)equation[i])
            {
                case 32:
                    //' '
                    break;
                case 83:
                    //S
                    //this method only gets called if no stage number is given so a 0 is returned as an error
                    return 0;
                    break;
                case 43:
                    //+
                    break;
                case 45:
                    //+
                    break;
                case 42:
                    //*
                    break;
                case 47:
                    //*
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
                    //0 through 9
                    if (operator1 == "null")
                    {
                        operand1.Push((int)equation[i] - 48);
                    }
                    else
                    {
                        operand2.Push((int)equation[i] - 48);
                    }
                    break;
                default:
                    break;
            }
        }
        return 0;
    }
}
