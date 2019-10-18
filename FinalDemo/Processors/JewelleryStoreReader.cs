﻿namespace FinalDemo.Processors
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Extensions.Logging;

    public class JewelleryStoreReader
    {
        private readonly TextProcessor processor;
        private string filename;
        private readonly ILogger _logger;

        public JewelleryStoreReader(string filename, ILogger logger)
        {
            this.processor = new TextProcessor(logger);
            this.Filename = filename;
            _logger = logger;
        }

        public string Filename
        {
            get => this.filename;
            set
            {
                if (value != null && new FileInfo(value).Exists)
                {
                    this.filename = value;
                }
            }
        }

        public List<JewelleryStore> ReadStores()
        {
            var text = this.processor.ReadText(this.filename);

            // getting stores count
            var lines = text.Split('\n', '\r').Where(l => l != string.Empty).ToArray();
            var storesCount = lines.Length / 2;

            var random = new Random();

            var collection = new List<JewelleryStore>(storesCount);
            for (var i = 0; i < storesCount; i++)
            {
                collection.Add(new JewelleryStore
                {
                    Address = lines[2 * i]
                });
                collection[i].GetRandomJewelleries(int.Parse(lines[1 + (2 * i)]), random);
            }

            return collection;
        }
    }
}
