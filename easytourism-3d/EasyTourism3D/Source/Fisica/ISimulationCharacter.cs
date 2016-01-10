using System;
using System.Collections.Generic;

namespace EasyTourism3D
{
    /// <summary>
    /// Esta interface define que um determinado objecto pode colidir com outro. Isso implica que terá
    /// o método collidesWith que permitirá fazer esse teste
    /// </summary>
    interface ISimulationCharacter
    {
        /// <summary>
        /// Verifica se um object colide com outros que estão na lista de "objectos reais"
        /// </summary>
        /// <param name="futurePosition">A posição futura do objecto em questão. Um VectorXYZ</param>
        /// <param name="objects">A lista de objectos reais</param>
        /// <returns>True se colidiu; False se não colidiu</returns>
        bool collidesWithObjects(Vector3D futurePosition, List<IReal> objects);

        /// <summary>
        /// Verifica se um object colide com outros que estão na lista de estradas
        /// </summary>
        /// <param name="futurePosition">A posição futura do objecto em questão. Um VectorXYZ</param>
        /// <param name="roads">A lista de estradas com as quais vamos testar a colisão</param>
        /// <returns></returns>
        //bool collidesWithRoads(Vector3D futurePosition, List<Estrada> roads);

        //bool collidesWithVisitableArea(Vector3D futurePosition, List<IVisitable> pointsOfInterest);
    }
}