using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignalRChat.Mobile
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;


            var imageSource = ImageSource.FromFile(Source);
            return imageSource;
        }
    }
}
