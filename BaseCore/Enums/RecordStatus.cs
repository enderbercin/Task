using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCore.Enums
{
    public enum RecordStatus
    {
        /// <summary>
        /// Aktif Kayıt
        /// </summary>
        Active = 1,

        /// <summary>
        /// Taslak
        /// </summary>
        Draft = 2,

        /// <summary>
        /// Doğrulama
        /// </summary>
        InValidation = 3,

        /// <summary>
        /// Tamamlandı
        /// </summary>
        Complete = 4,

        /// <summary>
        /// Geçici olarak devredışı
        /// </summary>
        Passive = 5,

        /// <summary>
        /// Silindi
        /// </summary>
        Deleted = 99
    }
}
