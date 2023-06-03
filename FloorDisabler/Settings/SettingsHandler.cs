using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage.Attributes;

namespace FloorDisabler.Settings
{
    class SettingsHandler : PersistentSingleton<SettingsHandler>
    {
        [UIValue("Enabled")]
        public bool Enabled
        {
            get => Configuration.Instance.Enabled;
            set
            {
                Configuration.Instance.Enabled = value;
            }
        }
        [UIValue("PlayersPlace")]
        public bool PlayersPlace
        {
            get => Configuration.Instance.PlayersPlace;
            set
            {
                Configuration.Instance.PlayersPlace = value;
            }
        }
        [UIValue("Laser")]
        public bool Laser
        {
            get => Configuration.Instance.Laser;
            set
            {
                Configuration.Instance.Laser = value;
            }
        }
        [UIValue("Ring")]
        public bool Ring
        {
            get => Configuration.Instance.Ring;
            set
            {
                Configuration.Instance.Ring = value;
            }
        }
        [UIValue("Spectrograms")]
        public bool Spectrograms
        {
            get => Configuration.Instance.Spectrograms;
            set
            {
                Configuration.Instance.Spectrograms = value;
            }
        }
    }
}
