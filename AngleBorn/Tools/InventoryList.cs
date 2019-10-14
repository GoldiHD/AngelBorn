using AngleBorn.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Tools
{
    class InventoryList
    {
        private List<BaseItem> _content;

        public BaseItem this[int index] { get { return _content[index]; } }

        public int Count { get { return _content.Count; }}

        public void Add(BaseItem item)
        {

        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(BaseItem item)
        {
            if(_content.Contains(item))
            {
                return true;
            }
            return false;
        }

        public int IndexOf(BaseItem item)
        {
            return _content.IndexOf(item);
        }

        public void Insert(int index, BaseItem item)
        {
            _content.Insert(index, item);
        }

        public bool Remove(BaseItem item)
        {
            return _content.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _content.RemoveAt(index);
        }
    }
}
