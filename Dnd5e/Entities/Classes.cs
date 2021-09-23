using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dnd5e.Entities
{
    public class Classes
    {
        public int ClassesId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Characters
        {
            get;
            private set;
        } = new ObservableCollection<Character>();
        
    }
}
