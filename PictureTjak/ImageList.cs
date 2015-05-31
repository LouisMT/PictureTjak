using System.Collections.Generic;
using System.Drawing;

namespace PictureTjak
{
    class ImageList : List<Image>
    {
        public int CurrentIndex
        {
            get;
            set;
        }

        public Image CurrentImage
        {
            get
            {
                return this[this.CurrentIndex];
            }
        }

        public int MinIndex
        {
            get
            {
                return 0;
            }
        }

        public int MaxIndex
        {
            get
            {
                return this.Count - 1;
            }
        }
    }
}
