using System;
using System.IO;
using System.Collections.Generic;
using EasyTourism3D.Properties;

using Tao.DevIl;
using Tao.OpenGl;
using Tao.OpenAl;
using SalmonViewer;

namespace EasyTourism3D
{
    class Assets
    {
        #region Singleton
        private static readonly Assets instancia = new Assets();

        private Assets() { }

        public static Assets Instance
        {
            get
            {
                return instancia;
            }
        }
        #endregion

        protected Dictionary<string, int> textures = new Dictionary<string, int>(10);
        public Dictionary<string, int> Textures
        {
            get { return textures; }            
        }

        protected Dictionary<string, ModelData> models = new Dictionary<string, ModelData>(4);
        public Dictionary<string, ModelData> Models
        {
            get { return models; }
        }

        private Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>(1);
        public Dictionary<string, SoundEffect> Sounds
        {
            get { return sounds; }
        }

        #region Carregamento de Texturas
        public void loadTextures()
        {
            Dictionary<String, String> listaTexturas = new Dictionary<string, string>(1);

            listaTexturas.Add("Estrada", "street_5.jpg");

            listaTexturas.Add("SkyboxNorteNight", "nightsky_north.jpg");
            listaTexturas.Add("SkyboxSulNight", "nightsky_south.jpg");

            listaTexturas.Add("SkyboxOesteNight", "nightsky_west.jpg");
            listaTexturas.Add("SkyboxEsteNight", "nightsky_east.jpg");

            listaTexturas.Add("SkyboxCeuNight", "nightsky_up.jpg");
            listaTexturas.Add("SkyboxChaoNight", "nightsky_down.jpg");

            listaTexturas.Add("SkyboxNorteDay", "sahara_north.jpg");
            listaTexturas.Add("SkyboxSulDay", "sahara_south.jpg");

            listaTexturas.Add("SkyboxOesteDay", "sahara_west.jpg");
            listaTexturas.Add("SkyboxEsteDay", "sahara_east.jpg");

            listaTexturas.Add("SkyboxCeuDay", "sahara_up.jpg");
            listaTexturas.Add("SkyboxChaoDay", "sahara_down.jpg");

            listaTexturas.Add("EdificioGenerico1", "building_facade.jpg");
            listaTexturas.Add("Interseccao", "interseccao.jpg");

            listaTexturas.Add("Snowy", "neve.jpg");
            listaTexturas.Add("Clear", "talya_floorbricks1a.jpg");

            listaTexturas.Add("Seta", "seta.jpg");

            listaTexturas.Add("Arvore1", "maplebranch.png");

            foreach (KeyValuePair<String, String> t in listaTexturas)
            {                
                this.loadTexture(t.Key, t.Value);
            }
        }

        private void loadTexture(String key, String value)
        {
            int id = 0;

            if (key.Length == 0 || value.Length == 0)
            {
                Console.WriteLine("ERRO: Key:Value errados ao carregar textura");
                return;
            }

            if (File.Exists(Settings.Default.TextureDirectory + value))
            {
                id = Ilut.ilutGLLoadImage(Settings.Default.TextureDirectory + value);
                this.Textures.Add(key, id);

                if (id != 0)
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);                        
                        Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);
                        Ilut.ilutGLBuildMipmaps();
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                }
                else
                {
                    Console.WriteLine("AVISO: A Textura '{0}' existe mas não foi possível carregá-la", value);
                }
            }
            else
            {
                Console.WriteLine("AVISO: A Textura '{0}' não existe.", value);
            }
        }

        #endregion

        #region Carregamento de Modelos
        public void loadModels()
        {
            Dictionary<String, String> listaModelos = new Dictionary<string, string>(1);

            listaModelos.Add("Turista", "Arthas.3ds");
            listaModelos.Add("Castelo", "castelo.3ds");
            listaModelos.Add("CavaloTroia", "cavalo_troia.3ds");
            listaModelos.Add("Workshop", "WarcraftHumanWorkshop.3ds");
            listaModelos.Add("GryphonAviary", "GryphonAviary.3ds");

            listaModelos.Add("AltarOfKings", "AltarOfKings.3ds");

            listaModelos.Add("HumanBarracks", "HumanBarracks.3ds");
            listaModelos.Add("BridgeObelisk", "BridgeObelisk.3ds");
            listaModelos.Add("DragonRoostBlack", "DragonRoostBlack.3ds");
            listaModelos.Add("Frostmourne", "Frostmourne.3ds");
            listaModelos.Add("AltarOfElders", "AltarOfElders.3ds");
            listaModelos.Add("Graveyard", "Graveyard.3ds");
            listaModelos.Add("BearDen", "BearDen.3ds");
            listaModelos.Add("TreeofLife", "TreeofLife.3ds");
            listaModelos.Add("TownHall", "TownHall.3ds");
            listaModelos.Add("FountainOfLifeBlood", "FountainOfLifeBlood.3ds");
            listaModelos.Add("Waygate", "Waygate.3ds");
            listaModelos.Add("ElvenVillageBuilding0", "ElvenVillageBuilding0.3ds");

            listaModelos.Add("CityBuildingSmall0_2", "CityBuildingSmall0_2.3ds");
            listaModelos.Add("CityBuildingSmall0_0", "CityBuildingSmall0_0.3ds");
            listaModelos.Add("CityBuildingLarge_0", "CityBuildingLarge_0.3ds");                      

            foreach (KeyValuePair<String, String> m in listaModelos)
            {
                this.loadModel(m.Key, m.Value);

                if (this.Models.ContainsKey(m.Key))
                {
                    /**
                     *  Para já está aqui. Irá ser lido do ficheiro XML
                     */
                    switch (m.Key)
                    {
                        case "Turista":
                            {
                                this.Models[m.Key].Translacao.set(0.5, 0.0, 1.0);
                                this.Models[m.Key].Escala.set(0.005, 0.005, 0.005);
                                break;
                            }

                        case "Castelo":
                            {
                                this.Models[m.Key].Escala.set(0.1, 0.1, 0.1);
                                this.Models[m.Key].Translacao.set(0.0, -1.0, 0.0);
                                break;
                            }

                        case "CavaloTroia":
                            {
                                this.Models[m.Key].Escala.set(0.01, 0.01, 0.01);
                                this.Models[m.Key].Rotacao.set(0.0, 1.0, 0.0);
                                this.Models[m.Key].Graus = 90.0;
                                this.Models[m.Key].Translacao.set(0.0, 3.8, 0.0);
                                break;
                            }

                        default:
                            {
                                this.Models[m.Key].Escala.set(0.02, 0.02, 0.02);
                                //this.Models[m.Key].Rotacao.set(0.0, 1.0, 0.0);
                                //this.Models[m.Key].Graus = 90.0;
                                this.Models[m.Key].Translacao.set(0.0, 1.0, 0.0);
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("ERRO: Não foi possível associar o modelo");
                }
            }
        }

        private void loadModel(String key, String value)
        {
            if (key.Length == 0 || value.Length == 0)
            {
                Console.WriteLine("ERRO: Key:Value errados ao carregar modelo");
                return;
            }

            if (File.Exists(Settings.Default.ModelDirectory + value))
            {
                FileInfo fi = new FileInfo(Settings.Default.ModelDirectory + value);
                ModelData info = new ModelData();

                switch (fi.Extension)
                {
                    case ".3ds":
                        {
                            info.Tipo = ModelData.TipoModelo.ThreeDS;
                            break;
                        }

                    case ".ms3d":
                        {
                            info.Tipo = ModelData.TipoModelo.Milkshape;
                            break;
                        }

                    default:
                        {
                            info.Tipo = ModelData.TipoModelo.Indefinido;
                            break;
                        }
                }

                info.NomeModelo = fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
                info.Model = new ThreeDSFile(Settings.Default.ModelDirectory + value).Model;

                this.Models.Add(key, info);
            }
            else
            {
                Console.WriteLine("AVISO: O Modelo '{0}' não existe.", value);
            }
        }

        #endregion

        #region Carregamento de Som
        public void loadSounds()
        {
            Dictionary<String, String> soundList = new Dictionary<string, string>(1);

            soundList.Add("Vento", "WindLoopStereo.wav");
            soundList.Add("Chuva", "RainAmbience.wav");
            soundList.Add("MusicaAmbiente1", "Human1.wav");
            soundList.Add("MusicaAmbiente2", "NightElf2.wav");

            soundList.Add("AltarOfKingsWhat1", "AltarOfKingsWhat1.wav");
            soundList.Add("GryphonAviaryWhat1", "GryphonAviaryWhat1.wav");
            soundList.Add("WorkshopWhat1", "WorkshopWhat1.wav");

            soundList.Add("HeroStep3", "HeroStep3.wav");
            
            foreach (KeyValuePair<String, String> t in soundList)
            {
                this.loadSound(t.Key, t.Value);
            }
        }

        private void loadSound(String key, String value)
        {
            int format, length, sourceId, bufferId;
            float frequency;
            IntPtr buffer = IntPtr.Zero;

            if (key.Length == 0 || value.Length == 0)
            {
                Console.WriteLine("ERRO: Key:Value errados ao carregar som");
                return;
            }

            if (File.Exists(Settings.Default.SoundDirectory + value))
            {                
                SoundEffect sound = null;
                
                //if (sourceId != 0)
                //{
                    buffer = Alut.alutLoadMemoryFromFile(Settings.Default.SoundDirectory + value, out format, out length, out frequency);

                    Al.alGenBuffers(1, out bufferId);
                    Al.alGenSources(1, out sourceId);
                    Al.alBufferData(bufferId, format, buffer, length, (int)frequency);

                    float gain = 1.0f;

                    if (key == "MusicaAmbiente1")
                    {
                        gain = 0.5f;
                    }

                    sound = new SoundEffect(sourceId, bufferId, buffer, new Vector3D(0.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 0.0), true, 1.0f, gain);
                    sound.SoundName = key;
                    sound.setup();
                //}
                //else
                //{
                //    Console.WriteLine("AVISO: O Som '{0}' existe mas não foi possível carregá-lo", value);
                //}

                this.Sounds.Add(key, sound);
            }
            else
            {
                Console.WriteLine("AVISO: O Som '{0}' não existe.", value);
            }
        }        
        #endregion
    }
}
