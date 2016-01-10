using System;
using System.Collections.Generic;
using Tao.OpenGl;
using Tao.OpenAl;

namespace EasyTourism3D
{
    /// <summary>
    /// O Turista da Simulação.
    /// 
    /// É IControllable porque pode movimentar-se
    /// É ISimulationCharacter porque pode colidir/intereagir com outros objectos no jogo
    /// É IAudible porque emite um som
    /// </summary>
    class Tourist : ThreeDObject, IControllable, ISimulationCharacter, IAudible
    {
        /// <summary>
        /// Indica a direcção em que a personagem se está a movimentar
        /// </summary>
        public enum CharacterDirection
        {
            Front,
            Back
        }

        private Guid touristID;

        public Guid TouristID
        {
            get { return touristID; }
            set { touristID = value; }
        }

        /// <summary>
        /// Velocidade de movimento
        /// </summary>
        private double velocity = 0.1;

        /// <summary>
        /// Ângulo de Rotação expresso em graus
        /// A rotação é efectuada sobre o próprio eixo da personagem
        /// </summary>
        private double rotationAngle = 5.0;

        /// <summary>
        /// Indica o nome da estrada em que a personagem está.
        /// </summary>
        private String currentRoad = "";

        /// <summary>
        /// Propriedade da variável currentRoad
        /// </summary>
        public String CurrentRoad
        {
            get { return currentRoad; }
            set { currentRoad = value; }
        }

        /// <summary>
        /// Indica qual foi o último Ponto de Interesse que o Turista visitou
        /// </summary>
        private PointOfInterest lastVisited;

        /// <summary>
        /// Propriedade da variável lastVisited
        /// </summary>
        public PointOfInterest LastVisited
        {
            get { return lastVisited; }
            set { lastVisited = value; }
        }


        /// <summary>
        /// Desenha o Objecto3D
        /// Override do método abstracto draw da classe ThreeDObject
        /// </summary>
        public override void draw()
        {
            if (this.Visible && Assets.Instance.Models.ContainsKey(this.ModelName))
            {
                ModelData modelo = Assets.Instance.Models[this.ModelName];

                Gl.glPushMatrix();
                    Gl.glTranslated(this.Position.Px, this.Position.Py, this.Position.Pz);
                    Gl.glRotated(Utilities.toDegrees(this.Angle), 0.0, 1.0, 0.0);
                    Gl.glScaled(modelo.Escala.Px, modelo.Escala.Py, modelo.Escala.Pz);
                    modelo.Model.Render();
                Gl.glPopMatrix();

                // TODO: Colocar no método do IAudible que está mais para baixo
                Al.alListener3f(Al.AL_POSITION, (float)this.Position.Px, (float)this.Position.Py, (float)this.Position.Pz);
                float[] mMatrix = new float[16];
	            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mMatrix);

                float[] vec = new float[6];
	            vec[0] = -mMatrix[2];
	            vec[1] = -mMatrix[6];
	            vec[2] = -mMatrix[10];
	            vec[3] = mMatrix[1];
	            vec[4] = mMatrix[5];
	            vec[5] = mMatrix[9];

                Al.alListenerfv(Al.AL_ORIENTATION, vec);
            }
        }

        /// <summary>
        /// Faz um teste de colisão do Turista com os Segmentos de Estrada para tentar determinar
        /// em que segmento se encontra actualmente.
        /// 
        /// O teste de colisão verifica se a posição actual do Turista XYZ está dentro dos limites de um
        /// qualquer segmento. A detecção da colisão é parecida com uma colisão XY porque não existem alturas
        /// </summary>
        /// <param name="segmentList">A Lista de Segmentos de Estrada existentes na simulação</param>
        /// <returns>O nome da rua</returns>
        /// 
        ///  TODO: Retornar bool e depois sacar o nome da estrada da propriedade CurrentRoad
        public String getCurrentRoad(List<RoadSegment> segmentList)
        {
            String name = "";

            foreach (RoadSegment t in segmentList)
            {
                if ((this.Position.Px >= t.begin.Position.Px - t.Area && this.Position.Px <= t.begin.Position.Px + t.Area && this.Position.Pz >= t.begin.Position.Pz + t.Area && this.Position.Pz <= t.end.Position.Pz - t.Area)
                    || (this.Position.Px <= t.begin.Position.Px && this.Position.Px >= t.end.Position.Px - t.Area && this.Position.Pz >= t.begin.Position.Pz - t.Area && this.Position.Pz <= t.begin.Position.Pz + t.Area))
                {
                    if (t.SegmentName != this.CurrentRoad && t.SegmentName.Length > 0)
                    {
                        name = t.SegmentName;
                        this.CurrentRoad = t.SegmentName;
                    }

                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// Calcula a posição seguinte da personagem para efeitos de colisão
        /// Apenas existem duas possibilidades de movimento (frente, trás) já que os movimentos
        /// Esquerda/Direita são rotações
        /// </summary>
        /// <param name="direction">A direcção em que se está a movimentar a personagem</param>
        /// <returns>Vector3D que indica a próxima posição</returns>
        public Vector3D calculateNextPosition(CharacterDirection direction)
        {
            Vector3D nextPosition = new Vector3D();

            if (direction == CharacterDirection.Front)
            {
                nextPosition.Px = this.Position.Px + Math.Cos(this.Angle) * this.Velocity;
                nextPosition.Pz = this.Position.Pz + Math.Sin(-this.Angle) * this.Velocity;
            }
            else if (direction == CharacterDirection.Back)
            {
                nextPosition.Px = this.Position.Px - Math.Cos(this.Angle) * this.Velocity;
                nextPosition.Pz = this.Position.Pz - Math.Sin(-this.Angle) * this.Velocity;
            }

            return nextPosition;
        }

        /// <summary>
        /// Faz um teste de colisão do Turista com a área Visitável de um Ponto de Interesse.
        /// A Área Visitável é apenas a área de colisão um pouco maior (*2)
        /// 
        /// Quando existe uma colisão com um Ponto de Interesse Visitável é mostrada a informação acerca
        /// das características da atracção.
        /// 
        /// Da mesma forma quando não existe nenhuma colisão e estava a ser mostrada informação sobre o ponto de interesse
        /// esta é eliminada
        /// </summary>
        /// <param name="list">Lista com os pontos de interesse presentes na simulaçao</param>
        /// <returns>Indica se foi visitado ou não um qualquer ponto de interesse que ainda não tenha sido visitado</returns>
        public bool visitedPointOfInterest(List<PointOfInterest> list)
        {
            bool visitedSomething = false;

            foreach (PointOfInterest poi in list)
            {
                if ((this.Position.Px <= poi.Position.Px + poi.ColisionArea.Adjustment.Px + poi.ColisionArea.Dimensions.Px * 2
                    && this.Position.Px >= poi.Position.Px + poi.ColisionArea.Adjustment.Px - poi.ColisionArea.Dimensions.Px * 2)

                    && (this.Position.Pz <= poi.Position.Pz + poi.ColisionArea.Adjustment.Pz + poi.ColisionArea.Dimensions.Pz * 2
                    && this.Position.Pz >= poi.Position.Pz + poi.ColisionArea.Adjustment.Pz - poi.ColisionArea.Dimensions.Pz * 2))
                {

                    if (poi.ToVisit && poi != this.LastVisited)
                    {
                        this.LastVisited = poi;
                        Messaging.Instance.addCharacteristics(poi);
                    }

                    if (!poi.Visited && poi.ToVisit)
                    {
                        Messaging.Instance.Information.Enqueue("Acabaste de visitar: " + poi.Nome);

                        Messaging.Instance.Permanent.Add("- " + poi.Nome + " (visitado)");
                        Messaging.Instance.Permanent.Remove("- " + poi.Nome);

                        poi.Visited = true;
                    }

                    visitedSomething = true;
                    break;                    
                }
            }

            if (!visitedSomething)
            {
                this.LastVisited = null;
                Messaging.Instance.removeCharacteristics();
            }

            return visitedSomething;
        }

        /// <summary>
        /// Verifica se o turista já visitou todas os Pontos de Interesse que estavam marcados
        /// </summary>
        /// <param name="list">A Lista de Pontos de Interesse presentes na Simulação</param>
        /// <returns>Se foi tudo visitado ou não</returns>
        /// 
        /// TODO: Melhorar isto para apenas testar com os pontos de interesse que estão para ser visitados em vez de verificar todos.
        public bool checkVisitComplete(List<PointOfInterest> list)
        {
            bool visitedAll = true;

            foreach (PointOfInterest p in list)
            {
                if (p.ToVisit && !p.Visited)
                {
                    visitedAll = false;
                    break;
                }
            }

            return visitedAll;
        }

        #region IControlavel Members
        /// <summary>
        /// Movimentar o Turista para a frente.
        /// Para chegar aqui já foi efectuado o teste de colisão (no Timer)
        /// </summary>
        /// 
        /// TODO: Estamos a calcular duas vezes a próxima posição trás. Aqui e no Timer ao efectuar o teste de colisão. Melhorar isto.
        public void moveForward()
        {
            Vector3D nextPosition = this.calculateNextPosition(CharacterDirection.Front);

            this.Position.Px = nextPosition.Px;
            this.Position.Pz = nextPosition.Pz;

            this.playSound();
        }

        /// <summary>
        /// Movimentar o Turista para a trás
        /// Para chegar aqui já foi efectuado o teste de colisão (no Timer)
        /// </summary>
        /// TODO: Estamos a calcular duas vezes a próxima posição para trás. Aqui e no Timer ao efectuar o teste de colisão.  Melhorar isto.
        public void moveBackward()
        {
            Vector3D nextPosition = this.calculateNextPosition(CharacterDirection.Back);

            this.Position.Px = nextPosition.Px;
            this.Position.Pz = nextPosition.Pz;

            this.playSound();
        }        

        /// <summary>
        /// Roda a personagem n Graus para a Esquerda
        /// O Angulo é armazenado em Radianos
        /// </summary>
        public void moveLeft()
        {
            this.Angle += Utilities.toRadians(this.RotationAngle);
        }

        /// <summary>
        /// Roda a personagem n Graus para a Direita
        /// O Angulo é armazenado em Radianos
        /// </summary>
        public void moveRight()
        {
            this.Angle -= Utilities.toRadians(this.RotationAngle);
        }

        /// <summary>
        /// Propriedade que retorna a velocidade do Turista.
        /// Dependende da velocidade actual da Simulação
        /// 
        /// Por omissão retorna 0.1
        /// </summary>
        public double Velocity
        {
            get 
            {
                double v = 0.1;

                switch (AppState.Instance.CurrentSimulationSpeed)
                {
                    case AppState.SimulationSpeed.Normal:
                        {
                            v = 0.1;
                            break;
                        }

                    case AppState.SimulationSpeed.Fast:
                        {
                            v = 0.2;
                            break;
                        }

                    case AppState.SimulationSpeed.Faster:
                        {
                            v = 0.4;
                            break;
                        }

                    case AppState.SimulationSpeed.SuperFast:
                        {
                            v = 0.8;
                            break;
                        }
                }

                return v; 
            }
            set { this.velocity = value; }
        }

        /// <summary>
        /// Retorna o Angulo de Rotação do Turista
        /// </summary>
        public double RotationAngle
        {
            get { return this.rotationAngle; }
        }

        #region Não Implementados da Interface IControlavel
            /// <summary>
            /// Reservado para suporte a movimento de Rato para Cima
            /// </summary>
            /// <exception cref="NotImplementedException">NotImplementedException</exception>
            public void lookUp()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reservado para suporte a movimento de Rato para Baixo
            /// </summary>
            /// <exception cref="NotImplementedException">NotImplementedException</exception>
            public void lookDown()
            {
                throw new NotImplementedException();
            }
        #endregion
        #endregion

        #region ISimulationCharacter Members

        /// <summary>
        /// Detecta de existiu uma colisão com Outros objectos 3D da simulação.
        /// Esses objectos deverão implementar a interface IReal que indica que um é objecto é real e colidível
        /// </summary>
        /// <param name="futurePosition">A posição futura da personagem</param>
        /// <param name="objects">Os objectos 3D da simulação. Provavelmente são os mesmos que estão a ser enviados para o Renderer</param>
        /// <returns>Se colidiu ou não</returns>
        /// 
        /// TODO: Extender a outros tipos de objectos
        public bool collidesWithObjects(Vector3D futurePosition, List<IReal> objects)
        {
            bool collided = false;

            foreach (IReal obj in objects)
            {
                if ((futurePosition.Px <= obj.Position.Px + obj.ColisionArea.Adjustment.Px + obj.ColisionArea.Dimensions.Px
                        && futurePosition.Px >= obj.Position.Px + obj.ColisionArea.Adjustment.Px - obj.ColisionArea.Dimensions.Px)

                        && (futurePosition.Pz <= obj.Position.Pz + obj.ColisionArea.Adjustment.Pz + obj.ColisionArea.Dimensions.Pz
                        && futurePosition.Pz >= obj.Position.Pz + obj.ColisionArea.Adjustment.Pz - obj.ColisionArea.Dimensions.Pz))
                {                        
                    collided = true;
                    break;
                }                
            }

            return collided;
        }
        #endregion

        #region IAudible Members

        /// <summary>
        /// Nome do Som associado ao Turista
        /// </summary>
        private String soundName;

        /// <summary>
        /// Propriedade que permite retornar e definir o nome do som associado ao turista
        /// </summary>
        public string SoundName
        {
            get { return soundName; }
            set { soundName = value; }
        }

        /// <summary>
        /// Define a posição em que o som se encontra. Neste caso seguirá sempre o Turista
        /// </summary>
        public void setSoundPosition()
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                SoundEffect s = Assets.Instance.Sounds[this.SoundName];
                s.setPosition(this.Position);

                //  TODO: Suportar este tipo de opções na Classe SoundEffect
                Al.alSourcef(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_ROLLOFF_FACTOR, 20.0f);
                Al.alSourcei(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_LOOPING, Al.AL_FALSE);
            }
        }

        /// <summary>
        /// Não implementado
        /// </summary>
        /// <exception cref="NotImplementedException">NotImplementedException</exception>
        /// <param name="position"></param>
        public void setSoundPosition(Vector3D position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Contador de Ticks para tocar o som da personagem.
        /// Convém apenas tocar o som de X em X para evitar que este fique muito acelerado. Como o som da
        /// personagem se trata de passos e o movimento frente/trás é muito rápido  ficou definido que de 500
        /// em 500 Ms será tocado o som
        /// </summary>
        private int soundTick = 0;

        /// <summary>
        /// Propriedade que permite retornar e definir o tick actual
        /// </summary>
        public int SoundTick
        {
            get { return soundTick; }
            set { soundTick = value; }
        }

        /// <summary>
        /// Inicia o som definido para a personagem após. Válido de 500 em 500 ticks
        /// </summary>
        public void playSound()
        {
            this.SoundTick += 50;

            if (Assets.Instance.Sounds.ContainsKey(this.SoundName) && this.SoundTick % 500 == 0)
            {
                SoundEffect s = Assets.Instance.Sounds[this.SoundName];
                s.setPosition(this.Position);
                s.playSound();

                this.SoundTick = 0;
            }            
        }

        /// <summary>
        /// Pára o som definido para a personagem
        /// </summary>
        public void stopSound()
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                SoundEffect s = Assets.Instance.Sounds[this.SoundName];
                s.stopSound();
            }
        }

        #endregion
    }
}