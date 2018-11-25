using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicios1e2
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public sealed class Dft
    {
        public static void computeDft(double[] inreal, double[] inimag, double[] outreal, double[] outimag)
        {
            int n = inreal.Length;
            for (int k = 0; k < n; k++)
            { // loop para cada ponto em frequencia
                double sumreal = 0;
                double sumimag = 0;
                for (int t = 0; t < n; t++)
                { // loop para cada amotra
                    double angle = 2 * Math.PI * t * k / n;
                    sumreal += inreal[t] * Math.Cos(angle) + inimag[t] * Math.Sin(angle);
                    sumimag += -inreal[t] * Math.Sin(angle) + inimag[t] * Math.Cos(angle);
                }
                outreal[k] = sumreal;
                outimag[k] = sumimag;
            }
        }
    }
}
