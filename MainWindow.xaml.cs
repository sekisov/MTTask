using MTTask.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MTTask
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//Количество рядов
		private int _countRowSeats = 10;
		//Количество мест в ряду
		private int _countColumnSeats = 20;
		public MainWindow()
		{
			InitializeComponent();
			//Создаем список билетных операций
			List<Ticket> tickets = new List<Ticket>();
			//Заполняем список
			tickets.Add(new Ticket { Id = 17504, Date = "21.09.2020", Time = "18:00", Name = "Баядерка" });
			tickets.Add(new Ticket { Id = 8894, Date = "23.07.2020", Time = "19:00", Name = "Аида" });
			tickets.Add(new Ticket { Id = 8958, Date = "25.07.2020", Time = "21:00", Name = "Тестирование" });
			tickets.Add(new Ticket { Id = 9058, Date = "19.09.2020", Time = "19:00", Name = "Аида" });
			tickets.Add(new Ticket { Id = 18482, Date = "22.09.2020", Time = "18:00", Name = "Баядерка" });
			tickets.Add(new Ticket { Id = 21352, Date = "01.10.2020", Time = "19:00", Name = "Баядерка" });
			tickets.Add(new Ticket { Id = 20302, Date = "30.09.2020", Time = "19:00", Name = "Баядерка" });
			//Создаем datagrid
			DataGrid dataGrid = new DataGrid();
			dataGrid.IsReadOnly = true;
			//Создаем groupBox что бы проименовать таблицу
			GroupBox groupBox = new GroupBox();
			groupBox.Header = "Билетные операции";
			groupBox.Content = dataGrid;
			//Заполняем datagrid данными 
			dataGrid.ItemsSource = tickets;
			//Добавляем наш GroupBox в общий Grid
			MainGrid.Children.Add(groupBox);
			//Указываем положение
			Grid.SetRow(groupBox, 1);
			Grid.SetColumn(groupBox, 0);

			GridSplitter gridSplitter = new GridSplitter() { VerticalAlignment = VerticalAlignment.Stretch, Width = 3, HorizontalAlignment = HorizontalAlignment.Center };
			MainGrid.Children.Add(gridSplitter);
			Grid.SetRow(gridSplitter, 1);
			Grid.SetColumn(gridSplitter, 1);

			//Создаем Canvas для рисования
			Canvas canvas = new Canvas();

			for (int i = 0; i < _countRowSeats; ++i)
			{
				for (int j = 0; j < _countColumnSeats; ++j)
				{
					//Создаем textBlock для отрисовки надстрочного и подстрочного шрифта
					TextBlock textBlock = new TextBlock();
					Run runSub = new Run();
					//указываем тип шрифта
					runSub.Typography.Variants = FontVariants.Subscript;
					runSub.Text = (j + 1).ToString();

					Run runSup = new Run();
					runSup.Typography.Variants = FontVariants.Superscript;
					runSup.Text = (i + 1).ToString();

					textBlock.Inlines.Add(runSup);
					textBlock.Inlines.Add(runSub);

					//Устанавливаем параметры кнопки
					Button button = new Button();
					button.Width = 20;
					button.Height = 20;
					//Устанавливаем цвет фона кнопки прозрачным
					button.Background = Brushes.Transparent;
					//Добавляем форматированный текст
					button.Content = textBlock;
					button.BorderBrush = Brushes.Red;

					button.Click += Button_Click;

					canvas.Children.Add(button);
					Canvas.SetLeft(button, 25 * j);
					Canvas.SetTop(button, 25 * i);
				}
			}
			//Добавляем GroupBox для показа описания блока
			GroupBox groupBoxCanvas = new GroupBox();
			groupBoxCanvas.Header = "Навигационный план";
			groupBoxCanvas.Content = canvas;

			MainGrid.Children.Add(groupBoxCanvas);
			Grid.SetRow(groupBoxCanvas, 1);
			Grid.SetColumn(groupBoxCanvas, 2);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//Преобразуем объект к Button
			Button button = sender as Button;
			//Если преобразование удалось, то сравниваем текущий цвет и выставляем необходимый
			if (button != null)
			{
				//Устанавливаем цвет границы зеленым, если ранее он был красным
				if (button.BorderBrush == Brushes.Red)
				{
					button.BorderBrush = Brushes.Green;
				}
				else
				{
					button.BorderBrush = Brushes.Red;
				}
			}
		}

		private void RibbonWin_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}

}
