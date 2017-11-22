using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Books
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<PicturePicker, UserControl>))]
    public partial class PicturePicker : UserControl
    {
        public static readonly List<Tuple<String, Image>> Images = new List<Tuple<String, Image>> {
            new Tuple<String, Image> ("POETRY", Properties.Resources.poezja),
            new Tuple<String, Image> ("FANTASY", Properties.Resources.lotr),
            new Tuple<String, Image> ("SCIENCE-FICTION", Properties.Resources.solaris)
        };
        private int currentImage = 0;

        public int CurrentImageId
        {
            get
            {
                return currentImage;
            }
            private set
            {
                if (value < Images.Count)
                    currentImage = value;
                else
                    throw new NoImageFoundException("No images available for picturePicker control.");
            }
        }

        public event EventHandler ImageChanged;

        public PicturePicker()
        {  
            InitializeComponent();
        }    

        [
        Category("Picture picker control"),
        Browsable(true),
        EditorAttribute(typeof(PicturePickerEditor), typeof(UITypeEditor))
        ]
        public String Description
        {
            get
            {
                return Images[CurrentImageId].Item1;
            }
            set
            {
                int index = ListUtils.Find<String, Image>(Images, value);
                if (index < 0)
                {
                    throw new NoImageFoundException("No images available for picturePicker control.");
                }
                    
                CurrentImageId = index;

                if (DesignMode && Parent != null)
                {
                    Parent.Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                pictureBox.Image = Images[CurrentImageId].Item2;
                pictureBox.Update();
            }
            catch (NoImageFoundException ex)
            {
                MessageBox.Show(ex.Message + "There were some problems reading picture picker control's images.");
            }
        }

        public void OnClick(object sender, EventArgs e)
        {
            CurrentImageId = (CurrentImageId + 1) % Images.Count;
            Invalidate();
            ImageChanged?.Invoke(this, new EventArgs());
        }
    }
}
