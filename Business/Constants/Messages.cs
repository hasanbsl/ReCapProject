using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Ürün Eklendi";

        public static string CarNameInvalid = "Ürün ismi geçersiz";

        public static string CarDeleded = "Ürün Silindi";

        public static string CarUpdated = "Ürün Güncellendi";

        public static string CarUpdateInvalid = "Ürün Güncellemesi geçersiz";

        public static string MaintenaceTime = "Bakım Zamanı";

        public static string CarsListed = "Araçlar Listelendi";

        public static string BrandNameInvalid = "Araç marka ismi geçersiz";

        public static string BrandAdded = "Araç Markası Eklendi";

        public static string ColorAdded = "Araç Rengi Eklendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted= "Müşteri silindi";
        public static string CustomerUpdated= "Müşteri Güncellendi";
        public static string CustomerGetAll = "Müşteriler Listelendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserGetAl = "Kullanıcılar Listelendi";
        public static string RentalUpdated = "Kiralanabilir Araç Güncellendi";
        public static string RentalInvalid = "Aracın Kiralanabilmesi için  teslim edilmesi gerekir";
        public static string RentalAdded = " Araç Kiralandı ";
        public static string RentalGetall = "Kiralanabilir Araçlar Listelendi";
        public static string FailedCarImageLimit;
        public static string CarImageUpdated;
        public static string CarImageDeleted;
        public static string CarImageAdded;

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied;
        internal static string GetErrorRentalMessage;

        public static string FindeksCalculateCompleted = "Findeks puanı hesaplandı.";
        public static string FindeksPointsSufficient = "Findeks puanı yeterli";
        public static string FindeksPointsInsufficient = "Findeks puanı yetersiz";
        internal static User GetErrorUserMessage;
        internal static string GetSuccessUserMessage;
        public static string ColorUpdate = "Renk Güncellendi";
    }
}
