using System;
using System.Collections.Generic;

namespace MemorizadorEscrituras
{
    public class Escritura
    {
        private Referencia _referencia;
        private List<Palavra> _palavras;

        public Escritura(Referencia referencia, string texto)
        {
            _referencia = referencia;
            _palavras = new List<Palavra>();

            string[] pedacos = texto.Split(' ');
            foreach (var pedaco in pedacos)
            {
                _palavras.Add(new Palavra(pedaco));
            }
        }

        public void OcultarPalavrasAleatorias(int numeroParaOcultar)
        {
            Random random = new Random();
            int ocultadas = 0;

            while (ocultadas < numeroParaOcultar && !EstaCompletamenteOculta())
            {
                List<Palavra> disponiveis = new List<Palavra>();
                foreach (var p in _palavras)
                {
                    if (!p.EstaOculta())
                    {
                        disponiveis.Add(p);
                    }
                }

                if (disponiveis.Count == 0) break;

                int indiceAleatorio = random.Next(disponiveis.Count);
                disponiveis[indiceAleatorio].Ocultar();
                ocultadas++;
            }
        }

        public string ObterReferenciaTexto()
        {
            return _referencia.ObterTexto();
        }

        public string ObterTexto()
        {
            List<string> partes = new List<string>();
            foreach (var palavra in _palavras)
            {
                partes.Add(palavra.ObterTexto());
            }

            string textoCombinado = string.Join(" ", partes);
            return $"{_referencia.ObterTexto()} - {textoCombinado}";
        }

        public bool EstaCompletamenteOculta()
        {
            foreach (var palavra in _palavras)
            {
                if (!palavra.EstaOculta())
                {
                    return false;
                }
            }
            return true;
        }
    }
}