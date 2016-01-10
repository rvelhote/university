using System;

namespace EasyTourism3D
{
    class EasyTourismMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            args = new String[7];
            args[0] = "u";
            args[1] = "p";
            args[2] = "4";
            args[3] = "1024x768";
            args[4] = "en-US";
            args[5] = "False";
            args[6] = "True";

            AppState.Instance.Username = args[0];
            AppState.Instance.Password = args[1];
            AppState.Instance.TourID = Convert.ToInt32(args[2]);

            String[] resolution = args[3].Split('x');
            AppState.Instance.Width = Convert.ToInt32(resolution[0]);
            AppState.Instance.Height = Convert.ToInt32(resolution[1]);

            AppState.Instance.Language = args[4];
            AppState.Instance.Fullscreen = Convert.ToBoolean(args[5]);
            AppState.Instance.SaveTour = Convert.ToBoolean(args[6]);

            new Simulation().executar();
        }
    }
}
