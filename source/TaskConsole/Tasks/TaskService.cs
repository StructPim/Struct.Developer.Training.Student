using Shared;
using Struct.PIM.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsole.Tasks
{
    internal class TaskService
    {
        private Task0 _task0;
        private Task1 _task1;
        private Task2 _task2;
        private Task3 _task3;
        private Task4 _task4;

        public TaskService(Task0 task0,Task1 task1, Task2 task2, Task3 task3, Task4 task4)
        {
            _task0 = task0;
            _task1 = task1;
            _task2 = task2;
            _task3 = task3;
            _task4 = task4;
        }

        public string DoHeartBeat()
        {
            return _task0.DoHeartBeat();
        }

        public void DoTask1_1()
        {
             _task1.LoadCategoryDataIntoPIM();
        }
        public void DoTask1_2()
        {
             _task1.LoadProductDataIntoPIM();
        }

        public void DoTask1_3()
        {
            _task1.LoadVariantDataIntoPIM();
        }

        public void DoTask2_1()
        {
            _task2.FullExportProductData();
        }

        public void DoTask2_2()
        {
            _task2.ConsumeDeltaUpdates();
        }

        public void DoTask3_1()
        {
            _task3.DeltaUpdateExistingVariants();
        }

        public void DoTask3_2()
        {
            _task3.DeltaUpdateExistingAndNewVariants();
        }

        public void DoTask3_3()
        {
            _task3.DeltaUpdateGlobalListValues();
        }

        public void DoTask3_4()
        {
            _task3.UpdateCostPrices();
        }

        public void DoTask4_1()
        {
            _task4.SearchEnrichedProducts();
        }

        public void DoTask4_2()
        {
            _task4.EnrichSegmentedData();
        }
    }
}
