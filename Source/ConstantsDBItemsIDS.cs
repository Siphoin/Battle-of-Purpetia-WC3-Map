using System.Collections.Generic;
using static WCSharp.Api.Common;
namespace Source
{
    public static class ConstantsDBItemsIDS
    {

        public static readonly HashSet<int> itemsIds = new HashSet<int>()
        {
           FourCC("ssil"), // Посох немоты
           Constants.ITEM_FPEM, // Мясо рыболюда
           // ПОСТОЯННЫЕ
            FourCC("stel"), // Посох Телепортации
            // ИМЕЮЩИЕ ЗАРЯДЫ
            FourCC("wshs"), // Жезл Чужих глаз
            FourCC("woms"), // Жезл Похищения маны
            FourCC("wlsd"), // Жезл Молний
            FourCC("will"), // Жезл Иллюзий
            FourCC("wcyc"), // Жезл Ветров
            // АРТЕФАКТЫ
            FourCC("desc"), // Кинжал мага
            // ПОДЛЕЖАЩИЕ ПРОДАЖЕ
            FourCC("ssan"), // Посох Спасения
            FourCC("silk"), // Моток паутины
            FourCC("hslv"), // Лечебный эликсир
            FourCC("wneu"), // Жезл Рассеивания
            FourCC("hlsv"), // Лечебный бальзам
            // РАЗНЫЕ
            FourCC("shtm"), // Шаманский тотем
            FourCC("ccmd"), // Скипетр Власти
            FourCC("spre"), // Посох Возвращения
            FourCC("gvsm"), // Перчатки волшебника
            FourCC("crdt"), // Корона Смерти
            FourCC("tmsc"), // Книга Жертв
            FourCC("schl"), // Жезл Исцеления
            FourCC("esaz"), // Душа Азуны

        };
    }
}
