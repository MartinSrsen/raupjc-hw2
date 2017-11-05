using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DrugiZadatak;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreciZadatak
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_Add()
        {
            TodoRepository repo = new TodoRepository();
            

            TodoItem item = new TodoItem("Item1");

            Assert.AreEqual(item , repo.Add(item));


        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void TestMethod2_Add()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");
            repo.Add(item);
            repo.Add(item);


        }

        [TestMethod]
        public void TestMethod1_Get()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");
            repo.Add(item);

            TodoItem item2 = repo.Get(item.Id);
            Assert.AreEqual(item2 , item);
        }

        [TestMethod]
        public void TestMethod2_Get()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");
            repo.Add(item);
            TodoItem item2 = new TodoItem("Item2");

            Assert.AreEqual(repo.Get(item2.Id) , null);
        }

        [TestMethod]
        public void TestMethod1_Remove()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");
            repo.Add(item);

            bool removed = repo.Remove(item.Id);
            Assert.AreEqual(true ,removed);

        }

        [TestMethod]
        public void TestMethod2_Remove()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item  = new TodoItem("Item1");
            repo.Add(item);
            TodoItem item2 = new TodoItem("Item2");

            Assert.AreEqual(false, repo.Remove(item2.Id));
        }

        [TestMethod]
        public void TestMethod1_Update()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");
            repo.Add(item);

            Assert.AreEqual(repo.Update(item) , item);

            TodoItem item2 = null;
            item2 = repo.Update(item2);

            Assert.AreEqual(item2.Text , "Todo Item:  UPDATED");
        }

        [TestMethod]
        public void TestMethod1_MarkAsComplete()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("Item1");

            Assert.AreEqual(repo.MarkAsCompleted(item.Id) , false);

            repo.Add(item);

            Assert.AreEqual(repo.MarkAsCompleted(item.Id) , true);
            Assert.AreEqual(repo.MarkAsCompleted(item.Id) ,false);

            Assert.AreEqual(item.IsCompleted  ,true);

        }

        [TestMethod]
        public void TestMethod1_GetAll()
        {
            TodoRepository repo = new TodoRepository();
            
            TodoItem item1 = new TodoItem("First created");

            Thread.Sleep(50);

            TodoItem item2 = new TodoItem("Second created");

            Thread.Sleep(50);
            TodoItem item3 = new TodoItem("Third created");

            Thread.Sleep(50);
            TodoItem item4 = new TodoItem("Fourth created");

            repo.Add(item2);
            repo.Add(item4);
            repo.Add(item1);
            repo.Add(item3);

            List<TodoItem> list = repo.GetAll();
            
            Assert.AreEqual(3 , list.IndexOf(item1));
           Assert.AreEqual(2, list.IndexOf(item2));
           Assert.AreEqual(1, list.IndexOf(item3));
          Assert.AreEqual(0 , list.IndexOf(item4));
        }

        [TestMethod]
        public void TestMethod1_GetActive()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("item1");
            TodoItem item2 = new TodoItem("item2");
            TodoItem item3 = new TodoItem("item3");
            TodoItem item4 = new TodoItem("item4");

            repo.Add(item);
            repo.Add(item2);
            repo.Add(item3);
            repo.Add(item4);

            item.MarkAsCompleted();
            item4.MarkAsCompleted();

            List<TodoItem> list = repo.GetActive();

            Assert.AreEqual(0 , list.IndexOf(item2));
            Assert.AreEqual(1, list.IndexOf(item3));
        }

        [TestMethod]
        public void TestMethod1_GetCompleted()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("item1");
            TodoItem item2 = new TodoItem("item2");
            TodoItem item3 = new TodoItem("item3");
            TodoItem item4 = new TodoItem("item4");

            repo.Add(item);
            repo.Add(item2);
            repo.Add(item3);
            repo.Add(item4);

            item.MarkAsCompleted();
            item4.MarkAsCompleted();

            List<TodoItem> list = repo.GetCompleted();

            Assert.AreEqual(0, list.IndexOf(item));
            Assert.AreEqual(1, list.IndexOf(item4));
        }

        [TestMethod]
        public void TestMethod1_GetFiltered()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item = new TodoItem("item1");
            TodoItem item2 = new TodoItem("item2");
            TodoItem item3 = new TodoItem("item3");
            TodoItem item4 = new TodoItem("item4");

            repo.Add(item);
            repo.Add(item2);
            repo.Add(item3);
            repo.Add(item4);

            item.MarkAsCompleted();
            item4.MarkAsCompleted();

            List<TodoItem> list = repo.GetFiltered(s => s.IsCompleted);

            Assert.AreEqual(0, list.IndexOf(item));
            Assert.AreEqual(1, list.IndexOf(item4));
        }

    }
}
