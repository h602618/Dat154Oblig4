namespace CustomerWebApp;

public class LoginUtil
{
    const string SessionKey = "_User";

    public static bool isLoggedIn(ISession session)
    {
        return !string.IsNullOrEmpty(session.GetString(SessionKey));
    }

    public static void logIn(ISession session, string value)
    {
        session.SetString(SessionKey, value);
    }

    public static string? getUser(ISession session)
    {
        return session.GetString(SessionKey);
    }

    public static bool isValid(string user, string pass)
    {
        return !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass);
    }

    public static bool validateUser(string user, string pass, string correctUser, string correctPass)
    {
        return user == correctUser && pass == correctPass;
    }
}
