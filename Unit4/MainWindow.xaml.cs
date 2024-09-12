using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Unit4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Factory factory;
        public MainWindow()
        {
            factory = new Factory();
            InitializeComponent();
          
        }

        private void PersonsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void ContainerDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void TaskDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public void UpdateTask()
        {
            this.TaskDataGrid.Items.Clear();
            for (int i = 0; i < factory.tasks.Count; i++)
            {
                var temp = new TempClass(factory.tasks[i].Title, factory.tasks[i].Description, factory.tasks[i].DeadLine, factory.tasks[i].Status, factory.tasks[i].FromNumber, factory.tasks[i].ToNumber, factory.tasks[i].Item, factory.persons[0].Name, factory.persons[0].WorkType);
                this.TaskDataGrid.Items.Add(temp);
            }
        }
        public void UpdatePerson()
        {
            this.PersonsDataGrid.Items.Clear();
            for (int i = 0; i < factory.persons.Count; i++)
            {
                this.PersonsDataGrid.Items.Add(factory.persons[i]);
            }
        }
        public void UpdateContainer() 
        {
            this.ContainerDataGrid.Items.Clear();
            for (int i = 0; i < factory.container.Count; i++)
            {
                this.ContainerDataGrid.Items.Add(factory.container[i]);
            }
        }

        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            factory.AddPerson(this.PersonNameInput.Text, this.PersonTypeWorkInput.Text);
            UpdatePerson();
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            factory.AddItem(this.ItemNumber.Text, this.ItemItem.Text);
            UpdateContainer();


        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            factory.AddTask("any", "any .Description", "any date", "ready to work", this.TaskFrom.Text, this.TaskTo.Text, this.TaskItem.Text, factory.persons[0]);
            var temp = new TempClass("any", "any .Description", "any date", "ready to work", this.TaskFrom.Text, this.TaskTo.Text, this.TaskItem.Text, factory.persons[0].Name, factory.persons[0].WorkType);
            this.TaskDataGrid.Items.Add(temp);
            UpdateTask();
        }

        private void MakeWork_Click(object sender, RoutedEventArgs e)
        {
            factory.MakeWork();
            UpdateContainer();
            UpdatePerson();
            UpdateTask();
        }
    }

  
}
