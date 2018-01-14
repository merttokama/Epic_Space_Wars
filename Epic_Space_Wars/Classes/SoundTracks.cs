using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace Epic_Space_Wars.Classes
{
    public class SoundTracks
    {
        public static SoundPlayer mainMenuSoundtrack { get; set; } = new SoundPlayer(Properties.Resources.MainMenu_Soundtrack);
        public static SoundPlayer crashSoundtrack { get; set; } = new SoundPlayer(Properties.Resources.Crash_Sound_Effect);
        public static SoundPlayer explosionSound { get; set; } = new SoundPlayer(Properties.Resources.Explosion_Sound_Effect);
        public static SoundPlayer bonusEffect { get; set; } = new SoundPlayer(Properties.Resources.Bonus_Effect);
        public static SoundPlayer spaceshipFireSoundtrack { get; set; } = new SoundPlayer(Properties.Resources.SpaceShip_Fire_Sound_Effect);
    }



}
