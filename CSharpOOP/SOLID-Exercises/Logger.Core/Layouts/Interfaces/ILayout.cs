namespace Logger.Core.Layouts.Interfaces
{
    using Models.Interfaces;

    public interface ILayout
    {
        public string Format(IMessage message);
    }
}
