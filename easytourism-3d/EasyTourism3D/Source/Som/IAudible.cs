using System;

namespace EasyTourism3D
{
    interface IAudible
    {
        String SoundName { get; set; }
        void setSoundPosition();
        void setSoundPosition(Vector3D position);

        void playSound();
        void stopSound();
    }
}
