using System;
using SalmonViewer;

namespace EasyTourism3D
{
    class ModelData
    {
        private double graus = 0.0;

        public double Graus
        {
            get { return graus; }
            set { graus = value; }
        }

        private Vector3D escala = new Vector3D();

        public Vector3D Escala
        {
            get { return escala; }
            set { escala = value; }
        }
        private Vector3D rotacao = new Vector3D();

        public Vector3D Rotacao
        {
            get { return rotacao; }
            set { rotacao = value; }
        }
        private Vector3D translacao = new Vector3D();

        public Vector3D Translacao
        {
            get { return translacao; }
            set { translacao = value; }
        }

        private String nomeModelo;

        public String NomeModelo
        {
            get { return nomeModelo; }
            set { nomeModelo = value; }
        }

        public enum TipoModelo
        {
            Indefinido,
            ThreeDS,
            Milkshape
        }

        private TipoModelo tipo = TipoModelo.Indefinido;

        public TipoModelo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private SalmonViewer.Model model;

        public SalmonViewer.Model Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
