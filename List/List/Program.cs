using System;

namespace List
{
    class Program
    {
        static SortedLinkedList<int> BuildList() // build list
        {
            var list = new SortedLinkedList<int>((int i1, int i2) => i1 < i2); // specify lambda in parameters

            list.Insert(1);
            list.Insert(0);
            list.Insert(-2);
            list.Insert(5);
            list.Insert(1);
            list.Insert(9);

            return list;
        }

        static SortedLinkedList<int> BuildList2() // build list
        {
            var list = new SortedLinkedList<int>((int i1, int i2) => i1 < i2); // specify lambda in parameters

            list.Insert(0);
            list.Insert(9);
            list.Insert(-2);
            list.Insert(8);
            list.Insert(4);
            list.Insert(3);

            return list;
        }

        static UnsortedLinkedList<int> BuildUList()
        {
            var list = new UnsortedLinkedList<int>();

            /*list.InsertToHead(1);
            list.InsertToHead(0);
            list.InsertToHead(-2);
            list.InsertToHead(5);
            list.InsertToHead(1);
            list.InsertToHead(9);*/

            list.InsertToEnd(1);
            list.InsertToEnd(0);
            list.InsertToEnd(-2);
            list.InsertToEnd(5);
            list.InsertToEnd(1);
            list.InsertToEnd(9);

            return list;
        }


        static void Output(SortedLinkedList<int> list) // output list on the screen 
        {
            Console.WriteLine("List: ");

            //var currentNode = list.GetHead(); // currentNode is SortedLinkedList<int>.Node<int> type 
            //while (currentNode != null)
            //{
            //    Console.WriteLine(list.GetValue(currentNode));
            //    currentNode = list.GetNext(currentNode);
            //}

            for(var node = list.GetHead(); node != null; node = list.GetNext(node))
            {
                Console.WriteLine(list.GetValue(node));
            }
        }

        static void OutputUnsortedList(UnsortedLinkedList<int> list) // output list on the screen 
        {
            Console.WriteLine("List: ");

            //var currentNode = list.GetHead(); // currentNode is SortedLinkedList<int>.Node<int> type 
            //while (currentNode != null)
            //{
            //    Console.WriteLine(list.GetValue(currentNode));
            //    currentNode = list.GetNext(currentNode);
            //}

            for (var node = list.GetHead(); node != null; node = list.GetNext(node))
            {
                Console.WriteLine(list.GetValue(node));
            }
        }

        static void InsertValue(SortedLinkedList<int> list) // insert value to the ordered list
        {
            try
            {
                Console.Write("Input new value: ");
                int value = int.Parse(Console.ReadLine());

                list.Insert(value);

                Output(list);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
                Console.ResetColor();
            }
        }

        static void DeleteValue(SortedLinkedList<int> list) // delete value from the list
        {
            try
            {
                Console.Write("Input value to delete: ");
                int value = int.Parse(Console.ReadLine());

                int deletedItemCount = 0;
                while (list.Delete(value)) // while delete returns true do next attempt to delete value 
                {
                    deletedItemCount++;
                }

                Output(list);
                Console.WriteLine($"{deletedItemCount} " + (deletedItemCount > 1 ? "elements were deleted." : "element was deleted."));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
                Console.ResetColor();
            }
        }

        static void MergeLists(SortedLinkedList<int> list1, SortedLinkedList<int> list2)
        {
            try
            {
                var newList = list1.MergeWith(list2, false);

                Console.WriteLine("Merged list: ");
                Output(newList);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
                Console.ResetColor();
            }
        }

        static void Search(UnsortedLinkedList<int> list)
        {
            var node = list.Find(value =>  value == 90 );
            
            if(node != null)
            {
                Console.WriteLine();
                Console.WriteLine("Item was found.");
                Console.WriteLine(list.GetValue(node));
            }
            else
            {
                Console.WriteLine("Item was not found.");
            }
        }

        static void Main(string[] args)
        {
            //var list = BuildList();
            //Output(list);

            //InsertValue(list);

            //DeleteValue(list);

            //MergeLists(list, BuildList2());

            var uList = BuildUList();
            OutputUnsortedList(uList);

            Search(uList);
        }
    }
}
