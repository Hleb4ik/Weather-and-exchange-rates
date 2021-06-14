using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Net;
using System.Text.RegularExpressions;

namespace ЕБС_ДБО_v._1._1._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MouseDown += delegate { DragMove(); }; //Перемещение окна

            //Протокол подключения (иначе ошибка защищённого соединения SSL/TLS)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //**********************************************************************************************************************
            //Получаем код страницы Яндекс.Погоды и достаем погоду на данный момент (!!!дописать исключение при отсутствии интернета!!!)
            var content_pogoda = new WebClient { Encoding = Encoding.UTF8 }.DownloadString("https://yandex.by/pogoda/minsk");
            var result = Regex.Match(content_pogoda, @"<span class=""temp__value temp__value_with-unit"">(.+?)</span>").Groups[1].Value;
            labelPogoda.Content = "Сейчас " + result + "°";
            //**********************************************************************************************************************

            //**********************************************************************************************************************
            //Получаем код страницы НацБанка и достаем курс валют (!!!дописать исключение при отсутствии интернета!!!)

            //DOLLAR
            var content_valutaUSD = new WebClient { Encoding = Encoding.UTF8 }.DownloadString("https://select.by/kurs/");
            var result_vUSDb = Regex.Match(content_valutaUSD, @"<span itemprop=""price"">(.+?)</span>").Groups[1].Value;
            labelVUSD.Content = "Доллар: " + result_vUSDb + "руб.";

            //EURO
            var content_valutaEUR = new WebClient { Encoding = Encoding.UTF8 }.DownloadString("https://select.by/bobrujsk/kurs-evro");
            var result_vEURb = Regex.Match(content_valutaEUR, @"<span itemprop=""price"">(.+?)</span>").Groups[1].Value;
            labelVEUR.Content = "Евро: " + result_vEURb + "руб.";

            //RUS RUB
            var content_valutaRUB = new WebClient { Encoding = Encoding.UTF8 }.DownloadString("https://select.by/kurs-rublya");
            var result_vRUBb = Regex.Match(content_valutaRUB, @"<span itemprop=""price"">(.+?)</span>").Groups[1].Value;
            labelVRUB.Content = "Российский рубль: " + result_vRUBb + "руб.";
            //**********************************************************************************************************************
        }
        //***********************************************************************************
        //
        //В кликах 1,2,6,7,8,9,10,11,15 простой запуск процесса на ссылку т.к. банковское ПО
        //использовать запрещено (кроме общего доступа) в связи с регламентом.
        //Остальные клики - заглушки и не более, кроме "монетки", она была написана по 
        //приколу на паре по математическому моделированию.
        //
        //***********************************************************************************

        private void Button_Click(object sender, RoutedEventArgs e)//Мусор, можно удалить, но я не трогаю потому что может лечь прога :/
        {
            Process.Start("www.google.com");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//ИБ БелВЭБ
        {
            Process.Start("https://dbo2.bveb.by");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//ИБ Приорбанк
        {
            Process.Start("https://www.ibank.priorbank.by");
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)//ИБ МТБанк
        {
            Process.Start("https://ib.mtbank.by/#/login");
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)//ИБ Дабрабыт
        {
            Process.Start("https://ibank.bankdabrabyt.by");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Выход
        {
            Environment.Exit(0);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//Авест
        {
            MessageBox.Show("Error connection Avest PCMBel. Error code: -1000000", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)//Персональный Менеджер Сертификатов
        {
            MessageBox.Show("На вашем ПК отсутствует Персональный Менеджер Сертификатов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)//Налоговая
        {
            Process.Start("https://nces.by/pki/");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)//Тех.поддержка БайТех
        {
            Process.Start("https://www.bytechs.by/services/podderzhka-dbo/");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)//БайТех POS-терминалы
        {
            Process.Start("https://www.bytechs.by/services/postavka-pos-terminalov-verifone/");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)//Сайт БайТех
        {
            Process.Start("https://www.bytechs.by");
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)//КБ МТБанк
        {
            MessageBox.Show("На вашем ПК отсутствует Клиент Банк", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)//КБ Статус Банк
        {
            MessageBox.Show("На вашем ПК отсутствует Клиент Банк", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)//КБ Банк Решение
        {
            MessageBox.Show("На вашем ПК отсутствует Клиент Банк", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)//Утилита дитсанционной помощи
        {
            Process.Start("https://www.bytechs.by/upload/utilits-dbo/support-YWRtaW5AY29ycG9yYXRlLnBsYW4gMTIzNDU2IDEyMzQ1NiBzdXBwb3J0LmJ5dGVjaHMuYnk=.exe");
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)//Чисто по приколу написал
        {
            Random rnd = new Random();
            int x = rnd.Next(0,1000);
            if (x < 500)
            {
                MessageBox.Show("Ваша монетка подброшена", "Монетка", MessageBoxButton.OK);
                MessageBox.Show("Выпал Орел", "Монетка", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Ваша монетка подброшена", "Монетка", MessageBoxButton.OK);
                MessageBox.Show("Выпала Решка", "Монетка", MessageBoxButton.OK);
            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поддержка данного Клиент Банка прекращена.\nПользователи были переведены на систему Интернет Банк БелВЭБ Бизнес", "Поддержка прекращена!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
