namespace MusicHub.Common
{
    public static class ValidationConstants
    {
        public const int SongNameMaxLength = 40;//20 symbols nvarchar - nvarchar(40) - 2 bytes per symbol for unicode 16

        public const int AlbumNameMaxLength = 80;

        public const int PerformerFirstNameMaxLength = 40;

        public const int PerformerLastNameMaxLength = 40;

        public const int ProducerNameMaxLength = 60;

        public const int ProducerPseudonymMaxLength = 60;

        public const int ProducerPhoneNumberMaxLength = 30;

        public const int WriterNameMaxLength = 40;

        public const int WriterPseudonymMaxLength = 40;

    }
}