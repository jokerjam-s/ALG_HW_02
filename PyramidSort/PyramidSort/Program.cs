/*
 * Пирамидальная сортировка
 * 
 * 
 */


// исходный массив
using System;

int[] arr = new int[] { 4, 5, 8, 7, 4, 6, 6, 9, 2, 1, 7, 9, 3 };


// вывод начального массива
Console.WriteLine("Исх. массив:");
Console.WriteLine(String.Join(" ", arr));

PyramidSort(arr, arr.Length);

// Сортир. массив
Console.WriteLine("Сортир. массив:");
Console.WriteLine(String.Join(" ", arr));


static int AddToPyramid(int[] arr, int i, int node)
{
    int maxItem;
    int buf;

    if ((2 * i + 2) < node)
    {
        if (arr[2 * i + 1] < arr[2 * i + 2])
        {
            maxItem = 2 * i + 2;
        }
        else
        {
            maxItem = 2 * i + 1;
        }
    }
    else maxItem = 2 * i + 1;
    if (maxItem >= node) return i;
    if (arr[i] < arr[maxItem])
    {
        buf = arr[i];
        arr[i] = arr[maxItem];
        arr[maxItem] = buf;
        if (maxItem < node / 2) i = maxItem;
    }
    return i;
}

static void PyramidSort(int[] arr, int size)
{
    //step 1: building the pyramid
    for (int i = size / 2 - 1; i >= 0; --i)
    {
        long prevItem = i;
        i = AddToPyramid(arr, i, size);
        if (prevItem != i) ++i;
    }

    //step 2: sorting
    int buf;
    for (int j = size - 1; j > 0; --j)
    {
        buf = arr[0];
        arr[0] = arr[j];
        arr[j] = buf;
        int i = 0, prevItem = -1;
        while (i != prevItem)
        {
            prevItem = i;
            i = AddToPyramid(arr, i, j);
        }
    }
}
