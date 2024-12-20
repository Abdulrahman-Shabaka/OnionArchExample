namespace Domain.Models.Accounts;

public static class PermissionExtensions
{
    /// <summary>
    /// Creates a Permission from its string representation.
    /// </summary>
    /// <param name="permission">The string representation of the permission.</param>
    /// <returns>The corresponding Permission enum value.</returns>
    /// <exception cref="ArgumentException">Thrown if the string doesn't match any Permission value.</exception>
    public static Permission FromString(string permission)
    {
        if (Enum.TryParse(permission, out Permission result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException($"Invalid permission value: {permission}");
        }
    }

    /// <summary>
    /// Returns FULL_ACCESS if the user is an admin, otherwise VIEW.
    /// </summary>
    /// <param name="isAdmin">Indicates whether the user is an admin.</param>
    /// <returns>The corresponding Permission based on admin status.</returns>
    public static Permission Of(bool isAdmin)
    {
        return isAdmin ? Permission.FullAccess : Permission.View;
    }
}