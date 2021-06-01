using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace MVVMPairs.Models
{
    [Serializable]
    public class Piesa : INotifyPropertyChanged
    {
        public Piesa(bool culoare)
        {
            this.Culoare = culoare;
            this.Rege = false;
            if (culoare == true)
                this.DisplayedImage = "/MVVMPairs;component/Resources/rosu.png";
            else
                this.DisplayedImage = "/MVVMPairs;component/Resources/alb.png";
        }

        public Piesa()
        {

        }
        private bool rege;

        [XmlElement]
        public bool Rege
        {
            get { return rege; }

            set
            {
                rege = value;
                if(value==true)
                    if (culoare == true)
                        this.DisplayedImage = "/MVVMPairs;component/Resources/rege.png";
                    else
                        this.DisplayedImage = "/MVVMPairs;component/Resources/regina.png";
                NotifyPropertyChanged("DisplayedImage");
            }
        }

        private bool culoare;

        [XmlElement]
        public bool Culoare
        {
            get { return culoare; }
            set
            {
                culoare = value;
            }
        }

        private string displayedImage;

        [XmlElement]
        public string DisplayedImage
        {
            get { return displayedImage; }
            set
            {
                displayedImage = value;
                NotifyPropertyChanged("DisplayedImage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}