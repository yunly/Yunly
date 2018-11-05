using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern
{
    public class Builder
    {
        public static void runTest() {

            var father = new Parents();
            var mother = new Parents();
            var homework1 = father.superVisior(new Celestia { name = "Celestia" });
            var homework2 = mother.superVisior(new Selena { name = "Selena" });

            homework1.listHomeWorkList();
            homework2.listHomeWorkList();


        }
    }

    public class Parents
    {
        public HomeWork superVisior(Children daughter)
        {
            daughter.PlayPiano();
            daughter.SchoolTask();
            daughter.ReadBook();
            daughter.OrganizeRoom();

            return daughter.doHomeWork();
        }
    }

    public class HomeWork
    {
        List<string> homeWorks = new List<string>();

        public void DoHomework(string task)
        {
            homeWorks.Add(task);                
        }

        public void listHomeWorkList()
        {
            foreach (var task in homeWorks)
                Console.WriteLine(task);
        }
    }

    public abstract class Children
    {
        public string name { get; set; }
        protected HomeWork homeWork = new HomeWork();

        public abstract void PlayPiano();
        public abstract void ReadBook();
        public abstract void OrganizeRoom();
        public abstract void SchoolTask();

        public abstract HomeWork doHomeWork();
    }

    public class Celestia : Children
    {
       
        public override HomeWork doHomeWork()
        {
            return homeWork;
        }

        public override void OrganizeRoom()
        {
            homeWork.DoHomework($"{name} organized living room.");                
        }

        public override void PlayPiano()
        {
            homeWork.DoHomework($"{name} played piano <for Alice>.");
        }

        public override void ReadBook()
        {
            homeWork.DoHomework($"{name} red book <<Frozen>>.");
        }

        public override void SchoolTask()
        {
            homeWork.DoHomework($"{name} filled agenda");
        }
    }

    public class Selena : Children
    {
        public override HomeWork doHomeWork()
        {
            return homeWork;
        }

        public override void OrganizeRoom()
        {
            homeWork.DoHomework($"{name} organized bedroom.");
        }

        public override void PlayPiano()
        {
            homeWork.DoHomework($"{name} played piano <ABC>.");
        }

        public override void ReadBook()
        {
            homeWork.DoHomework($"{name} red book <<Welcome baby.>>.");
        }

        public override void SchoolTask()
        {
            homeWork.DoHomework($"{name} filled communication book.");
        }
    }




}
