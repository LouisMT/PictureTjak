using System.Collections.Generic;
using System.Drawing;

namespace PictureTjak
{
    class ImageList : List<Image>
    {
        public bool HasImage => Count > 0;

        public int CurrentIndex
        {
            get;
            set;
        }

        public Image CurrentImage => this[CurrentIndex];

        public int MinIndex => 0;

        public int MaxIndex => (Count > 0) ? Count - 1 : 0;

        public new void Clear()
        {
            CurrentIndex = MinIndex;

            base.Clear();
        }
    }
}
