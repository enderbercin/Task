using BaseCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore
{
    public abstract class BaseEntity
    {

        /// <summary>
        /// Veritabanı Kayıt Değeri
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Kayıt Durumu
        /// </summary>
        public RecordStatus RecordStatus { get; set; } = RecordStatus.Active;

        /// <summary>
        /// Kayıt Oluşturulma Tarihi
        /// </summary>
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Kayıt değiştirme tarihi
        /// </summary>
        public DateTime? ChangedDate { get; set; }
    }
}
