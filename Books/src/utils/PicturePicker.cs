using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Books
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<PicturePicker, UserControl>))]
    public abstract partial class PicturePicker : UserControl
    {
        public abstract ref List<Tuple<String, Image>> Images
        {
            get;
        }
        private int currentImage = 0;

        public int CurrentImageId
        {
            get
            {
                if (ListUtils.AnyOrNotNull<Tuple<String, Image>>(Images))
                    return currentImage;
                throw new NoImageFoundException("Error while getting displayed image. No image available for picturePicker control.");
            }
            private set
            {
                if (ListUtils.AnyOrNotNull<Tuple<String, Image>>(Images) && value < Images.Count)
                    currentImage = value;
                else
                    throw new NoImageFoundException("No images available for picturePicker control.");
            }
        }

        public delegate void ImageChangedEventHandler(object sender, EventArgs args, Image image, String description);
        public event ImageChangedEventHandler ImageChanged;

        protected PicturePicker()
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
                if (ListUtils.AnyOrNotNull<Tuple<String, Image>>(Images))
                    return Images[currentImage].Item1;
                throw new NoImageFoundException("Error while getting displayed image. No image available for picturePicker control.");
            }
            set
            {
                int index = ListUtils.Find<String, Image>(Images, value);
                if (index < 0)
                    throw new NoImageFoundException("No images available for picturePicker control.");
                currentImage = index;

                /*if(DesignMode)
                    ImageChanged(this, new EventArgs(), Images[CurrentImageId].Item2, value);*/
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
                MessageBox.Show("There were some problems reading picture picker control's images.");
            }
        }

        public void OnClick(object sender, EventArgs e)
        {
            ++currentImage;
            currentImage %= Images.Count;
            Invalidate();
            //ImageChanged(sender, e, Images[CurrentImageId].Item2, Description);
        }
    }
}
