using ClosedXML.Excel;
using ConsultaCnpj.Models;

namespace ConsultaCnpj.Services
{
    public class ExcelService
    {
        public List<string> LerCnpjs(string filePath)
        {
            var cnpjs = new List<string>();

            using var workbook = new XLWorkbook(filePath);
            var sheet = workbook.Worksheets.First();

            var usedRange = sheet.RangeUsed();
            
            if (usedRange == null)
            {
                return cnpjs;
            }

            var headerRow = usedRange.FirstRow();
            int cnpjCol = DetectarColunaCnpj(headerRow);

            if (cnpjCol == -1)
            {
                throw new Exception("Coluna 'CNPJ' não encontrada na planilha de entrada.");
            }

            foreach (var row in usedRange.RowsUsed().Skip(1))
            {
                var cnpj = row.Cell(cnpjCol).GetString();

                if (!string.IsNullOrWhiteSpace(cnpj))
                {
                    cnpjs.Add(cnpj);
                }
            }

            return cnpjs;
        }

        public void ExportarResultados(List<ConsultaResultado> resultados, string filePath)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Resultados");

            sheet.Cell(1, 1).Value = "Resultado";
            sheet.Cell(1, 2).Value = "Erro";
            sheet.Cell(1, 3).Value = "CNPJ";
            sheet.Cell(1, 4).Value = "Nome";
            sheet.Cell(1, 5).Value = "Fantasia";
            sheet.Cell(1, 6).Value = "Tipo";
            sheet.Cell(1, 7).Value = "Porte";
            sheet.Cell(1, 8).Value = "Situação";
            sheet.Cell(1, 9).Value = "Data Situação";
            sheet.Cell(1, 10).Value = "Motivo Situação";
            sheet.Cell(1, 11).Value = "UF";
            sheet.Cell(1, 12).Value = "Município";
            sheet.Cell(1, 13).Value = "Bairro";
            sheet.Cell(1, 14).Value = "Logradouro";
            sheet.Cell(1, 15).Value = "Número";
            sheet.Cell(1, 16).Value = "Complemento";
            sheet.Cell(1, 17).Value = "CEP";
            sheet.Cell(1, 18).Value = "Email";
            sheet.Cell(1, 19).Value = "Telefone";
            sheet.Cell(1, 20).Value = "Capital Social";
            sheet.Cell(1, 21).Value = "Atividade Principal";
            sheet.Cell(1, 22).Value = "Atividades Secundárias";
            sheet.Cell(1, 23).Value = "Sócios";
            sheet.Cell(1, 24).Value = "Simples - Optante";
            sheet.Cell(1, 25).Value = "Simples - Data Opção";
            sheet.Cell(1, 26).Value = "Simples - Data Exclusão";
            sheet.Cell(1, 27).Value = "Simples - Última Atualização";
            sheet.Cell(1, 28).Value = "Simei - Optante";
            sheet.Cell(1, 29).Value = "Simei - Data Opção";
            sheet.Cell(1, 30).Value = "Simei - Data Exclusão";
            sheet.Cell(1, 31).Value = "Simei - Última Atualização";

            var header = sheet.Range(1, 1, 1, 31);
            header.Style.Font.Bold = true;

            int row = 2;

            foreach (var r in resultados)
            {
                var e = r.Empresa;

                sheet.Cell(row, 1).Value = r.Resultado;
                sheet.Cell(row, 2).Value = r.Erro;
                sheet.Cell(row, 3).Value = e?.Cnpj;
                sheet.Cell(row, 4).Value = e?.Nome;
                sheet.Cell(row, 5).Value = e?.Fantasia;
                sheet.Cell(row, 6).Value = e?.Tipo;
                sheet.Cell(row, 7).Value = e?.Porte;
                sheet.Cell(row, 8).Value = e?.Situacao;
                sheet.Cell(row, 9).Value = e?.DataSituacao;
                sheet.Cell(row, 10).Value = e?.MotivoSituacao;
                sheet.Cell(row, 11).Value = e?.Uf;
                sheet.Cell(row, 12).Value = e?.Municipio;
                sheet.Cell(row, 13).Value = e?.Bairro;
                sheet.Cell(row, 14).Value = e?.Logradouro;
                sheet.Cell(row, 15).Value = e?.Numero;
                sheet.Cell(row, 16).Value = e?.Complemento;
                sheet.Cell(row, 17).Value = e?.Cep;
                sheet.Cell(row, 18).Value = e?.Email;
                sheet.Cell(row, 19).Value = e?.Telefone;
                sheet.Cell(row, 20).Value = e?.CapitalSocial;
                sheet.Cell(row, 21).Value = ConcatenarAtividades(e?.AtividadePrincipal);
                sheet.Cell(row, 22).Value = ConcatenarAtividades(e?.AtividadesSecundarias);
                sheet.Cell(row, 23).Value = ConcatenarSocios(e?.Socios);
                sheet.Cell(row, 24).Value = BoolToSimNao(e?.Simples?.Optante);
                sheet.Cell(row, 25).Value = e?.Simples?.DataOpcao;
                sheet.Cell(row, 26).Value = e?.Simples?.DataExclusao;
                sheet.Cell(row, 27).Value = e?.Simples?.UltimaAtualizacao;
                sheet.Cell(row, 24).Value = BoolToSimNao(e?.Simei?.Optante);
                sheet.Cell(row, 29).Value = e?.Simei?.DataOpcao;
                sheet.Cell(row, 30).Value = e?.Simei?.DataExclusao;
                sheet.Cell(row, 31).Value = e?.Simei?.UltimaAtualizacao;

                row++;
            }

            sheet.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }

        private string ConcatenarAtividades(IEnumerable<Atividade>? atividades)
        {
            if (atividades == null || !atividades.Any())
            {
                return string.Empty;
            }

            return string.Join(" | ",atividades.Select(a => $"{a.Codigo} - {a.Descricao}"));
        }

        private string ConcatenarSocios(IEnumerable<Socio>? socios)
        {
            if (socios == null || !socios.Any())
            {
                return string.Empty;
            }

            return string.Join(" | ",socios.Select(s => $"{s.Nome} ({s.Qualificacao})"));
        }

        private int DetectarColunaCnpj(IXLRangeRow headerRow)
        {
            foreach (var cell in headerRow.CellsUsed())
            {
                var value = cell.GetString()?.Trim();

                if (string.Equals(value, "cnpj", StringComparison.OrdinalIgnoreCase))
                {
                    return cell.Address.ColumnNumber;
                }
            }

            return -1;
        }

        private string BoolToSimNao(bool? value)
        {
            if (value == null)
            {
                return "NÃO INFORMADO";
            }

            return value.Value ? "NÃO" : "SIM";
        }
    }
}