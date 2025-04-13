using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

 class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }


    public  void LoadConfig()
    {
        String filePath = "covid_config.json";
        string json = File.ReadAllText(filePath);
        CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(json);
    }

    public void SaveConfig()
    {
        String filePath = "covid_config.json";
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public void UbahSatuan()
    {
        if (satuan_suhu == "celcius")
            satuan_suhu = "fahrenheit";
        else
            satuan_suhu = "celcius";

        SaveConfig();
        Console.WriteLine("Satuan suhu telah diubah menjadi: " + satuan_suhu);
    }
}