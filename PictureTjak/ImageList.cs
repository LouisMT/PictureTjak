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
                return (this.Count > 0) ? this.Count - 1 : 0;
            }
        }

        public new void Clear()
        {
            this.CurrentIndex = this.MinIndex;

            base.Clear();
        }
    }
}
