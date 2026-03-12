using Presentation.Utils.Enums;

namespace Presentation.Utils.HelpFunc
{
    public static class GetCaptionsByEnum
    {
        public static string GetResetButtonCaption(FormModeEnum mode)
        {
            switch (mode)
            {
                case FormModeEnum.ViewOnly:
                    return "Закрыть";
                case FormModeEnum.Edit:
                    return "Отмена";
                case FormModeEnum.Create:
                    return "Очистить";
                default:
                    return "Отмена";
            }
        }

        public static string GetActionButtonCaption(FormModeEnum mode)
        {
            switch (mode)
            {
                case FormModeEnum.ViewOnly:
                    return "Редактировать";
                case FormModeEnum.Edit:
                    return "Сохранить";
                case FormModeEnum.Create:
                    return "Добавить";
                default:
                    return "Выполнить";
            }
        }
    }
}
