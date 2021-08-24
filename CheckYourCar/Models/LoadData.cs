using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CheckYourCar.Models
{
    public static class LoadData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {

                // look for any vehicle recall data
                if (db.VehicleRecalls.Any())
                {
                    return; // no load
                }
                DataTable csvFileData = GetDataTabletFromCSVFile("vehicleRecallDb.csv");
                using (SqlConnection sqlCon = new SqlConnection(db.Database.GetConnectionString()))
                {
                    sqlCon.Open();
                    using (SqlBulkCopy s = new SqlBulkCopy(sqlCon))
                    {
                        s.DestinationTableName = "VehicleRecalls";
                        for (int i = 0; i < csvFileData.Columns.Count; i++)
                        {
                            s.ColumnMappings.Add(i, i);
                        }

                        s.WriteToServer(csvFileData);
                    }
                }
            }
        }


        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return csvData;
        }
    }
}
