using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Charts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DevExpressExcelDashboard
{
	public partial class ExcelGenerator : Form
	{
		readonly string RESULT_FILE = "./sample_excel.xlsx";
		readonly string SOURCE_JSON = "./data.json";
		public ExcelGenerator()
		{
			InitializeComponent();
		}
		public class Example
		{
			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; }
			[JsonProperty(PropertyName = "type")]
			public string Type { get; set; }
			[JsonProperty(PropertyName = "price")]
			public double Price { get; set; }
		}
		public class ExampleList : List<Example>
		{

		}
		private void CreateExcelBtn_Click(object sender, EventArgs e)
		{
			if (!pivotCB.Checked && !chartCB.Checked && !tableCB.Checked)
			{
				MessageBox.Show("Please select at least one option.");
				return;
			}
			GenerateExcel();
		}
		/// <summary>
		/// Method to create Excel based on options selected by the user.
		/// </summary>
		private void GenerateExcel()
		{
			openBtn.Enabled = false;
			try
			{
				FileInfo file = new FileInfo(RESULT_FILE);
				if (IsFileAlreadyOpen(file))
				{
					return;
				}
				string text = File.ReadAllText(SOURCE_JSON);

				ExampleList list = JsonConvert.DeserializeObject<ExampleList>(text);

				Workbook book = new Workbook();
				Worksheet dataSheet = book.Worksheets[0];
				dataSheet.Name = "DataSheet";
				Cell cell = dataSheet.Cells["A1"];
				cell.Value = "EmployeeId";

				cell = dataSheet.Cells["B1"];
				cell.Value = "Type";

				cell = dataSheet.Cells["C1"];
				cell.Value = "Price";

				dataSheet.Import(list, 1, 0);

				if (chartCB.Checked)
				{
					Worksheet chartsSheet = book.Worksheets.Add("Charts");
					Chart chart = chartsSheet.Charts.Add(ChartType.Pie);
					chart.TopLeftCell = chartsSheet.Cells["B2"];
					chart.BottomRightCell = chartsSheet.Cells["P30"];
					// Add chart series using worksheet ranges as the data sources.
					Series series1 = chart.Series.Add(dataSheet["B1"], dataSheet["B2:B10"], dataSheet["C2:C10"]);
					chart.Series.Add(dataSheet["A1"], dataSheet["A2:A10"], dataSheet["C2:C10"]);
					// Display the category name and percentage.
					DataLabelOptions dataLabels = chart.Views[0].DataLabels;
					dataLabels.ShowCategoryName = true;
					dataLabels.LabelPosition = DataLabelPosition.OutsideEnd;
					dataLabels.ShowPercent = true;

				}
				if (tableCB.Checked)
				{
					Worksheet tableSheet = book.Worksheets.Add("Table");
					cell = tableSheet.Cells["A1"];
					cell.Value = "EmployeeId";

					cell = tableSheet.Cells["B1"];
					cell.Value = "Type";

					cell = tableSheet.Cells["C1"];
					cell.Value = "Price";

					tableSheet.Import(list, 1, 0);

					Table table = tableSheet.Tables.Add(tableSheet["A1:C" + (list.Count + 1)], true);
					table.ShowTotals = true;
					table.Style = book.TableStyles[BuiltInTableStyleId.TableStyleMedium27];

				}
				if (pivotCB.Checked)
				{
					Worksheet pivotSheet = book.Worksheets.Add("Pivot");

					PivotTable table = pivotSheet.PivotTables.Add(dataSheet["A1:C10"], pivotSheet["A1"], "PivotTable");
					table.RowFields.Add(table.Fields["EmployeeId"]);
					table.ColumnFields.Add(table.Fields["Type"]);
					table.DataFields.Add(table.Fields["Price"]);
					table.Style = book.TableStyles[BuiltInPivotStyleId.PivotStyleDark6];
				}
				dataSheet.Visible = false;
				dataSheet.VisibilityType = WorksheetVisibilityType.VeryHidden;

				book.SaveDocument(RESULT_FILE, DocumentFormat.Xlsx);
				MessageBox.Show("Excel created successfully.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Some error occurred, Please try again.");
			}
			openBtn.Enabled = true;
		}

		/// <summary>
		/// Method to check if a file is already opened.
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private bool IsFileAlreadyOpen(FileInfo file)
		{

			if (!file.Exists)
			{
				MessageBox.Show("File does not exists, Please create first.");
				return true;
			}
			FileStream stream = null;

			try
			{
				stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (IOException)
			{
				MessageBox.Show("File is currently open or in use, Please close the active instance first.");
				return true;
			}
			finally
			{
				if (stream != null)
					stream.Close();
			}
			return false;
		}
		private void openBtn_Click(object sender, EventArgs e)
		{
			FileInfo file = new FileInfo(RESULT_FILE);
			if (!IsFileAlreadyOpen(file))
			{
				System.Diagnostics.Process.Start(file.FullName);
			}

		}
	}
}
