using System.Linq;
using WCSharp.Api;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class Portal
    {
        public const string ID_OBJECT = "h000:hbar";
        private static unit _portal;
        public static unit GetPortal ()
        {
            if (_portal is null)
            {
                group g = group.Create();
                GroupEnumUnitsOfPlayer(g, Player(0), null);
                foreach (var item in g.ToList().Where(item => GetUnitTypeId(item) == FourCC(ID_OBJECT)))
                {
                    _portal = item;
                    break;
                }

                DestroyGroup(g);
            }

            return _portal;
        }
    }
}
