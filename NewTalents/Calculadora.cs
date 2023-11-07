using System;
using System.Collections.Generic;

namespace NewTalents
{
    public class Calculadora
    {

        private List<string> listahistorico;

        DateTime dataAtual = DateTime.Now;

        public Calculadora(string data)
        {
            listahistorico = new List<string>();
            this.dataAtual = DateTime.Now;
        }

        private void AdicionarAoHistorico(int res)
        {
            //listahistorico.Insert(0, "Res:" + res + " - data: " + data);
            // substitui a linha acima por essa
            listahistorico.Insert(0, "Res:" + res + " - data: " + dataAtual.ToString());
        }

        public int somar(int val1, int val2)
        {
            int res = val1 + val2;
            AdicionarAoHistorico(res);
            return res;
        }

        public int subtrair(int val1, int val2)
        {
            int res = val1 - val2;
            AdicionarAoHistorico(res);
            return res;
        }

        public int multiplicar(int val1, int val2)
        {
            int res = val1 * val2;
            AdicionarAoHistorico(res);
            return res;
        }

        public int dividir(int val1, int val2)
        {
            int res = val1 / val2;
            AdicionarAoHistorico(res);
            return res;
        }


        public List<string> historico()
        {
            const int historicoLimite = 3;
            if (listahistorico.Count > historicoLimite)
            {
                listahistorico.RemoveRange(historicoLimite, listahistorico.Count - historicoLimite);
            }
            else if (listahistorico.Count == 0)
            {

            }
            return listahistorico;
        }

        public void limparHistorico()
        {
            this.listahistorico.Clear();
        }
    }
}

