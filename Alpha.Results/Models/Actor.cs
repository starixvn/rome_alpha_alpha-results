namespace Alpha.Results.Site.Models
{
    public class Actor
    {
        public Actor(int actorId, byte actorRoleId)
        {
            ActorId = actorId;
            ActorRoleId = actorRoleId;
        }

        public int ActorId { get; }

        public byte ActorRoleId { get; }
    }
}