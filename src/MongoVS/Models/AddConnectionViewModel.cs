using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MongoDB.VisualStudio.Models
{
    public class AddConnectionViewModel
    {
        public AddConnectionViewModel()
        {
            UsedServerAddresses = new CollectionView(Enumerable.Empty<string>());
        }

        public CollectionView UsedServerAddresses { get; set; }

        public string ServerAddress { get; set; }
    }
}