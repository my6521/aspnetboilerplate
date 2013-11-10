using Abp.Modules.Core.Entities.NHibernate.Mappings;
using FluentNHibernate.Mapping;
using Taskever.Domain.Entities;
using Taskever.Domain.Enums;

namespace Taskever.Entities.NHibernate.Mappings
{
    public class FriendshipMap : EntityMap<Friendship>
    {
        public FriendshipMap()
            : base("TeFriendships")
        {
            References(x => x.Pair).Column("PairFriendshipId").Cascade.All();
            References(x => x.User).Column("UserId").LazyLoad();
            References(x => x.Friend).Column("FriendUserId").LazyLoad();
            Map(x => x.FallowActivities);
            Map(x => x.CanAssignTask);
            Map(x => x.LastVisitTime);
            Map(x => x.CreationTime);
            Map(x => x.Status).CustomType<FriendshipStatus>().Not.Nullable();
        }
    }
}