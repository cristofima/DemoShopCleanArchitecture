using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Core.Entities
{
    public class Log : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string Path { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        [Required]
        public string Host { get; set; }

        [Required]
        public string ClientIp { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}