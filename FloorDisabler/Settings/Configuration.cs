using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorDisabler.Settings
{
    public class Configuration
    {
        public static Configuration Instance { get; set; } = null;
        public virtual bool Enabled { get; set; } = true;
        public virtual bool PlayersPlace { get; set; } = true;
        public virtual bool Laser { get; set; } = true;
        public virtual bool Ring { get; set; } = true;
        public virtual bool Spectrograms { get; set; } = true;
    }
}
