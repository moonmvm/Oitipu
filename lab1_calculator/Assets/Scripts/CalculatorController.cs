using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CalculatorController : MonoBehaviour
{
    public Text verticalResultText;
    public Text horizontalResultText;
    
    private string number = string.Empty;
    private string lastPressedOperation;
    private double lastInputNumber;
    private double result;
    private bool isExpressionFinished = false;

    private void ShowTextOnDisplay(string text)
    {
        verticalResultText.text = text;
        horizontalResultText.text = text;
    }

    public void OnDigitButtonPressed()
    {
        GameObject digitButton = EventSystem.current.currentSelectedGameObject;
        if (isExpressionFinished == false)
        {
            number += digitButton.GetComponentInChildren<Text>().text;
        }
        else
        {
            number = string.Empty;
            number += digitButton.GetComponentInChildren<Text>().text;
            isExpressionFinished = false;
        }
        ShowTextOnDisplay(number);
    }

    public void OnOperationButtonPressed()
    {
        GameObject operationButton = EventSystem.current.currentSelectedGameObject;
        lastPressedOperation = operationButton.GetComponentInChildren<Text>().text;
        lastInputNumber = double.Parse(number);
        number = string.Empty;
    }

    public void OnEqualsButtonPressed()
    {
        double currentInputNumber = 0;
        if (!number.Equals(string.Empty))
        {
            currentInputNumber = double.Parse(number);
        }

        switch (lastPressedOperation)
        {
            case "+":
                result = lastInputNumber + currentInputNumber;
                break;
            case "-":
                result = lastInputNumber - currentInputNumber;
                break;
            case "÷":
                result = lastInputNumber / currentInputNumber;
                break;
            case "x":
                result = lastInputNumber * currentInputNumber;
                break;
            case "y√x":
                result = Math.Pow(lastInputNumber, 1 / currentInputNumber);
                break;
            case "x^y":
                result = Math.Pow(lastInputNumber, currentInputNumber);
                break;
        }
        isExpressionFinished = true;
        lastInputNumber = 0;
        number = result.ToString();
        ShowTextOnDisplay(result.ToString());
    }

    public void OnClearButtonPressed()
    {
        lastInputNumber = 0;
        number = string.Empty;
        lastPressedOperation = string.Empty;
        ShowTextOnDisplay(number);
    }

    public void OnChangeSignButtonPressed()
    {
        if (number.StartsWith("-"))
        {
            number = number.Substring(1);
        } else {
            number = number.Insert(0, "-");
        }
        ShowTextOnDisplay(number);
    }

    public void OnPercentButtonPressed()
    {
        result = double.Parse(number) / 100;
        number = string.Empty;
        ShowTextOnDisplay(result.ToString());
    }

    public void OnCommaButtonPressed()
    {
        if (!number.Contains("."))
        {
            number += ".";
            ShowTextOnDisplay(number);
        }
    }

    public void OnFactorialButtonPressed()
    {
        if (number.Contains("."))
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        } else
        {
            int inputNum = int.Parse(number);
            result = 1;
            while (inputNum != 1)
            {
                result *= inputNum;
                inputNum -= 1;
            }
            ShowTextOnDisplay(result.ToString());
        }
        number = string.Empty;
    }

    public void OnDivideByXButtonPressed()
    {
        if (number == "0" || number == string.Empty)
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        } else
        {
            result = 1 / double.Parse(number);
            ShowTextOnDisplay(result.ToString());
        }
        number = result.ToString();
    }

    public void OnXPowButtonPressed(int power)
    {
        if (number == string.Empty)
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        }
        else
        {
            result = Math.Pow(double.Parse(number), power);
            ShowTextOnDisplay(result.ToString());
        }
        number = result.ToString();
    }

    public void OnXSqrtButtonPressed(int power)
    {
        if (number == string.Empty)
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        }
        else
        {
            result = Math.Pow(double.Parse(number), 1.0 / power);
            ShowTextOnDisplay(result.ToString());
        }
        number = result.ToString();
    }

    public void OnTrigonometricFuncButtonPressed()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        string operation = button.GetComponentInChildren<Text>().text;

        if (number == string.Empty)
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        }
        else
        {
            double inputNum = double.Parse(number);
            switch (operation)
            {
                case "sin":
                    result = Math.Sin(inputNum);
                    break;
                case "cos":
                    result = Math.Cos(inputNum);
                    break;
                case "tan":
                    result = Math.Tan(inputNum);
                    break;
                case "sinh":
                    result = Math.Sinh(inputNum);
                    break;
                case "cosh":
                    result = Math.Cosh(inputNum);
                    break;
                case "tanh":
                    result = Math.Tanh(inputNum);
                    break;
            }
            number = result.ToString();
            ShowTextOnDisplay(result.ToString());
        }
    }

    public void OnPiButtonPressed()
    {
        number = Math.PI.ToString();
        ShowTextOnDisplay(number);
    }

    public void OnEButtonPressed()
    {
        number = Math.E.ToString();
        ShowTextOnDisplay(number);
    }

    public void OnLogarithmButtonPressed()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        string operation = button.GetComponentInChildren<Text>().text;

        if (number == string.Empty)
        {
            ShowTextOnDisplay(Constants.ERROR_MESSAGE);
        }
        else
        {
            double inputNum = double.Parse(number);
            switch (operation)
            {
                case "lg":
                    result = Math.Log10(inputNum);
                    break;
                case "ln":
                    result = Math.Log(inputNum);
                    break;
            }
            number = result.ToString();
            ShowTextOnDisplay(result.ToString());
        }
    }

    public void OnParenthesisButtonPressed()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        string parenthesis = button.GetComponentInChildren<Text>().text;
       
        number += parenthesis;
    }

    public void OnTenInPowerXButtonPressed()
    {

    }
}
