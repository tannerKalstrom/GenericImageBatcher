using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num_inputs = Convert.ToInt32(Console.ReadLine());
            List<int> inputs = new List<int>();
            List<int> first = new List<int>();
            var input_raw = Console.ReadLine();
            var inputs_split = input_raw.Split(' ');
            foreach (var num in inputs_split)
            {
                var number = Convert.ToInt32(num);
                inputs.Add(number);
            }
            for (int i = 1; i < inputs.Count; i++)
            {
               first.Add(inputs[i] - inputs[i - 1]);
            }
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int val in first)
            {
                if (counter.ContainsKey(val)) counter[val]++;
                else counter.Add(val, 1);
            }
            int most_frequent = 0;
            int val_of_most_frequent = 0;
            foreach(var val in counter.Keys)
            {
                if (counter[val] > most_frequent)
                {
                    most_frequent = counter[val];
                    val_of_most_frequent = val;
                }
            }
            for (int i = 1; i < inputs.Count; i++)
            {
                if (inputs[i] - inputs[i - 1] != val_of_most_frequent) 
                    Console.WriteLine(inputs[i-1] + val_of_most_frequent);
            }
        
        }
    
 
    }
}
