namespace FinalDemo.Models
{
    using System;
    using System.Collections.Generic;

    public class JewelleryStore
    {
        private List<Jewellery> jewelleries;

        public JewelleryStore()
            : this(4)
        {
        }

        public JewelleryStore(int count)
        {
            this.jewelleries = new List<Jewellery>(count);
        }

        public string Address { get; set; }

        public int JewelleriesCount => this.jewelleries.Count;

        public List<Jewellery> Jewelleries
        {
            get => this.jewelleries;
            set
            {
                if (value != null && value.Count > 0)
                {
                    this.jewelleries = value;
                }
            }
        }

        public void GetRandomJewelleries(int count, Random random)
        {
            for (var i = 0; i < count; i++)
            {
                var jewellery = new Jewellery();
                jewellery.GetRandomValues(random);
                this.jewelleries.Add(jewellery);
            }
        }
    }
}
