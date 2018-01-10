namespace FinalDemo.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Models;
    using Newtonsoft.Json;

    public class ApplicationManager
    {
        public void WriteIntoFile(string inputFilename, string outputFilename)
        {
            var storeReader = new JewelleryStoreReader(inputFilename);
            var storeProcessor = new JewelleryStoreProcessor();
            var textFileProcessor = new TextProcessor();

            var stores = storeReader.ReadStores();

            foreach (var store in stores)
            {
                textFileProcessor.WriteText(outputFilename, store.Address);
                var metalsCount = storeProcessor.GetAllMetalsCountDistinct(store);

                foreach (var metal in metalsCount)
                {
                   textFileProcessor.WriteText(outputFilename, metal.ToString());
                }

                var sortedJewelleries = storeProcessor.GetSortedJewelleriesFromStores(store, 50);
                foreach (var j in sortedJewelleries)
                {
                    textFileProcessor.WriteText(outputFilename, j.ToString());
                }
            }
        }

        public void WriteIntoFileCount(string inputFilename, string outputFilename)
        {
            var storeReader = new JewelleryStoreReader(inputFilename);
            var storeProcessor = new JewelleryStoreProcessor();
            var textFileProcessor = new TextProcessor();

            var stores = storeReader.ReadStores();

            foreach (var store in stores)
            {
                textFileProcessor.WriteText(outputFilename, store.Address);
                var metalsCount = storeProcessor.GetAllMetalsCountDistinct(store);

                foreach (var metal in metalsCount)
                {
                    textFileProcessor.WriteText(outputFilename, metal.ToString());
                }
            }
        }

        public void SerializeInfo(string inputFilename, string outputFilename)
        {
            var storeReader = new JewelleryStoreReader(inputFilename);
            var storeProcessor = new JewelleryStoreProcessor();
            var textFileProcessor = new TextProcessor();
            var outputText = ConfigurationManager.AppSettings["OutputTextFile"];

            var stores = storeReader.ReadStores();

            var metalsCountCollection = new List<JewelleryStoreProcessor.MetalCountPair>();
            foreach (var store in stores)
            {
                var metalsCount = storeProcessor.GetAllMetalsCountDistinct(store);
                metalsCountCollection.AddRange(metalsCount);
            }

            var serializedMetalsCountCollection = JsonConvert.SerializeObject(metalsCountCollection);
            textFileProcessor.WriteText(outputFilename, serializedMetalsCountCollection);

            var d = JsonConvert.DeserializeObject(serializedMetalsCountCollection);
            textFileProcessor.WriteText(outputText, d.ToString());

            var sortedJewelleriesCollection = new List<Jewellery>();
            foreach (var store in stores)
            {
                var sortedJewelleries = storeProcessor.GetSortedJewelleriesFromStores(store, 50);
                sortedJewelleriesCollection.AddRange(sortedJewelleries);
            }

            var serializedSortedJewelleriesCollection = JsonConvert.SerializeObject(sortedJewelleriesCollection);
            textFileProcessor.WriteText(outputFilename, serializedSortedJewelleriesCollection);
        }
    }
}
