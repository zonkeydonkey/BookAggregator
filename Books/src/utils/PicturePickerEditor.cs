using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Books
{
    class PicturePickerEditor : UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object dsc)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                PicturePicker picturePicker = new PicturePicker();
                picturePicker.Description = (String)dsc;
                edSvc.DropDownControl(picturePicker);
                try
                {
                    return picturePicker.Description;
                } catch (NoImageFoundException nife)
                {
                    MessageBox.Show(nife.Message + "No images for picture picker control found.");
                }
                
            }
            return dsc;
        }
    }
}