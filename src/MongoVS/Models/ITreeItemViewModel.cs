using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Models
{
    public interface ITreeItemViewModel
    {
        string Name { get; }

        bool IsExpanded { get; set; }
    }
}