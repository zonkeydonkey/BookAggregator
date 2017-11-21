using System;
using System.Collections.Generic;
using System.Drawing;

namespace Books
{
    public partial class BookPicturePicker : PicturePicker
    {
        public List<Tuple<String, Image>> images = new List<Tuple<String, Image>> {
            new Tuple<String, Image> ("POETRY", Properties.Resources.poezja),
            new Tuple<String, Image> ("FANTASY", Properties.Resources.lotr),
            new Tuple<String, Image> ("SCIENCE-FICTION", Properties.Resources.solaris)
        };

        public override ref List<Tuple<String, Image>> Images
        {
            get
            {
                return ref images;
            }
        }

        public BookPicturePicker() : base()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
        }
    }
}
