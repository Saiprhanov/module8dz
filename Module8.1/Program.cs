using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8.1
{
    public class SquaredArray
    {
        private double[] data;

        public SquaredArray(int size)
        {
            data = new double[size];
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= data.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                return data[index];
            }
            set
            {
                if (index < 0 || index >= data.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                data[index] = value * value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SquaredArray squaredArray = new SquaredArray(5);

            squaredArray[0] = 2;
            squaredArray[1] = 3;
            squaredArray[2] = 4;
            squaredArray[3] = 5;
            squaredArray[4] = 6;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Element {i}: {squaredArray[i]}");
            }
            Console.ReadKey();
        }
    }
}
