using System;

namespace EasyTourism3D
{
    interface IReal
    {        
        Vector3D Position { get; }
        CollisionBox ColisionArea { get; }
    }
}
