using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using asuransi_polis.Models;

namespace asuransi_polis.Services
{
    public class PolisService
    {
        private readonly string _polisFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Polis.json");

        public PolisService()
        {
            if (!File.Exists(_polisFile))
            {
                File.WriteAllText(_polisFile, "[]");
            }
        }

        public List<Polis> GetPolisList()
        {
            var json = File.ReadAllText(_polisFile);
            return JsonSerializer.Deserialize<List<Polis>>(json);
        }

        public Polis GetPolisByNomorPolis(string nomorPolis)
        {
            var polisList = GetPolisList();
            return polisList.FirstOrDefault(p => p.NomorPolis == nomorPolis);
        }

        public void AddPolis(Polis polis)
        {
            var polisList = GetPolisList();
            polis.NomorPolis = GenerateNomorPolis();
            polisList.Add(polis);
            var json = JsonSerializer.Serialize(polisList);
            File.WriteAllText(_polisFile, json);
        }

        public void UpdatePolis(Polis polis)
        {
            var polisList = GetPolisList();
            var existingPolis = GetPolisByNomorPolis(polis.NomorPolis);
            if (existingPolis != null)
            {
                existingPolis.NamaTertanggung = polis.NamaTertanggung;
                existingPolis.TanggalEfektif = polis.TanggalEfektif;
                existingPolis.TanggalExpired = polis.TanggalExpired;
                existingPolis.MerekKendaraan = polis.MerekKendaraan;
                existingPolis.TipeKendaraan = polis.TipeKendaraan;
                existingPolis.TahunKendaraan = polis.TahunKendaraan;
                existingPolis.HargaKendaraan = polis.HargaKendaraan;
                existingPolis.RatePremi = polis.RatePremi;
                existingPolis.HargaPremi = polis.HargaPremi;
                var json = JsonSerializer.Serialize(polisList);
                File.WriteAllText(_polisFile, json);
            }
        }

        public void DeletePolis(string nomorPolis)
        {
            var polisList = GetPolisList();
            var polis = GetPolisByNomorPolis(nomorPolis);
            if (polis != null)
            {
                polisList.Remove(polis);
                var json = JsonSerializer.Serialize(polisList);
                File.WriteAllText(_polisFile, json);
            }
        }

        private string GenerateNomorPolis()
        {
            var now = DateTime.Now;
            var year = now.Year.ToString().Substring(2);
            var month = now.Month.ToString("D2");
            var day = now.Day.ToString("D2");
            var sequence = GetPolisList().Count + 1;
            return $"POL-{year}{month}{day}-{sequence:D3}";
        }
    }
}