using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calc20._1WpfApp.Models;


namespace Calc20._1WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftop = ""; // Левая часть
        string operation = ""; // Знак операции
        string rightop = ""; // Правая часть



        public MainWindow()
        {
            InitializeComponent();
            // Обработчик для всех кнопок 
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст кнопки
            string s = (string)((Button)e.OriginalSource).Content;
            // ДОбавляем его в текстовое поле
            textBlock.Text += s;
            double num;
            // Пытаемся преобразовать его в число
            bool result = double.TryParse(s, out num);
            // Если текст - это число
            if (result == true)
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    leftop += s;
                }
                else
                {
                    // Иначе к правому операнду
                    rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                // Очищаем поле и переменные
                else if (s == "C")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }


        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            double num1 = double.Parse(leftop);
            double num2 = double.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    rightop = Ariph.Add1(num1, num2).ToString();
                    break;
                case "-":
                    rightop = Ariph.Add2(num1,num2).ToString();
                    break;
                case "x":
                    rightop = Ariph.Add3(num1, num2).ToString();
                    break;
                case "/":
                    rightop = Ariph.Add4(num1, num2).ToString();
                    break;
            }
        }

    }
    }

