using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicios1e2
{
    public partial class Form1 : Form
    {
        String nomeSerie = "som";
        int xAtual = 0;
        int frequencia = 7;

        double intervaloX = 10;
        double minimoX = 0;
        double maximoX = 100;

        double intervaloY = 10;
        double minimoY = 0;
        double maximoY = 100;


        public Form1()
        {
            InitializeComponent();

            InciaGrafico(grafico);
            Teste();
        }

        private void Teste()
        {
            int Taq = 5;
            int Fs = 200;
            Double Ts = 1.0 / Fs;
            int n = Taq * Fs;

            int i = 0;
            double[] t = new double[n];
            double[] inreal = new double[n];
            double[] inimag = new double[n];
            double[] outreal = new double[n];
            double[] outimag = new double[n];
            double[] dft = new double[n];
            
            for (i = 0; i < n; i++)
            {
                t[i] = i * Ts;
                inreal[i] = Math.Sin(2 * Math.PI * 30 * t[i]);
            }

            Dft.computeDft(inreal, inimag, outreal, outimag);

            for (i = 0; i < n; i++)
            {
                dft[i] = (float)Math.Sqrt(outreal[i] * outreal[i] + outimag[i] * outimag[i]);
                grafico.Series[nomeSerie].Points.AddXY(t[i], dft[i]);
            }


        }

        private void InciaGrafico(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            System.Windows.Forms.DataVisualization.Charting.Series dados;

            chart.Series.Clear();
            chart.Series.Add(nomeSerie);

            dados = chart.Series[nomeSerie];

            dados.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            dados.Color = Color.Red;
            dados.IsVisibleInLegend = false;

            chart.ChartAreas[0].AxisX.Interval = intervaloX;
            grafico.ChartAreas[0].AxisX.Minimum = minimoX;
            grafico.ChartAreas[0].AxisX.Maximum = maximoX;
        }

        private void InsereValorSerie(System.Windows.Forms.DataVisualization.Charting.Series dados, int valor)
        {
            dados.Points.AddXY(xAtual, valor);

            if(xAtual > grafico.ChartAreas[0].AxisX.Maximum + intervaloX)
            {
                grafico.ChartAreas[0].AxisX.Minimum += intervaloX;
                grafico.ChartAreas[0].AxisX.Maximum += intervaloX;
            }

            xAtual += frequencia;
        }

        private void grafico_Click(object sender, EventArgs e)
        {
           /* System.Windows.Forms.DataVisualization.Charting.Series dados = grafico.Series[nomeSerie];
            int res = new Random().Next() % 100;

            InsereValorSerie(dados, res);
            */
        }
    }
}
