using CollectionHierarchy.Model;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();
            var indexesOfAddedElementsInCollections = new List<int>();

            var stringsToAdd = Console.ReadLine()
                .Split();
            var numberOfRemoveCommandsToAplly = int.Parse(Console.ReadLine());

            CollectIndexesOfAddCollection(addCollection, stringsToAdd, indexesOfAddedElementsInCollections);

            PrintIndexes(indexesOfAddedElementsInCollections);
            indexesOfAddedElementsInCollections = new List<int>();

            CollectIndexesOfAddRemoveCollection(addRemoveCollection, stringsToAdd, indexesOfAddedElementsInCollections);
            PrintIndexes(indexesOfAddedElementsInCollections);

            indexesOfAddedElementsInCollections = new List<int>();

            CollectIndexesOfMyList(myList, stringsToAdd, indexesOfAddedElementsInCollections);
            PrintIndexes(indexesOfAddedElementsInCollections);

            var collectRemovedElements = new List<string>();
            for (int i = 0; i < numberOfRemoveCommandsToAplly; i++)
            {
                collectRemovedElements.Add(addRemoveCollection.Remove());
            }
            PrintRemovedElement(collectRemovedElements);

            collectRemovedElements = new List<string>();
            for (int i = 0; i < numberOfRemoveCommandsToAplly; i++)
            {
                collectRemovedElements.Add(myList.Remove());
            }
            PrintRemovedElement(collectRemovedElements);
        }

        private static void PrintRemovedElement(List<string> collectRemovedElements)
        {
            Console.WriteLine(string.Join(" ", collectRemovedElements));
        }

        private static void CollectIndexesOfMyList(MyList myList, string[] stringsToAdd, List<int> indexesOfAddedElementsInCollections)
        {
            foreach (var item in stringsToAdd)
            {
                indexesOfAddedElementsInCollections.Add(myList.Add(item));
            }
        }

        private static void PrintIndexes(List<int> indexesOfAddedElementsInCollections)
        {
            Console.WriteLine(string.Join(" ", indexesOfAddedElementsInCollections));
        }

        private static void CollectIndexesOfAddRemoveCollection(AddRemoveCollection addRemoveCollection, string[] stringsToAdd, List<int> indexesOfAddedElementsInCollections)
        {
            foreach (var item in stringsToAdd)
            {
                indexesOfAddedElementsInCollections.Add(addRemoveCollection.Add(item));
            }
        }

        private static void CollectIndexesOfAddCollection(AddCollection addCollection, string[] stringsToAdd, List<int> indexesOfAddedElementsInCollections)
        {
            foreach (var item in stringsToAdd)
            {
                indexesOfAddedElementsInCollections.Add(addCollection.Add(item));
            }
        }
    }
}
