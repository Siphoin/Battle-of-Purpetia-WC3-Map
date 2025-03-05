using System.Linq;
using WCSharp.Api;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public static class Portal
    {
        private static unit _portal;
        public static unit GetPortal ()
        {
            if (_portal is null)
            {
                group g = group.Create();
                GroupEnumUnitsOfPlayer(g, Player(0), null);
                foreach (var item in g.ToList().Where(item => GetUnitTypeId(item) == FourCC("h000:hbar")))
                {
                    _portal = item;
                    break;
                }
            }

            return _portal;
        }
    }
}
