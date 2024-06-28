using System.ComponentModel;

namespace amorphie.core.Enums;
public enum HttpStatusEnum
{
    [Description("Tüm başarılı işlemler için kullanılır")]
    Success = 1,
    [Description("Tüm hatalı ve uyarı işlemleri için kullanılır")]
    Error = 2,
    [Description("Tüm uyuşmazlık durumlar için kullanılır")]
    Conflict = 4,
    [Description("Bulunamayan datalarda kullanılır")]
    NotFound = 8
}
