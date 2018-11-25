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

        int intervaloX = 10;
        int minimoX = 0;
        int maximoX = 100;

        int intervaloY = 10;
        int minimoY = 0;
        int maximoY = 100;


        public Form1()
        {
            InitializeComponent();

            InciaGrafico(grafico);
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
            System.Windows.Forms.DataVisualization.Charting.Series dados = grafico.Series[nomeSerie];
            int res = new Random().Next() % 100;

            InsereValorSerie(dados, res);
        }
    }
}
