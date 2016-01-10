using System;

namespace EasyTourism3D
{
    /// <summary>
    /// Declara as operação que um objecto que seja Controlável (Camera, Turista) deve implementar
    /// </summary>
    interface IControllable
    {
        /// <summary>
        /// Velocidade a que se movimenta o Object
        /// </summary>
        double Velocity { get; set; }

        /// <summary>
        /// Ângulo que roda o objecto quando existe um movimento para a esquerda ou para a direita
        /// Este ângulo é expresso em Graus
        /// </summary>
        double RotationAngle { get; }

        /// <summary>
        /// Andar para a frente
        /// </summary>
        void moveForward();

        /// <summary>
        /// Andar para trás
        /// </summary>
        void moveBackward();

        /// <summary>
        /// Olhar para cima
        /// </summary>
        void lookUp();

        /// <summary>
        /// Olhar para baixo
        /// </summary>
        void lookDown();

        /// <summary>
        /// Rodar para a esquerda
        /// </summary>
        void moveLeft();

        /// <summary>
        /// Rodar para a direita
        /// </summary>
        void moveRight();
    }
}
