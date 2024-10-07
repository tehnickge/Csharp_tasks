using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


//Создать консольное приложение для учета задач и проектов в 
//отделе логистики. Программа позволяет хранить информацию о 
//задачах, связанных с управлением поставками, складским 
//хранением и распределением товаров, включая название задачи,
//описание, статус выполнения, ответственного логиста и срок 
//выполнения. Реализовать функциональность добавления новых 
//задач, назначения ответственных, изменения статусов и 
//отображения задач по логисту.
namespace C_units
{
    public interface ITask
    {
        string Title { get; set; }
        string Description { get; set; }
        string DeadLine { get; set; }
        string Status { get; set; }
        string FromNumber { get; set; }
        string ToNumber { get; set; }
        string Item { get; set; }
        IPerson HeadPerson { get; set; }
    }
    public interface IContainer
    {
        string Number { get; set; }
        string Item { set; get; }
    }
    public interface IPerson
    {
        string Name { get; set; }
        string WorkType { get; set; }
    }
    public interface IFactory
    {
        List<ITask> tasks { get; set; }
        List<IContainer> container { get; set; }
        List<IPerson> persons { get; set; }
        void AddTask(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, IPerson person);
        void AddPerson(string name, string workType);
        void AddItem(string number, string title);
        void MakeWork();
    }

    public interface IFactoryTask
    {
        ITask FactoryMethod(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, string personName, string worktype);
        ITask FactoryMethod(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, IPerson person);
    }
    public interface IFactoryPerson
    {
        IPerson FactoryMethod(string name, string worktype);
    }
    public interface IContainerFactory
    {
        IContainer FactoryMethod(string name, string item);
    }
    public class FactoryPerson : IFactoryPerson
    {
        public IPerson FactoryMethod(string name, string worktype)
        {
            return new Person(name, worktype);
        }
    }

    public class Container : IContainer
    {
        public Container(string number, string item)
        {
            Number = number;
            Item = item;
        }
        public string Number { get; set; }
        public string Item { get; set; }
    }

    public class FactoryTask : IFactoryTask
    {
        public ITask FactoryMethod(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, string personName, string worktype)
        {
            FactoryPerson factoryPerson = new FactoryPerson();
            return new Task(title, description, deadLine, status, fromNumber, toNumber, item, factoryPerson.FactoryMethod(personName, worktype));
        }

        public ITask FactoryMethod(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, IPerson person)
        {
            FactoryPerson factoryPerson = new FactoryPerson();
            return new Task(title, description, deadLine, status, fromNumber, toNumber, item, person);
        }
    }

    public class Task : ITask
    {
        public Task(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, IPerson headPerson)
        {
            Title = title;
            Description = description;
            DeadLine = deadLine;
            Status = status;
            FromNumber = fromNumber;
            ToNumber = toNumber;
            Item = item;
            HeadPerson = headPerson;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
        public string Status { get; set; }
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }
        public string Item { get; set; }
        public IPerson HeadPerson { get; set; }
    }
    public class Person : IPerson
    {
        public Person(string name, string workType)
        {
            Name = name;
            WorkType = workType;
        }
        public string Name { get; set; }
        public string WorkType { get; set; }
    }

    public class ContainerFactory : IContainerFactory
    {
        public IContainer FactoryMethod(string number, string item)
        {
            return new Container(number, item);
        }
    }
    public class Factory : IFactory
    {
        public Factory()
        {
            container = new List<IContainer>();
            persons = new List<IPerson>();
            tasks = new List<ITask>();
            container = new List<IContainer>();
            Console.WriteLine("Производство запущено");
        }
        public List<ITask> tasks { get; set; }
        public List<IContainer> container { get; set; }
        public List<IPerson> persons { get; set; }
        public void AddTask(string title, string description, string deadLine, string status, string fromNumber, string toNumber, string item, IPerson person)
        {
            FactoryTask factoryTask = new FactoryTask();
            tasks.Add(factoryTask.FactoryMethod(title, description, deadLine, status, fromNumber, toNumber, item, person));
            Console.WriteLine("Задача добавлена");
        }
        public void AddPerson(string name, string workType)
        {
            FactoryPerson factoryPerson = new FactoryPerson();
            persons.Add(factoryPerson.FactoryMethod(name, workType));
            Console.WriteLine("Работник добавлен");
        }
        public void AddItem(string number, string item)
        {
            ContainerFactory cont = new ContainerFactory();

            container.Add(cont.FactoryMethod(number, item));
            Console.WriteLine("Предмет добавлен");
        }
        public void MakeWork()
        {
            if (tasks.Count <= 0) { Console.WriteLine("ошибка выполнения"); return; }
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Status != "ready to work") { Console.WriteLine("нет задач"); continue; }
                var temp = container.Find(item => item.Number == tasks[i].FromNumber && item.Item == tasks[i].Item);
                Console.WriteLine($"предмет {temp} найден");
                container.Remove(container.Find(item => item.Number == tasks[i].FromNumber && item.Item == tasks[i].Item));
                this.AddItem(tasks[i].ToNumber, tasks[i].Item);
                Console.WriteLine($"предмет перемещен");
                tasks[i].Status = "finish";
                Console.WriteLine($"{tasks[i].Status}");
            }
        }
    }
}