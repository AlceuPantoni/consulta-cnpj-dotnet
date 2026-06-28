using ConsultaCnpj.Services;
using System.Diagnostics;

namespace ConsultaCnpj.Forms
{
    public partial class MainForm : Form
    {
        private readonly CnpjProcessingController _controller;
        private string _inputPath = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            var excel = new ExcelService();
            var cnpjService = new CnpjService();

            _controller = new CnpjProcessingController(excel, cnpjService);

            _controller.Progresso += Controller_Progresso;
            _controller.Log += Controller_Log;

            btnIniciar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvarResultado.Enabled = false;
        }

        private void btnCarregarPlanilha_MouseClick(object sender, MouseEventArgs e)
        {
            using var openFileDialog = new OpenFileDialog{Filter = "Excel Files|*.xlsx"};

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _inputPath = openFileDialog.FileName;
                    txtLocalArquivo.Text = _inputPath;

                    _controller.CarregarArquivo(_inputPath);

                    lblStatusArquivo.Text = "Arquivo válido carregado";
                    lblProgStatus1.Text = $"Aguardando iniciar consultas - Total: {_controller.Cnpjs.Count} CNPJs";

                    btnIniciar.Enabled = _controller.Cnpjs.Count > 0;
                    btnCancelar.Enabled = false;
                    btnSalvarResultado.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblStatusArquivo.Text = "O arquivo carregado não é válido";
                    lblProgStatus1.Text = $"Consultas não iniciadas. {ex.Message}";
                    btnIniciar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSalvarResultado.Enabled = false;
                }
            }
        }

        private async void btnIniciar_MouseClick(object sender, MouseEventArgs e)
        {
            btnIniciar.Enabled = false;
            btnCarregarPlanilha.Enabled = false;
            btnCancelar.Enabled = true;

            progBar.Value = 0;
            lblProgStatus1.Text = "Consultas em execução... aguarde finalizar ou cancele, caso necessário";

            await _controller.ExecutarConsultaAsync();

            btnCancelar.Enabled = false;
            btnCarregarPlanilha.Enabled = true;
            btnSalvarResultado.Enabled = true;

            if (_controller.Cancelado)
            {
                lblProgStatus1.Text = $"Execução cancelada - {_controller.Resultados.Count} CNPJs foram consultados";
                progBar.Value = 0;
            }
            else
            {
                lblProgStatus1.Text = "Consultas concluídas";
            }
        }

        private void btnCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            _controller.Cancelar();

            btnCancelar.Enabled = false;
            btnIniciar.Enabled = false;
            btnCarregarPlanilha.Enabled = true;
        }

        private void btnSalvarResultado_MouseClick(object sender, MouseEventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = "Resultado consultas.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _controller.Exportar(saveDialog.FileName);
                MessageBox.Show("Arquivo salvo com sucesso!");

                btnSalvarResultado.Enabled = false;
                btnCancelar.Enabled = false;
                btnIniciar.Enabled = false;
                btnCarregarPlanilha.Enabled = true;

                txtLocalArquivo.Clear();
                lblStatusArquivo.Text = "Nenhum arquivo carregado";
                lblProgStatus1.Text = $"Aguardando seleção de um arquivo válido";
                lblProgStatus2.Text = $"Consulta não iniciada";

                progBar.Value = 0;

                _controller.Limpar();
            }
        }

        private void linkApi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.receitaws.com.br",
                UseShellExecute = true
            });
        }

        private void Controller_Progresso(int atual, int total)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Controller_Progresso(atual, total)));
                return;
            }

            progBar.Value = (int)((atual / (double)total) * 100);
            lblProgStatus2.Text = $"{atual} de {total} CNPJs";
        }

        private void Controller_Log(string mensagem)
        {
            if (InvokeRequired)
            {
                Invoke(() => Controller_Log(mensagem));
                return;
            }

            txtLogs.AppendText(
                $"{mensagem}{Environment.NewLine}");

            txtLogs.ScrollToCaret();
        }
    }
}