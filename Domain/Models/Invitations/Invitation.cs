using Domain.Models.Accounts;

namespace Domain.Models.Invitations;

public class Invitation(MobileNumber invitedMobileNumber, Guid inviterId) : IEquatable<Invitation>
{
    public MobileNumber InvitedMobileNumber { get; } = invitedMobileNumber;
    public Guid InviterId { get; } = inviterId;

    public static Invitation Create(string invitedMobileNumber, Guid inviterId) =>
        new(
            MobileNumber.Of(invitedMobileNumber),
            inviterId
        );

    public static Invitation NewInvitation(string invitedMobileNumber, Guid inviterId) => Create(invitedMobileNumber, inviterId);

    public bool Equals(Invitation? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        var that = (Invitation)obj;
        return EqualityComparer<MobileNumber>.Default.Equals(InvitedMobileNumber, that.InvitedMobileNumber) &&
               EqualityComparer<Guid>.Default.Equals(InviterId, that.InviterId);
    }

    public override int GetHashCode() => HashCode.Combine(InvitedMobileNumber, InviterId);

    public override string ToString() => $"Invitation{{InvitedMobileNumber={InvitedMobileNumber}, InviterId={InviterId}}}";
}