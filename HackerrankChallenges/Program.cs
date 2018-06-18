using System;
using System.Collections.Generic;

class Solution
{
    private static LinkedList<int> convertArrayIntoLinkedList(int[] array)
    {
        return new LinkedList<int>(array);
    }

    private static LinkedList<int> rotateLeftOnce(LinkedList<int> linkedList)
    {
        linkedList.AddLast(linkedList.First.Value);
        linkedList.RemoveFirst();
        return linkedList;
    }

    private static LinkedList<int> rotateLeft(LinkedList<int> linkedList, int numOfRotations)
    {
        var rotatedList = linkedList;

        for (int i = 0; i < numOfRotations; i++)
        {
            rotatedList = rotateLeftOnce(linkedList);
        }

        return rotatedList;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);

        var linkedList =  convertArrayIntoLinkedList(a);

        linkedList = rotateLeft(linkedList, k);

        foreach (var node in linkedList)
        {
            Console.Write(node.ToString() + ' '); 
        }
    }
}