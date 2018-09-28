using System;
using System.Collections.Generic;
using System.IO;

namespace BubbleSort
{
    //http://snipd.net/quicksort-in-c
    class Program
    {
        static void Main(string[] args)
        {
            //uses system.io.file readalltext function to gather data and place in array <-- currently the only method that works
            string path = @"/Users/EDGUIV/Documents/eg-jf-jd.csv";
            string readFile = File.ReadAllText(path);
            string[] unsorted = readFile.Split(',');

            //string[] experiment = { };

            //string[] sortedDouble = { };
            //string[] sortedGuid = { };
            //string[] sortedInt = { };

            //Uses streamreader and while loop to gather data <--- currently does not (completely) work
            //if (File.Exists(path))
            //{
            //    var reader = new StreamReader(File.OpenRead(path));

            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var values = line.Split(',');

            //        var Pval1 = Int32.Parse(values[0]);
            //        var Pval2 = Guid.Parse(values[1]);
            //        var Pval3 = double.Parse(values[2]);

            //        var val1 = values[0];
            //        var val2 = values[1];
            //        var val3 = values[2];

            //        Tuple<int, Guid, double>[] myTuple = { Tuple.Create(Pval1, Pval2, Pval3) };
            //        //experiment = new string[] { myTuple[0].Item1.ToString(), myTuple[0].Item2.ToString(), myTuple[0].Item3.ToString() };

            //        //Arrays using Tuples, integer first then subject to sort
            //        string[] unsortDouble = { myTuple[0].Item1.ToString(), myTuple[0].Item3.ToString() };
            //        string[] unsortGuid = { myTuple[0].Item1.ToString(), myTuple[0].Item2.ToString() };
            //        string[] unsortInt = { myTuple[0].Item1.ToString(), myTuple[0].Item1.ToString() };


            //        //Arrays using values
            //        //sortedDouble = new string[] { values[0], values[2] };
            //        //sortedGuid = new string[] { values[0], values[1] };
            //        //sortedInt = new string[] { values[0], values[0] };

            //        //Sort algorithms
            //        //MergeSorter.SortMerge(unsortInt, 0, 1);

            //       //Quicksort(unsortGuid, 0, 1);

            //        //Console.WriteLine(String.Join(", ", unsortGuid));

            //        //Print the sorted array
            //        //for (int i = 0; i < 2; i++)
            //        //{
            //        //    Console.WriteLine(String.Join(", ", sortedDouble[i]));
            //        //}
            //    }
            //}

            //Use this method to sort the string[] unsorted array <--- currently works (kinda)
            //Print the unsorted array
            for (int i = 0; i < 100; i++)
            {
                Console.Write(unsorted[i]);
            }

            Console.WriteLine("\n");

            //Algorithms for sorting the array
              Quicksort(unsorted, 0, 100);
            //MergeSorter.SortMerge(values: unsorted, left: 0, right: 100);

                //Print the sorted array
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(unsorted[i]);
                //Console.WriteLine(String.Join(", ", unsorted[i]));
            }


            Console.ReadLine();
        }
       

        //public static void SortByGuidUsingQuickSort(Tuple<int, int>[] elements, int left, int right) <--- currently does not work
        //{
        //    int i = left, j = right;
        //    Tuple<int, int> pivot = elements[(left + right) / 2];

        //    while (i <= j)
        //    {
        //        while (elements[i].Item1.CompareTo(pivot) < 0)
        //        {
        //            i++;
        //        }

        //        while (elements[j].Item1.CompareTo(pivot) > 0)
        //        {
        //            j--;
        //        }

        //        if (i <= j)
        //        {
        //            // Swap
        //            Tuple<int, int> tmp = elements[i];
        //            elements[i] = elements[j];
        //            elements[j] = tmp;

        //            i++;
        //            j--;
        //        }
        //    }

        //    // Recursive calls
        //    if (left < j)
        //    {
        //        SortByGuidUsingQuickSort(elements, left, j);
        //    }

        //    if (i < right)
        //    {
        //        SortByGuidUsingQuickSort(elements, i, right);
        //    }
        //}

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        public static class MergeSorter
        {
            static public void MainMerge<T>(T[] values, int left, int mid, int right) where T : IComparable<T>
            {
                var temp = new T[1000000];
                int i, eol, num, pos;

                eol = (mid - 1);
                pos = left;
                num = (right - left + 1);

                while ((left <= eol) && (mid <= right))
                {
                    if (values[left].CompareTo(values[mid]) < 0)
                    {
                        temp[pos++] = values[left++];
                    }
                    else
                    {
                        temp[pos++] = values[mid++];
                    }
                }

                while (left <= eol)
                    temp[pos++] = values[left++];

                while (mid <= right)
                    temp[pos++] = values[mid++];

                for (i = 0; i < num; i++)
                {
                    values[right] = temp[right];
                    right--;
                }
            }

            static public void SortMerge<T>(T[] values, int left, int right) where T : IComparable<T>
            {
                int mid;

                if (right > left)
                {
                    mid = (right + left) / 2;
                    SortMerge(values, left, mid);
                    SortMerge(values, (mid + 1), right);

                    MainMerge(values, left, (mid + 1), right);
                }
            }
        }
    }
}

