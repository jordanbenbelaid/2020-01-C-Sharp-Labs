﻿using System;
using System.Collections.Generic;
using System.Linq;      //Query language


                                    //Can use => (LAMBDA ARROW)
namespace lab_20_list_queue_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var List = new List<int>() { 10, 20, 30, 40 };  //literal
            List.Add(50);
            List.Add(60);       // at end
            List.Insert(0, 5);         //add 5 at index 0
            //print list
           
            foreach (int x in List)
            {
                Console.WriteLine(x);
            }
            //foreach item in 'List' ((get item, call it item, process it whatever code in braces))
            List.ForEach(item => 
            {
                Console.WriteLine(item);
            });

            //Queue
            var queue = new Queue<int>();
            //add 5 items
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            //remove 2 items
            //queue.Dequeue();
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            
            //print queue
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            //or
            Console.WriteLine(string.Join(',', queue));
            Array.ForEach(queue.ToArray(), item => Console.WriteLine(item));

            //stack
            //create stack with 10 random numbers between 1-100
            var stack = new Stack<int>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(random.Next(1, 100));
            }
            //print stack on one line with commas
            Console.WriteLine(string.Join(',', stack));

            //remove top 3 items
            stack.Pop();
            stack.Pop();
            stack.Pop();

            //print stack again
            Console.WriteLine(string.Join(',', stack));

        }
    }
}
