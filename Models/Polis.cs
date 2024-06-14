using asuransi_polis.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace asuransi_polis.Models
{
    public class Polis
    {
        public string NomorPolis { get; set; }
        public string NamaTertanggung { get; set; }

        [ModelBinder(BinderType = typeof(CustomDateBinder))]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [Display(Name = "Tanggal Efektif")]
        public DateTime? TanggalEfektif { get; set; } = DateTime.Now;

        [ModelBinder(BinderType = typeof(CustomDateBinder))]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [Display(Name = "Tanggal Expired")]
        public DateTime? TanggalExpired { get; set; } = DateTime.Now;

        public string MerekKendaraan { get; set; }
        public string TipeKendaraan { get; set; }
        public int TahunKendaraan { get; set; }
        public decimal HargaKendaraan { get; set; }
        public decimal RatePremi { get; set; }
        public decimal HargaPremi { get; set; }
    }
}