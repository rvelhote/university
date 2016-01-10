using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.DevIl;
using Tao.OpenAl;
using System.Collections.Generic;
using EasyTourism3D.Properties;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Simulation
    {
        /// <summary>
        /// 
        /// </summary>
        private Renderer renderer = new Renderer();

        /// <summary>
        /// 
        /// </summary>
        private Input input = new Input();

        /// <summary>
        /// 
        /// </summary>
        private Input Input
        {
            get { return input; }
            set { input = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Renderer Renderer
        {
            get { return renderer; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Tourist tourist = new Tourist();

        /// <summary>
        /// 
        /// </summary>
        public Tourist ActiveTourist
        {
            get { return tourist; }
            set { tourist = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private SoundManager soundManager = new SoundManager();

        /// <summary>
        /// 
        /// </summary>
        public SoundManager SoundManager
        {
            get { return soundManager; }
        }

        ///
        /// <summary>
        /// 
        /// </summary>
        List<IReal> collidible = new List<IReal>();

        /// <summary>
        /// 
        /// </summary>
        //private List<Cartography> estradas = new List<Cartography>(2);

        /// <summary>
        /// 
        /// </summary>
        //public List<Cartography> Estradas
        //{
        //    get { return estradas; }
        //}

        /// <summary>
        /// 
        /// </summary>
        //private List<PointOfInterest> attractions = new List<PointOfInterest>();

        /// <summary>
        /// 
        /// </summary>
        //public List<PointOfInterest> Attractions
        //{
        //    get { return attractions; }
        //}

        /// <summary>
        /// 
        /// </summary>
        private Atmosphere atmophere = new Atmosphere();

        /// <summary>
        /// 
        /// </summary>
        public Atmosphere AtmosphericConditions
        {
            get { return atmophere; }            
        }

        private Cartography cartography = new Cartography();

        public Cartography Cartography
        {
            get { return cartography; }            
        }

        private Tour tour = new Tour();

        public Tour CurrentTour
        {
            get { return tour; }            
        }

        private WebServiceData ws = new WebServiceData();

        public WebServiceData Ws
        {
            get { return ws; }
            set { ws = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullscreen"></param>
        public void executar()
        {
            AppState.Instance.setLanguage(AppState.Instance.Language);

            #region Inicializações Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA | Glut.GLUT_DEPTH);

            if (AppState.Instance.Fullscreen)
            {
                Glut.glutGameModeString(AppState.Instance.Width + "x" + AppState.Instance.Height + ":32");

                if (Glut.glutGameModeGet(Glut.GLUT_GAME_MODE_POSSIBLE) == 1)
                {
                    Glut.glutEnterGameMode();
                    Glut.glutSetCursor(Glut.GLUT_CURSOR_NONE);
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                Glut.glutInitWindowSize(AppState.Instance.Width, AppState.Instance.Height);
                Glut.glutCreateWindow(Settings.Default.ApplicationName + "-" + Settings.Default.VersionNumber);
            }
            #endregion

            #region Inicializações OpenGL
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);

            Gl.glEnable(Gl.GL_POLYGON_SMOOTH);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glEnable(Gl.GL_NORMALIZE);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_AUTO_NORMAL);
            //Gl.glEnable(Gl.GL_CULL_FACE);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            #endregion
            
            Camera cam = new Camera();
            cam.IsActive = true;
            cam.Following = (ThreeDObject)this.ActiveTourist;
            Camera.CameraList.Add(cam);

            this.Renderer.Atmosphere = this.AtmosphericConditions;
           
            #region Inicialização do DevIL, Alut e bibliotecas associadas
                Il.ilInit();
                Ilut.ilutInit();
                Ilut.ilutRenderer(Ilut.ILUT_OPENGL);                      

                Alut.alutInit();
            #endregion            

            #region Carregar os Recursos

                Console.WriteLine(AppState.Instance.ResourceManager.GetString("LoadingTextures"));
                Assets.Instance.loadTextures();

                Console.WriteLine(AppState.Instance.ResourceManager.GetString("Loading3DS"));
                Assets.Instance.loadModels();

                Console.WriteLine(AppState.Instance.ResourceManager.GetString("LoadingSounds"));
                Assets.Instance.loadSounds();

            #endregion

            #region Skybox
                Skybox skybox = new Skybox();
                skybox.createDisplayList();
                this.Renderer.ObjectosCena.Add(skybox);
            #endregion

            #region Terreno
                Terrain terreno = new Terrain();            
                terreno.createDisplayList();
                this.Renderer.ObjectosCena.Add(terreno);
            #endregion            

            #region Sol
                Sun sol = new Sun();
                this.Renderer.IluminacaoCena.Add(sol);
            #endregion

            #region Carregamento dos Dados obtidos atrávés do WebService
            this.Ws.loadTour(ref this.tour);
            this.Ws.loadCartography(ref this.cartography, this.tour.cityID);
            AppState.Instance.CurrentDate = this.tour.begin;
            #endregion

            #region Adicionar Elementos "Colidíveis"
            foreach (PointOfInterest p in this.Cartography.pointsOfInterest)
            {
                this.collidible.Add(p);
            }

            foreach (GenericObject go in this.Cartography.genericObjects)
            {
                if (go is RandomBuilding)
                {
                    this.collidible.Add(go);
                }
            }
            #endregion

            #region Adicionar Elementos Visitáveis
            PointOfInterest poi;
            foreach (ToVisit t in this.CurrentTour.toVisit)
            {
                poi = this.Cartography.getPointOfInterestWithID(t.attractionID);

                poi.ToVisit = true;
                poi.Visited = t.visited;
            }
            #endregion

            #region Ajustes à Área de Colisão dos Modelos
            String[] adjustment;
            String[] dimensions;
            foreach (PointOfInterest col in this.Cartography.pointsOfInterest)
            {                
                adjustment = ModelSettings.Default[col.ModelName + "Adjustment"].ToString().Split('|');
                col.ColisionArea.Adjustment.set(Double.Parse(adjustment[0]), Double.Parse(adjustment[1]), Double.Parse(adjustment[2]));

                dimensions = ModelSettings.Default[col.ModelName + "Dimensions"].ToString().Split('|');
                col.ColisionArea.Dimensions.set(Double.Parse(dimensions[0]), Double.Parse(dimensions[1]), Double.Parse(dimensions[2]));

                col.SoundName = ModelSettings.Default[col.ModelName + "SoundName"].ToString();
                col.ColisionArea.Visible = true;
            }
            #endregion

            #region Turista
            this.ActiveTourist.ModelName = "Turista";
                this.ActiveTourist.setPosicao(20.0, -0.9, 0.0);

                this.ActiveTourist.SoundName = "HeroStep3";
                this.ActiveTourist.setSoundPosition();
                this.Renderer.ObjectosCena.Add(this.ActiveTourist);
            #endregion

            //  TODO: Cria uma propriedade para isto
            new Ambiente().definirProperiedades();
            
            Glut.glutDisplayFunc(new Glut.DisplayCallback(this.Renderer.render));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(this.Input.tecladoNormal));
            Glut.glutKeyboardUpFunc(new Glut.KeyboardUpCallback(this.Input.tecladoNormalUp));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(this.Renderer.redimensionar));
            Glut.glutSpecialFunc(new Glut.SpecialCallback(this.Input.tecladoEspecial));

            Glut.glutTimerFunc(30, new Glut.TimerCallback(this.timer), 0);

            this.createPopupMenus();

            if (this.CurrentTour.toVisit.Count > 0)
            {
                Messaging.Instance.Permanent.Add(AppState.Instance.ResourceManager.GetString("ToVisitLabel") + ":");                

                foreach (ToVisit tv in this.CurrentTour.toVisit)
                {
                    poi = this.Cartography.getPointOfInterestWithID(tv.attractionID);

                    if (poi.ToVisit && !poi.Visited)
                    {
                        Messaging.Instance.Permanent.Add("- " + poi.Nome);
                    }
                    else
                    {
                        Messaging.Instance.Permanent.Add("- " + poi.Nome + " (" + AppState.Instance.ResourceManager.GetString("VisitedLabel") + ")");
                    }
                }                
            }
            else
            {
                Messaging.Instance.Permanent.Add(AppState.Instance.ResourceManager.GetString("NoPOIsToVisit"));
            }


            #region Inicializar Música Ambiente
                this.SoundManager.switchAmbientMusicTo("MusicaAmbiente1");
            #endregion

            this.Renderer.Map = this.Cartography;

            Glut.glutMainLoop();          
        }

        //private void saveTour()
        //{
        //    if (this.CurrentTour.toVisit.Count > 0)
        //    {
        //        EasyTourismServices webService = new EasyTourismServices();

        //        List<WebService.ToVisit> tv = new List<WebService.ToVisit>();
        //        WebService.ToVisit[] tvArray;

        //        WebService.ToVisit t;

        //        /// TODO: Chuta logo para o Array[]!
        //        foreach (PointOfInterest p in this.CurrentTour.toVisit)
        //        {
        //            if (p.ToVisit && p.Visited)
        //            {
        //                t = new WebService.ToVisit();

        //                t.id = p.ID;
        //                t.visited = p.Visited;

        //                tv.Add(t);
        //            }
        //        }

        //        tvArray = new ToVisit[tv.Count];
        //        tv.CopyTo(tvArray);

        //        //webService.SaveTour("12345678-9012-3456-7890-123456789013", this.CurrentTour.tourID, tvArray);
        //    }
        //}

        private void timer(int valor)
        {
            if (this.Input.ExitingApplication)
            {
                if (AppState.Instance.SaveTour)
                {
                    this.Ws.save(ref this.tour, ref this.cartography);
                }

                Environment.Exit(0);
            }

            if (this.Input.SimulationSpeedChanged)
            {
                Messaging.Instance.Information.Enqueue(AppState.Instance.ResourceManager.GetString("SimulationSpeedChanged") + ": " + AppState.Instance.ResourceManager.GetString("SimulationSpeed" + AppState.Instance.CurrentSimulationSpeed.ToString()));
                this.Input.SimulationSpeedChanged = false;
            }

            #region Lidar com Input do Utilizador
            if (this.Input.keyPressed())
            {                
                Camera cam = Camera.getCurrentActiveCamera();

                if (this.Input.isMoving())
                {
                    if (this.Input.TeclaW)
                    {
                        if (!this.ActiveTourist.collidesWithObjects(this.ActiveTourist.calculateNextPosition(Tourist.CharacterDirection.Front), this.collidible))
                        {
                            this.ActiveTourist.moveForward();
                            cam.moveForward();
                        }
                    }
                    else if (this.Input.TeclaS)
                    {
                        if (!this.ActiveTourist.collidesWithObjects(this.ActiveTourist.calculateNextPosition(Tourist.CharacterDirection.Back), this.collidible))
                        {
                            this.ActiveTourist.moveBackward();
                            cam.moveBackward();
                        }
                    }

                    if (this.Input.TeclaW || this.Input.TeclaS)
                    {
                        /**
                         * 
                         */
                        String streetName = this.ActiveTourist.getCurrentRoad(this.Cartography.segments);

                        if (streetName.Length > 0)
                        {                            
                            Messaging.Instance.Information.Enqueue(streetName);
                        }

                        /**
                         * 
                         */
                        this.ActiveTourist.visitedPointOfInterest(this.Cartography.pointsOfInterest);
                    }

                    if (this.Input.TeclaA)
                    {
                        this.ActiveTourist.moveLeft();
                        cam.moveLeft();
                    }                    

                    if (this.Input.TeclaD)
                    {
                        this.ActiveTourist.moveRight();
                        cam.moveRight();
                    }
                }

                if (this.Input.TeclaT)
                {
                    cam.lookUp();
                }

                if (this.Input.TeclaG)
                {
                    cam.lookDown();
                }

                if (this.Input.Tab)
                {                    
                    cam.mudarCamera();
                    this.Input.Tab = false;
                }

                if (this.Input.Plus)
                {                    
                    this.SoundManager.increaseVolume();
                    this.Input.Plus = false;
                }

                if (this.Input.Minus)
                {                    
                    this.SoundManager.decreaseVolume();
                    this.Input.Minus = false;
                }
            }
            #endregion

            if (!this.tourOver && this.ActiveTourist.checkVisitComplete(this.Cartography.pointsOfInterest))
            {
                Messaging.Instance.Information.Enqueue(AppState.Instance.ResourceManager.GetString("TourOver"));
                Messaging.Instance.Permanent.Add("");
                Messaging.Instance.Permanent.Add(AppState.Instance.ResourceManager.GetString("TourOverPressESC"));
                this.tourOver = true;
            }

            Messaging.Instance.stateCheck();
            AppState.Instance.clockForward();
            this.AtmosphericConditions.weatherStateCheck();            

            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(30, this.timer, valor);            
        }

        public bool tourOver = false;

        private void createPopupMenus()
        {
            int menu;

            menu = Glut.glutCreateMenu(this.processMenuEvents);
            
            Glut.glutAddMenuEntry(AppState.Instance.ResourceManager.GetString("Music1"), 11);
            Glut.glutAddMenuEntry(AppState.Instance.ResourceManager.GetString("Music2"), 12);   
            
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);
        }

        //private void loadWebServiceData()
        //{
        //    String[] adjustment;
        //    String[] dimensions;

        //    Console.WriteLine("A aceder ao WebService...");
        //    EasyTourismServices webService = new EasyTourismServices();

        //    WebService.Cartography c = webService.CityCartographyFull(1);

        //    Intersection itr;
        //    foreach (WebService.Intersection i in c.intersections)
        //    {
        //        itr = new Intersection(i.id);
        //        itr.Position.set(i.position.x, i.position.y, i.position.z);
        //        this.Cartography.intersections.Add(itr);
        //    }

        //    RoadSegment rs;
        //    foreach (WebService.RoadSegment r in c.roadSegments)
        //    {
        //        rs = new RoadSegment(this.Cartography.getIntersectionWithID(r.idIntersectionBegin), this.Cartography.getIntersectionWithID(r.idIntersectionEnd));
        //        rs.SegmentName = r.name;
        //        this.Cartography.segments.Add(rs);
        //    }

        //    PointOfInterest poi;
        //    foreach (WebService.PointOfInterest p in c.pointsOfInterest)
        //    {
        //        poi = new PointOfInterest(new Vector3D(p.position.x, p.position.y, p.position.z));
        //        poi.ID = p.id;
        //        poi.ModelName = p.model;

        //        /// TODO: Alterar para "Nome"
        //        poi.Nome = p.description;
        //        poi.Description = p.description;

        //        poi.Facing = p.facing;

        //        for (int i = 0; i < p.features.Length; i++)
        //        {
        //            poi.Features.Add(p.features[i]);
        //        }

        //        adjustment = new String[0];
        //        dimensions = new String[0];


        //        //NameValueConfigurationCollection nvc = ModelSettings.Default.Properties;
        //        //Console.WriteLine(ConfigurationSettings.AppSettings.AllKeys.);

        //        //if (poi.ModelName == "Castelo")
        //        //{

        //        //    //if (ModelSettings.Default.PropertyValues..Contains(poi.ModelName + "Adjustment"))
        //        //    //{
        //        //    adjustment = ModelSettings.Default[poi.ModelName + "Adjustment"].ToString().Split('|');
        //        //    //}

        //        //    //if (ModelSettings.Default.SettingsKey.Contains(poi.ModelName + "Dimensions"))
        //        //    //{
        //        //    dimensions = ModelSettings.Default[poi.ModelName + "Dimensions"].ToString().Split('|');
        //        //    //}

        //        //    //if (ModelSettings.Default.SettingsKey.Contains(poi.ModelName + "SoundName"))
        //        //    //{
        //        //    poi.SoundName = ModelSettings.Default[poi.ModelName + "SoundName"].ToString();
        //        //    //}

        //        //    if (adjustment.Length > 0)
        //        //    {
        //        //        poi.ColisionArea.Adjustment.set(Double.Parse(adjustment[0]), Double.Parse(adjustment[1]), Double.Parse(adjustment[2]));
        //        //    }

        //        //    if (dimensions.Length > 0)
        //        //    {
        //        //        poi.ColisionArea.Dimensions.set(Double.Parse(dimensions[0]), Double.Parse(dimensions[1]), Double.Parse(dimensions[2]));
        //        //    }

        //        //    poi.ColisionArea.Visible = true;
        //        //}

        //        poi.ColisionArea.Adjustment.set(0, 0, -1.5);
        //        poi.ColisionArea.Dimensions.set(3, 1, 2);

        //        this.collidible.Add(poi);
        //        this.Cartography.pointsOfInterest.Add(poi);
        //    }

        //    GenericObject go;
        //    foreach (WebService.GenericObject g in c.genericObjects)
        //    {
        //        go = GenericObjectFactory.getGenericObject(g.type);
        //        go.Position.set(g.position.x, g.position.y, g.position.z);

        //        if (go is RandomBuilding)
        //        {
        //            this.collidible.Add(go);
        //        }

        //        this.Cartography.genericObjects.Add(go);
        //    }


        //    //WebService.Tour t = webService.TourForTourist("12345678-9012-3456-7890-123456789013", 4);
        //    WebService.Tour t = webService.TourForTourist("u", "p", 4);
        //    this.CurrentTour.begin = t.begin;            
        //    this.CurrentTour.tourID = t.tourID;

        //    for (int i = 0; i < t.toVisit.Length; i++)
        //    {
        //        poi = this.Cartography.getPointOfInterestWithID(t.toVisit[i].id);

        //        poi.ToVisit = true;
        //        poi.Visited = t.toVisit[i].visited;
        //        poi.OrderVisit = t.toVisit[i].ordering;

        //        this.CurrentTour.toVisit.Add(poi);                
        //    }
        //}

        private void processMenuEvents(int option)
        {
            switch (option)
            {
                case 11: { this.SoundManager.switchAmbientMusicTo("MusicaAmbiente1"); break; }
                case 12: { this.SoundManager.switchAmbientMusicTo("MusicaAmbiente2"); break; }
            }    	            
        }
    }
}
