using System;
using System.Collections.Generic;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class SoundManager
    {
        /// <summary>
        /// 
        /// </summary>
        private string currentBackgroundMusic = "MusicaAmbiente1";

        public string CurrentBackgroundMusic
        {
            get { return currentBackgroundMusic; }
            set { currentBackgroundMusic = value; }
        }

        private float volumeStep = 0.1f;

        private float VolumeStep
        {
            get { return volumeStep; }
            set { volumeStep = value; }
        }

        /// <summary>
        /// Aumenta o volume de todos os efeitos de som presentes na simulação
        /// </summary>
        public void increaseVolume()
        {
            foreach (SoundEffect s in Assets.Instance.Sounds.Values)
            {
                s.Gain += this.VolumeStep;
            }

            

            //Assets.Instancia.Sounds["Chimes"].Gain += this.VolumeStep;
        }

        /// <summary>
        /// Baixar o volume de todos os efeitos de som presentes na simulação
        /// </summary>
        public void decreaseVolume()
        {
            foreach (SoundEffect s in Assets.Instance.Sounds.Values)
            {                
                s.Gain -= this.VolumeStep;                
            }

            //Assets.Instancia.Sounds["Chimes"].Gain -= this.VolumeStep;            
        }

        /// <summary>
        /// Aumenta o volume de um efeito específico
        /// </summary>
        /// <param name="key">O nome do efeito do qual queremos aumentar o volume</param>
        public void increaseEffectVolume(String key)
        {
            if (Assets.Instance.Sounds.ContainsKey(key))
            {
                Assets.Instance.Sounds[key].Gain += this.VolumeStep;
            }
        }

        /// <summary>
        /// Diminui o volume de um efeito específico
        /// </summary>
        /// <param name="key">O nome do efeito do qual queremos baixar o volume</param>
        public void decreaseEffectVolume(String key)
        {
            if (Assets.Instance.Sounds.ContainsKey(key))
            {
                Assets.Instance.Sounds[key].Gain -= this.VolumeStep;
            }
        }

        public void switchAmbientMusicTo()
        {
        }

        public void switchAmbientMusicTo(String newMusic)
        {
            SoundEffect s;

            if (Assets.Instance.Sounds.ContainsKey(this.CurrentBackgroundMusic))
            {
                s = Assets.Instance.Sounds[this.CurrentBackgroundMusic];
                s.stopSound();
            }

            if (Assets.Instance.Sounds.ContainsKey(newMusic))
            {
                s = Assets.Instance.Sounds[newMusic];
                s.playSound();

                Messaging.Instance.Information.Enqueue("Música Ambiente alterada para: " + s.SoundName);
            }

            this.CurrentBackgroundMusic = newMusic;
        }
    }
}
